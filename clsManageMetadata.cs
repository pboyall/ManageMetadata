using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using SpreadsheetLight;

//TODO: Add Logging

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
        public string pubPath = "";                 //Folder containing publishing forms - PUB_FORM
        public string metaPath = "METADATA";                //Folder containing metadata forms
        public string mappingfiles = "";                    //Folder containing original publishing forms (pre renaming of key messages)
        public int[] NonMetadataColumns = { 1, 9, 11 };     //Index of columns which do not appear in metadata sheet but do appear in publishing form
        public bool recusePubFolders = false;               //Whether or not to recurse folders in the publising forms


        private string folderPath;           //Top path which contains publishign forms and metadata.
        public string sourcePath;           //Contains code
        //Don't really need full dictionary but gives some future proofing
        private SortedDictionary<string, string> keymessages;           //KeyMessage, PresID    //Zip file names, for now
        private SortedDictionary<string, string> oldkeymessages;        //KeyMessage, PresID    //Previous Zip file names, for now
        private Dictionary<string, bool> sourcefolders;                  //KeyMessage, Validated   //Source Code Folders
        private SortedDictionary<string, string> missingfolders;        //KeyMessage, PresID  Exist in folders but not in spreadsheets
        private SortedDictionary<string, string> pubforms;              //Filename, PresentationID     //Actual Publishing Forms
        private SortedDictionary<string, string> previouspubforms;     //Filename, PresentationID       //Previous Publishing Forms (used when doing mass rename)
        private string  pubfolder;     
        private string metafolder;

        public string FolderPath
        {
            get
            {
                return folderPath;
            }

            set
            {
                folderPath = value;
                pubfolder = folderPath + "\\" + pubPath;
                metafolder = folderPath + "\\" + metaPath;
            }
        }

        public clsManageMetadata()
        {
            //Hard code pubfolder and metafolder based on parent
            pubfolder = folderPath + "\\" + pubPath;
            metafolder = folderPath + "\\" + metaPath;
            //Not using the above yet as don't have a standard!!!
            initialise();
        }

        //Redo all dictionaries
        public void initialise()
        {
            sourcefolders = new Dictionary<string, bool>();
            keymessages = new SortedDictionary<string, string>();
            oldkeymessages = new SortedDictionary<string, string>();
            pubforms = new SortedDictionary<string, string>();
            previouspubforms = new SortedDictionary<string, string>();
        }

        //Confirm that Key Messages in current publishing forms are also contained in the Source Code Folders
        public void validateKeyMessages()
        {
            //Iterate Source Folder Path
            ListFolderNames();
            //Iterate Key Message Names in Spreadsheets
            ExtractKeyMessages(pubfolder);
            //Compare the spreadsheet names with the source names
            CompareKeyMessages();
        }

        private void ExtractKeyMessage(string filename, string thisFolder, bool current = true)
        {
            //Extract key messages from publishing form
            string PresID="";
            SLDocument pubform = new SLDocument(thisFolder + "\\" + filename);
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
                        if (current) { 
                            keymessages.Add(kmzip.Replace(".zip", ""), PresID);
                        }else
                        {
                            oldkeymessages.Add(kmzip.Replace(".zip", ""), PresID);
                        }
                    }
                    catch(Exception e)
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

        //TODO: Refactor these two functions into one - only difference is the dictionary being iterated
        //iterate publishing forms and extract key messages
        private void ExtractKeyMessages(string folder, bool current=true)
        {
            //List publising forms
            listFileNames(folder, current);           //Populate list of Publishing Form spreadsheets
            //Extract KeyMessages from them
            foreach (var f in pubforms)
            {
                ExtractKeyMessage(f.Value, folder, current);
            }
        }

        private void ExtractOldKeyMessages(string folder, bool current = false)
        {
            //List publising forms
            listFileNames(folder, current);           //Populate list of Publishing Form spreadsheets
            //Extract KeyMessages from them
            foreach (var f in previouspubforms)
            {
                ExtractKeyMessage(f.Value, folder, current);
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
                    sourcefolders.Add(dir.Substring(dir.LastIndexOf("\\") + 1), false);
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
        private void listFileNames(string folder, bool current = true)
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

            var files = from file in Directory.EnumerateFiles(folder, "*.xls*", RecurseFolders) select Path.GetFileName(file);
            foreach (var f in files)
            {
                //TODO: Open File with Spreadsheet Light and get the Presentation Name
                if (current) { pubforms.Add("DummyPresName" + f, f); }else { previouspubforms.Add("DummyPresName" + f, f); }
            }
        }

        

        //Check Key Messages in Sheets against Key Messages in Source Code

        private void CompareKeyMessages()
        {
            missingfolders = new SortedDictionary<string, string>();
            HashSet<string> lines = new HashSet<string>() ;
            lines.Add("Key Messages Missing from folders:");
            string[] headermessage = new string[] { "Key Messages found in folders but not found in spreadsheet"};
            //Validate names in publishing form match folders
            //Don't use a clever (big O) comparison as may not be a perfect match
            foreach (var v in keymessages)
            {
                if (sourcefolders.ContainsKey(v.Key))
                {
                    sourcefolders[v.Key] = true;      //Flag as validated
                }
                else
                {
                    //Key Message from spreadsheets has no corresponding folder
                    missingfolders.Add(v.Key, v.Value);
                }
            }

            //Identify any folders that are still invalid (i.e. not key message in spreadsheet matches)

            if (sourcefolders.ContainsValue(false))
            {
                // var matches = dict.Where(pair => pair.Value.Contains("abc")) .Select(pair => pair.Key);
                var matches = sourcefolders.Where(pair => pair.Value != true).Select(pair => pair.Key);
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
            listFileNames(folderPath);
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
            Dictionary<string, string> mapmessages = new Dictionary<string, string>();
            //Get list of key messages which are in publishing forms and not in folders
            validateKeyMessages();
            //How do we map from one to the other?  Need a mapping file - use the previous version of the publishing forms
            ExtractOldKeyMessages(mappingfiles, false);
            //Compare old and new Key message lists to generate a mapping dictionary
            MapKeys(ref mapmessages);
            //Go through source folders and rename those found in mapmessages

        }

        private void MapKeys(ref Dictionary<string, string> mapmessages)
        {
            var s = new SortedList<string, string>(keymessages);

            //Compare each current current key message
            foreach (var v in keymessages)
            {
                //and see if it existed previous
                if (!oldkeymessages.ContainsKey(v.Key))
                {
                    //Key Message has changed name
                    //Look on same line in oldkeymessages spreadsheet and add to dictionary of changed messages
                    int index = s.IndexOfKey(v.Key);
                    mapmessages.Add(v.Key, oldkeymessages.ElementAt(index).Key);
                }
            }
            //For each changed message, rename the folder
            foreach (var f in mapmessages) {
                try
                {
                    Directory.Move(sourcePath + "\\" + f.Value, sourcePath + "\\" + f.Key);
                }
                catch { }
                //Now go through every source code file and rename any occurence of the renamed zips
                //Open each html and js file
                replaceLinks("*.html", mapmessages);
                replaceLinks("*.js", mapmessages);
            }
        }

        private void replaceLinks(string filetype, Dictionary<string, string> mapmessages)
        {
            foreach (var f in mapmessages) { 
                        //Open each html and js file
                        var files = from file in Directory.EnumerateFiles(sourcePath, filetype, SearchOption.AllDirectories)
                                from line in File.ReadAllLines(file)
                                where line.Contains(f.Value)
                                select new
                                {
                                    File = file,
                                    Line = line
                                };
                    foreach (var g in files)
                    {
                        //Optimise by only doing any given file once.
                        string fileContents = System.IO.File.ReadAllText(g.File);
                        fileContents = fileContents.Replace("gotoSlide(" + f.Value + ".zip", "gotoSlide(" + f.Key + ".zip");
                        fileContents = fileContents.Replace("pkg_id: \"" + f.Value + ".zip\"", "pkg_id: \"" + f.Key + ".zip\"");
                        System.IO.File.WriteAllText(g.File, fileContents);
                    }
            }
        }

        }
    }




/*
 *Code to work around locking issues
                        string gotoreplace = "gotoSlide(71.5_RA_HUM_SEG8_UK_EN_CONCERTO MTX DOSES_LO.zip,";
                        string packagereplace = "pkg_id: \"10_RA_HUM_SEG8_UK_EN_GLOBAL PI_LO.zip\"";
 *                        using (FileStream inStream = new FileStream(g.File, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        {
                            using (StreamReader sr = new StreamReader(inStream))
                            {
                                fileContents = sr.ReadToEnd();
                                sr.Close();
                                sr.Dispose();
                            }
                            inStream.Close();
                            inStream.Dispose();
                        }*/
