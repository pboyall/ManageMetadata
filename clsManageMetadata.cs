using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using SpreadsheetLight;

namespace ManageMetadata
{
    class clsManageMetadata
    {
        //Config constants (move to config file later)

        public string KeyMessageCol = "K";              //Column containing zip file names.  Do we need to validate Zip file names against the Key Message Name column too?
        public string PresIDCell = "C20";
        public string PresTab = "Presentation-Slide metadata";
        public int keymessagestartrow = 36;             //Row where key messages start in publishing form
        public string logfile = "ValidationErrors.log";
        public string pubPath = "PUB_FORM";             //Folder containing publishing forms
        public string metaPath = "METADATA";             //Folder containing metadata forms
        public int[] NonMetadataColumns = { 1, 9, 11 };     //Index of columns which do not appear in metadata sheet but do appear in publishing form
        public bool recusePubFolders = false;               //Whether or not to recurse folders in the publising forms

        public string folderPath;           //Top path which contains publishign forms and metadata.
        public string sourcePath;
        //Don't really need full dictionary but gives some future proofing
        private Dictionary<string, string> keymessages; //KeyMessage, PresID    //Zip file names, for now
        private Dictionary<string, bool> folders;     //KeyMessage, Validated
        private Dictionary<string, string> missingfolders; //KeyMessage, PresID  Exist in folders but not in spreadsheets
        private Dictionary<string, string> pubforms;     //Filename, PresentationID
        private string  pubfolder;     
        private string metafolder;     


        public clsManageMetadata()
        {
            //Hard code pubfolder and metafolder based on parent
            pubfolder = folderPath + "\\" + pubPath;
            metafolder = folderPath + "\\" + metaPath;

            folders = new Dictionary<string, bool>();
            keymessages = new Dictionary<string, string>();
            pubforms = new Dictionary<string, string>();
        }

        public void validateKeyMessages()
        {
            //Iterate Source Folder Path
            ListFolderNames();
            //Iterate Key Message Names in Spreadsheets
            ExtractKeyMessages();
            //Compare the spreadsheet names with the source names
            CompareKeyMessages();

        }

        private void ExtractKeyMessage(string filename)
        {
            //Extract key messages from publishing form
            string PresID="";
            SLDocument pubform = new SLDocument(folderPath + "\\" + filename);
            SLWorksheetStatistics stats1 = pubform.GetWorksheetStatistics();
            //Get Presentation ID

            string curSheet = pubform.GetCurrentWorksheetName();
            if (curSheet != "") { pubform.SelectWorksheet(PresTab); }

            PresID = pubform.GetCellValueAsString(PresIDCell);
            //Vulnerability on EndRowIndex (AbbVie Care and Safety Profile for RA)
            for (int j = 36; j < stats1.EndRowIndex; j++)
            {
                string kmzip = pubform.GetCellValueAsString(KeyMessageCol + j);
                if (kmzip.Contains(".zip"))
                {
                    try { 
                    keymessages.Add(kmzip.Replace(".zip", ""), PresID);
                    }catch(Exception e)
                    {
                        if(e.HResult == -2147024809)
                        {
                            //Ignore as duplicate keys can occur if same key message in more than one presentation

                        }else
                        {
                            //Re raise?
                            throw e;
                        }
                    }
                }
            }
        }

        //iterate publishing forms and extract key messages
        private void ExtractKeyMessages()
        {

            //List publising forms
            listFileNames();           //Populate list of Publishing Form spreadsheets
            //Extract KeyMessages from them
            foreach(var f in pubforms)
            {
                ExtractKeyMessage(f.Value);
            }
        }

//List Source Code Folders
        private void ListFolderNames()
        {
            //List key message names in given folder
            //Default to unvalidated
            try
            {
                List<string> dirs = new List<string>(Directory.EnumerateDirectories(sourcePath));
                foreach (var dir in dirs)
                {
                    folders.Add(dir.Substring(dir.LastIndexOf("\\") + 1), false);
                }
            }
            catch (UnauthorizedAccessException UAEx)
            {
                Console.WriteLine(UAEx.Message);
            }
            catch (PathTooLongException PathEx)
            {
                Console.WriteLine(PathEx.Message);
            }
        }

//List the names of the Publishing forms
        private void listFileNames()
        {
            /*  var files = from file in Directory.EnumerateFiles(@"c:\", "*.txt", SearchOption.AllDirectories)
                          from line in File.ReadLines(file)
                          where line.Contains("Microsoft")
                          select new
                          {
                              File = file,
                              Line = line
                          };
              */
            System.IO.SearchOption RecurseFolders = SearchOption.TopDirectoryOnly;
            if(recusePubFolders)
            { RecurseFolders = SearchOption.AllDirectories; }
            else
            { RecurseFolders = SearchOption.TopDirectoryOnly;}

        var files = from file in Directory.EnumerateFiles(folderPath, "*.xls*", RecurseFolders) select Path.GetFileName(file);
            foreach (var f in files)
            {
                //TODO: Open File with Spreadsheet Light and get the Presentation Name
                pubforms.Add("DummyPresName" + f, f);
            }
        }

        

        //Check Key Messages in Sheets against Key Messages in Source Code

        private void CompareKeyMessages()
        {
            missingfolders = new Dictionary<string, string>();
            HashSet<string> lines = new HashSet<string>() ;
            lines.Add("Key Messages Missing from folders:");
            string[] headermessage = new string[] { "Key Messages found in folders but not found in spreadsheet"};
            //Validate names in publishing form match folders
            //Don't use a clever (big O) comparison as may not be a perfect match
            foreach (var v in keymessages)
            {
                if (folders.ContainsKey(v.Key))
                {
                    folders[v.Key] = true;      //Flag as validated
                }
                else
                {
                    //Key Message from spreadsheets has no corresponding folder
                    missingfolders.Add(v.Key, v.Value);
                }
            }

            //Identify any folders that are still invalid (i.e. not key message in spreadsheet matches)

            if (folders.ContainsValue(false))
            {
                // var matches = dict.Where(pair => pair.Value.Contains("abc")) .Select(pair => pair.Key);
                var matches = folders.Where(pair => pair.Value != true).Select(pair => pair.Key);
                Console.Write(matches.ToString());
                System.IO.File.WriteAllLines(folderPath + "\\" + logfile, headermessage);
                System.IO.File.AppendAllLines(folderPath + "\\" + logfile, matches.ToArray<string>());
            }

            //Also need to identify if any messages in the spreadsheets lack a corresponding folder
            foreach (var v in missingfolders)
            {
                Console.WriteLine(v.Key);
                lines.Add(v.Key);
            }
            System.IO.File.AppendAllLines(folderPath + "\\" + logfile, lines.ToArray<string>());


        }

        //For each sheet in the publishing form folder, create a metadata sheet by deleting the unneeded columns
        public void createMetadata()
        {
            listFileNames();
            foreach (var f in pubforms) { 
                SLDocument sl = new SLDocument(folderPath + "\\" + f.Value);
                // delete 1 column at column 6 - sl.DeleteColumn(6, 1);
                foreach (var i in NonMetadataColumns)
                {
                    sl.DeleteColumn(i, 1);
                }
                sl.SaveAs(folderPath + "\\" + f.Value + " - Metadata.xlsx");
            }
        }


        //Where names have been updated in publishing form, rename source zip files
        public void RenameZips()
        {
            ListFolderNames();
            listFileNames();



        }

    }
}
