﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Spreadsheet;
using SpreadsheetLight;

//TODO: Add Logging
//TODO: Getting complicated, may want to add a class for the key message to hold all the data related to it e.g. slide number, clickrtream records.

namespace ManageMetadata
{
    class clsManageMetadata
    {
        //Config constants (move to config file later)

        public string KeyMessageCol = "K";              //Column containing zip file names in publishing form.  Do we need to validate Zip file names against the Key Message Name column too?
        public string pubclickstreamkeycolumn = "D";          //Column containing clickstream key message numbers in publishing form
        public string pubkeynumbercolumn = "B";          //Column containing presentation tab key message numbers in publishing form
        public string pubclickstreamcolumn = "A";          //Column containing clickstream names in publishing form

        public string clickstreamcolumn = "F";          //Column containing clickstream names in clickstream report
        public string clickstreamkeycolumn = "D";          //Column containing clickstream key message names in clickstream report
        public string prescolumn = "K";                 //Column containing presentation IDs in presentation report

        public string PresIDCell = "C20";
        public string PresTab = "Presentation-Slide metadata";
        public string ClickTab = "clickstream data";         
        public int keymessagestartrow = 36;             //Row where key messages start in publishing form
        public int clickstreamstartrow = 4;             //Row where clickstream start in publishing form
        public int repstartrow = 1;             //Row where clickstream (and pres ids) start in report 

        public string logfile = "ValidationErrors.log";
        public string pubPath = "";                 //Folder containing publishing forms - PUB_FORM
        public string metaPath = "METADATA";                //Folder containing metadata forms
        public string mappingfiles = "";                    //Folder containing original publishing forms (pre renaming of key messages)
        public int[] NonMetadataColumns = { 1, 9, 11 };     //Index of columns which do not appear in metadata sheet but do appear in publishing form
        public bool recusePubFolders = false;               //Whether or not to recurse folders in the publising forms
        public string sourcePath;           //Contains code
        public string clickstreamfile;                      //Report containing Clickstream data for validation
        public string presrepfile;                      //Report containing Presentation Details for validation

        private string folderPath;           //Top path which contains publishign forms and metadata.
        
        //Don't really need full dictionary but gives some future proofing
        private SortedDictionary<string, string> keymessages;           //KeyMessage, PresID    //Zip file names, for now
        private SortedDictionary<string, string> oldkeymessages;        //KeyMessage, PresID    //Previous Zip file names, for now
        private Dictionary<string, bool> sourcefolders;                  //KeyMessage, Validated   //Source Code Folders
        private SortedDictionary<string, string> missingfolders;        //KeyMessage, PresID  Exist in folders but not in spreadsheets
        private SortedDictionary<string, string> pubforms;              //Filename, PresentationID     //Actual Publishing Forms
        private SortedDictionary<string, string> previouspubforms;     //Filename, PresentationID       //Previous Publishing Forms (used when doing mass rename)
        private SortedDictionary<string, string> clickstreams;           //clickstream, KeyMessage   
        private string  pubfolder;     
        private string metafolder;
        private string ProjectName;

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

        public SortedDictionary<string, string> getPresentationsAndKeyMessages() {
            return keymessages; 
        }
        public string getProjectName()
        {
            //In the abence of any other method just grab the first one (later on be more clever and find the one that has no "_LO" on the end
            return keymessages.Keys.First<string>();
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
            clickstreams = new SortedDictionary<string, string>();
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

        //TODO compare common code to ExtractClickstream and refactor

        private void ExtractKeyMessage(string filename, string thisFolder, bool current = true)
        {
            //Extract key messages from publishing form
            string PresID="";
            SLDocument pubform = new SLDocument(thisFolder + "\\" + filename);
            string curSheet = pubform.GetCurrentWorksheetName();
            if (curSheet != "") { pubform.SelectWorksheet(PresTab); }
            SLWorksheetStatistics stats1 = pubform.GetWorksheetStatistics();
            //Get Presentation ID
            PresID = pubform.GetCellValueAsString(PresIDCell);
            //Vulnerability on EndRowIndex (AbbVie Care and Safety Profile for RA)//Think I fixed it - need to ensure worksheet is selected before making the Statistics call
            for (int j = keymessagestartrow; j <= stats1.EndRowIndex; j++)
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

        //TODO refactor as similar code to above
        //Extract Clickstream details from publishing form
        private void ExtractClickstream(string filename, string thisFolder)
        {
            //Extract clickstreams from publishing form
            SLDocument pubform = openPubForm(thisFolder + "\\" + filename);
            string curSheet = pubform.GetCurrentWorksheetName();
            pubform.SelectWorksheet(PresTab); 
            string PresID = pubform.GetCellValueAsString(PresIDCell);
            SLWorksheetStatistics stats1 = pubform.GetWorksheetStatistics();
            Dictionary<string, string> keymessagenumberstonames = new Dictionary<string, string>();
            //Get Key Message Number to Name Mapping - no need to store Presentation id as disposable lookup dictionary on a per spreadsheet basis 
            for (int j = keymessagestartrow; j <= stats1.EndRowIndex; j++)
            {
                
                string kmzip = pubform.GetCellValueAsString(KeyMessageCol + j);
                string kmnumber = pubform.GetCellValueAsString(pubkeynumbercolumn + j);
                try { keymessagenumberstonames.Add(kmnumber, kmzip);  } catch (Exception e) { if (e.HResult == -2147024809) { } else { throw e; } }                  //Allow for duplicates
            }
            pubform.SelectWorksheet(ClickTab);
            stats1 = pubform.GetWorksheetStatistics();
            for (int j = clickstreamstartrow; j < stats1.EndRowIndex; j++)
            {
                string clickstream = pubform.GetCellValueAsString(pubclickstreamcolumn + j);               //Clickstream name
                string clickstreamkey = pubform.GetCellValueAsString(pubclickstreamkeycolumn + j);         //Key Message Number
                string clickstreamname = "";
                bool hasValue = keymessagenumberstonames.TryGetValue(clickstreamkey, out clickstreamname);                                                                                           //Lookup Key Message Number using dictionary generated earlier
                if (!hasValue) { }  //TODO: Handle the lack of a lookup?
                    try { clickstreams.Add(PresID + "#" + clickstreamname + "@" + clickstream, clickstream);}                //Concatenated PresID, Key Name and Clicksteam so can still just use string dictionaries in case can refactor later to be same as key message
                    catch (Exception e){if (e.HResult == -2147024809){}else{throw e;}}                  //Allow for duplicates
            }
        }
        //TODO: Refactor these two functions into one - only difference is the dictionary being iterated
        //iterate publishing forms and extract key messages
        //Wait until done clickstream too as may have further common code
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

        private void ExtractClickStreamNames()
        {
            //List publising forms
            listFileNames(pubfolder);           //Populate list of Publishing Form spreadsheets
            //Extract Clickstreams from them
            foreach (var f in pubforms)
            {
                ExtractClickstream(f.Value, pubfolder);
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
            
            var files = from file in Directory.EnumerateFiles(folder, "*.xls*", RecurseFolders) select Path.GetFileName(file);  //select new {filename = Path.GetFileName(file), Path = Path.GetDirectoryName 
            foreach (var f in files)
            {
                //TODO: Open File with Spreadsheet Light and get the Presentation Name (currenlty working on single folder only, need to change Select above)
                SLDocument pubform = openPubForm(folder + "\\" + f);
                string PresID = pubform.GetCellValueAsString(PresIDCell);
                if (current) { pubforms.Add(PresID + f, f); }else { previouspubforms.Add(PresID + f, f); }
            }
        }

        private SLDocument openPubForm(string pathtofile, bool forPres = true) {
            SLDocument pubform = new SLDocument(pathtofile);
            // Irrelevent string curSheet = pubform.GetCurrentWorksheetName();
            //if (curSheet != "") { }
            if (forPres) { pubform.SelectWorksheet(PresTab); } else { pubform.SelectWorksheet(ClickTab); }
            return pubform;
        }

        //Check Key Messages in Sheets against Key Messages in Source Code
        //TODO: Try and refactor to use same codebase as CompareClickstreams
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

        public void validateClickstreams()
        {
            //Open Excel Clickstream Report File and extract list of clickstreamids
            SLDocument repform = new SLDocument(clickstreamfile);
            Dictionary<string, bool> reportclickstreams = new Dictionary<string, bool>();           //Bool indicates validated
            SLWorksheetStatistics stats1 = repform.GetWorksheetStatistics();
            for (int j = repstartrow; j <= stats1.EndRowIndex; j++)
            {
                string clickstream = repform.GetCellValueAsString(clickstreamcolumn + j);               //Clickstream name
                string clickstreamkey = repform.GetCellValueAsString(clickstreamkeycolumn + j);         //Key Message Name
                string presid = repform.GetCellValueAsString(prescolumn + j);                           //Presentation ID
                try { reportclickstreams.Add(presid + "#" + clickstreamkey + "@" + clickstream, false); }                //Concatenated PresID, Key and Clicksteam so can still just use string dictionaries in case can refactor later to be same as key message
                catch (Exception e) { if (e.HResult == -2147024809) { } else { throw e; } }                  //Allow for duplicates
            }

            //Query all presentations for CLickstream information
            ExtractClickStreamNames();
            //Run comparison
            CompareClickstreams(reportclickstreams);

        }

        private void CompareClickstreams(Dictionary<string, bool> reportclickstreams) {

            SortedDictionary<string, string> missingstreams = new SortedDictionary<string, string>();
            HashSet<string> lines = new HashSet<string>();
            lines.Add("Clickstreams Missing from Veeva:");
            string[] headermessage = new string[] { "Clickstreams found in Veeva but not found in publishing forms" };
            //Validate names in publishing form match folders
            //Don't use a clever (big O) comparison as may not be a perfect match
            foreach (var v in clickstreams)
            {
                if (reportclickstreams.ContainsKey(v.Key))
                {
                    reportclickstreams[v.Key] = true;      //Flag as validated
                }
                else
                {
                    //Key Message from spreadsheets has no corresponding folder
                    missingstreams.Add(v.Key, v.Value);
                }
            }

            //Identify any clickstreams that are still invalid (i.e. no key message in spreadsheet matches)

            if (reportclickstreams.ContainsValue(false))
            {
                var matches = reportclickstreams.Where(pair => pair.Value != true).Select(pair => pair.Key);
                Console.Write(matches.ToString());
                System.IO.File.WriteAllLines(folderPath + "\\Clickstream" + logfile, headermessage);
                System.IO.File.AppendAllLines(folderPath + "\\Clickstream" + logfile, matches.ToArray<string>());
            }

            //Also need to identify if any messages in the spreadsheets lack a corresponding folder
            foreach (var v in missingstreams)
            {
                Console.WriteLine(v.Key);
                lines.Add(v.Key);
            }
            System.IO.File.AppendAllLines(folderPath + "\\Clickstream" + logfile, lines.ToArray<string>());




        }

        //TODO refactor with Validate Clickstreams for the report extraction bit
        public void validatePresentations()
        {
            Dictionary<string, string> presreport = new Dictionary<string, string>();           //Reported Presenation IDs
            Dictionary<string, bool> pubformpres = new Dictionary<string, bool>();           //Publishing Form Presenation IDs - bool indicates if validated or not
            SortedDictionary<string, string> missingpubs = new SortedDictionary<string, string>();

            //Grab Presentation IDs from each publishing form using presentation report
            //List publising forms
            listFileNames(pubfolder);           //Populate list of Publishing Form spreadsheets
            foreach (var f in pubforms)
            {
                SLDocument pubform = openPubForm(pubfolder + "\\" + f.Value);
                string curSheet = pubform.GetCurrentWorksheetName();
                pubform.SelectWorksheet(PresTab);
                string PresID = pubform.GetCellValueAsString(PresIDCell);
                try { pubformpres.Add(PresID, false); }         //Default to not validated
                catch (Exception e) { if (e.HResult == -2147024809) { } else { throw e; } }                  //Allow for duplicates
            }


            //Then verify against the Presentation IDs in Veeva  (and those coded into "GotoSlide" in the pages?  No, rely on manual checks for that for now)
            //Use publishing report
            //Open Excel Clickstream Report File and extract list of clickstreamids
            SLDocument repform = new SLDocument(presrepfile);
            SLWorksheetStatistics stats1 = repform.GetWorksheetStatistics();
            for (int j = repstartrow; j <= stats1.EndRowIndex; j++)
            {
                string Pres = repform.GetCellValueAsString(prescolumn + j);               //Presentation ID
                try { presreport.Add(Pres, Pres); }                
                catch (Exception e) { if (e.HResult == -2147024809) { } else { throw e; } }                  //Allow for duplicates
            }

            //Now Compare

            
            HashSet<string> lines = new HashSet<string>();
            lines.Add("Presentation IDs Missing from Publishing Forms :");
            string[] headermessage = new string[] { "Presentations found in Publising Form but not found in Veeva" };
            //Validate names in publishing form match folders
            //Don't use a clever (big O) comparison as may not be a perfect match
            foreach (var v in presreport)
            {
                if (pubformpres.ContainsKey(v.Key))
                {
                    pubformpres[v.Key] = true;      //Flag as validated
                }
                else
                {
                    //Presentation from spreadsheets has no corresponding entry in Veeva
                    missingpubs.Add(v.Key, v.Value);
                }
            }

            //Identify any pubforms that are still invalid (i.e. not presenation in veeva matches)

            if (pubformpres.ContainsValue(false))
            {
                var matches = pubformpres.Where(pair => pair.Value != true).Select(pair => pair.Key);
                Console.Write(matches.ToString());
                System.IO.File.WriteAllLines(folderPath + "\\PresentationValidation" + logfile, headermessage);
                System.IO.File.AppendAllLines(folderPath + "\\PresentationValidation" + logfile, matches.ToArray<string>());
            }

            //Also need to identify if any veeva presentations lack a corresponding pub form
            foreach (var v in missingpubs)
            {
                Console.WriteLine(v.Key);
                lines.Add(v.Key);
            }
            System.IO.File.AppendAllLines(folderPath + "\\PresentationValidation" + logfile, lines.ToArray<string>());

            //For completeness, probably worth writing out the "true", i.e. validated, publishing form names, so can see that all the lists tie up together.

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
