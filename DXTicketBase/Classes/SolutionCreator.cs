using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace DXTicketBase.Classes {
    class SolutionCreator {
        private string ticketNumber;
        private string folderPath;

        public SolutionCreator(string _ticketNumber, string _folderPath, string _dropBoxPath, string _sourceSolutionPath) {
            this.ticketNumber = _ticketNumber;
            this.folderPath = _folderPath;
            this.dropBoxPath = _dropBoxPath;
            this.sourceSolutionPath = _sourceSolutionPath;
        }
        string sourceSolutionPath = "";
        string dropBoxPath = "";
        string slnPathWithProjectName = "";
        string folderNumber = "";
        string finalSolutionFolderPath = "";
        internal void CreateSolution() {
            folderNumber = "dx" + ticketNumber;
            finalSolutionFolderPath = folderPath + string.Format(@"\{0}\", folderNumber);
            bool canNotCreateSolution = true;
            int tmpCount = 0;
            MessageBoxResult? needCreateNewOne = null;
            string tmpFolderNumber = null;
            do {
                var isAlreadyExist = Directory.Exists(finalSolutionFolderPath);
                if(isAlreadyExist) {
                    if(needCreateNewOne == null)
                        needCreateNewOne = MessageBox.Show("Solution exists. Create a new one?", "Already exists", MessageBoxButton.YesNo);
                    if(needCreateNewOne.Value == MessageBoxResult.Yes) {
                        tmpFolderNumber = folderNumber + "v" + ++tmpCount;
                        finalSolutionFolderPath = folderPath + string.Format(@"\{0}\", tmpFolderNumber);
                    } else {
                        return;
                    }
                } else {
                    canNotCreateSolution = false;
                    if(tmpFolderNumber != null)
                        folderNumber = tmpFolderNumber;
                }
            } while(canNotCreateSolution);
            Directory.CreateDirectory(finalSolutionFolderPath);
            File.Copy(Path.Combine(dropBoxPath, @"work\templates\MainSolution\delbinobj.bat"), Path.Combine(finalSolutionFolderPath, "delbinobj.bat"));
            var gitBatchFile = Path.Combine(finalSolutionFolderPath, "createGit.bat");
            File.Copy(Path.Combine(dropBoxPath, @"work\templates\MainSolution\createGit.bat"), gitBatchFile);
            File.Copy(Path.Combine(dropBoxPath, @"work\templates\MainSolution\.gitignoreToCopy"), Path.Combine(finalSolutionFolderPath, ".gitignore"));


            List<string> filesWithSolutionName = new List<string>();
            string pattern;
            List<string> tokens = new List<string>();
            if(FirstProjectType == FirstProjectEnum.XPO) {
                pattern = "dxTestSolutionXPO";
                sourceSolutionPath = dropBoxPath + @"work\templates\MainSolution\ConsoleApp1\";
                DirectoryCopy(sourceSolutionPath, finalSolutionFolderPath, true);
                filesWithSolutionName.Add(@"dxTestSolutionXPO\dxTestSolutionXPO.csproj");
                filesWithSolutionName.Add(@"dxTestSolutionXPO\\");
                filesWithSolutionName.Add(@"dxTestSolutionXPO.sln");
                if(SelectedModules != null && SelectedModules.Contains("inmemory")) {
                    tokens.Add("inmemory");
                }
            } else {
                pattern = "dxTestSolution";

                DirectoryCopy(sourceSolutionPath, finalSolutionFolderPath, "dxTestSolution.Module", true);
                File.Copy(sourceSolutionPath + "dxTestSolution.sln", finalSolutionFolderPath + "dxTestSolution.sln", true);
                DirectoryCopy(sourceSolutionPath, finalSolutionFolderPath, "dxTestSolution.Module.Win", true);
                DirectoryCopy(sourceSolutionPath, finalSolutionFolderPath, "dxTestSolution.Win", true);
                DirectoryCopy(sourceSolutionPath, finalSolutionFolderPath, "dxTestSolution.Module.Web", true);
                DirectoryCopy(sourceSolutionPath, finalSolutionFolderPath, "dxTestSolution.Web", true);
                if(SelectedModules != null && SelectedModules.Contains("report")) {
                    File.Copy(sourceSolutionPath + @"Controllers\ClearReportCacheController.cs", finalSolutionFolderPath + @"dxTestSolution.Module\Controllers\ClearReportCacheController.cs");
                }
                if(SelectedModules != null && SelectedModules.Contains("office")) {
                    File.Copy(sourceSolutionPath + @"Controllers\ClearMailMergeCacheController.cs", finalSolutionFolderPath + @"dxTestSolution.Module.Win\Controllers\ClearMailMergeCacheController.cs");
                }
                switch(FirstProjectType) {
                    case FirstProjectEnum.Web:
                        DirectoryCopy(sourceSolutionPath + ".vsWeb", finalSolutionFolderPath + ".vs", true);
                        break;
                    case FirstProjectEnum.Win:
                        DirectoryCopy(sourceSolutionPath + ".vsWin", finalSolutionFolderPath + ".vs", true);
                        break;
                }

                //rename folders
                //1 folders/files
                filesWithSolutionName.Add(@"dxTestSolution.Module\dxTestSolution.Module.csproj");
                filesWithSolutionName.Add("dxTestSolution.Module\\");
                filesWithSolutionName.Add(@"dxTestSolution.Module.Win\dxTestSolution.Module.Win.csproj");
                filesWithSolutionName.Add("dxTestSolution.Module.Win\\");
                filesWithSolutionName.Add(@"dxTestSolution.Win\dxTestSolution.Win.csproj");
                filesWithSolutionName.Add("dxTestSolution.Win\\");
                filesWithSolutionName.Add(@"dxTestSolution.Module.Web\dxTestSolution.Module.Web.csproj");
                filesWithSolutionName.Add("dxTestSolution.Module.Web\\");
                filesWithSolutionName.Add(@"dxTestSolution.Web\dxTestSolution.Web.csproj");
                filesWithSolutionName.Add("dxTestSolution.Web\\");
                filesWithSolutionName.Add(@".vs\dxTestSolution\");
                filesWithSolutionName.Add("dxTestSolution.sln");
                //5 add security
                if(SelectedModules != null) {
                    tokens = SelectedModules.Cast<string>().ToList();
                }
            }



            foreach(var fl in filesWithSolutionName) {
                Regex rgx = new Regex(pattern);
                MatchCollection matches = rgx.Matches(fl);
                var newFl = rgx.Replace(fl, folderNumber, 1, matches.Count - 1);
                var fullFileName = finalSolutionFolderPath + "\\" + fl;
                var fullNewFileName = finalSolutionFolderPath + "\\" + newFl;
                FileMove(fullFileName, fullNewFileName);
            }

            AddAdditionalModules(tokens, sourceSolutionPath);


            //4 replace old solution name in text files
            var alltxtFiles = Directory.GetFiles(finalSolutionFolderPath, "*.*", SearchOption.AllDirectories);
            foreach(var fl in alltxtFiles) {
                var txt = File.ReadAllText(fl);
                if(txt.Contains(pattern)) {
                    txt = txt.Replace(pattern, folderNumber);
                    File.WriteAllText(fl, txt);
                }
            }
            Process.Start(gitBatchFile);
            slnPathWithProjectName = finalSolutionFolderPath + string.Format(@"{0}.sln", folderNumber);

        }

        internal void StartSolution() {
            Process.Start(slnPathWithProjectName);
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, string subFolderName, bool copySubDirs) {
            DirectoryCopy(sourceDirName + subFolderName, destDirName + subFolderName, copySubDirs);
        }
        void FileMove(string fromPath, string toPath) {
            var lstChar = fromPath[fromPath.Length - 1];
            if(lstChar == '\\') {
                Directory.Move(fromPath, toPath);
                return;
            }
            File.Move(fromPath, toPath);
        }
        void AddAdditionalModules(List<string> tokens, string solutionPath) {
            if(tokens.Count > 0) {
                var xDoc = XDocument.Load(solutionPath + "TextToReplace.txt");
                var files = xDoc.Element("Replace").Element("Files").Elements();
                var fileTokens = xDoc.Element("Replace").Element("Tokens").Elements();
                foreach(var file in files) {
                    string fileName = file.Value;
                    string filePath = finalSolutionFolderPath + string.Format(fileName, folderNumber);
                    if(!File.Exists(filePath))
                        continue;
                    string fileText = File.ReadAllText(filePath);
                    foreach(var token in fileTokens) {
                        string tokenName = token.Attribute("name").Value;
                        //   string token = item.Attribute("token").Value;
                        if(tokens.Contains(tokenName)) {
                            var tokenItems = token.Elements();
                            foreach(var item in tokenItems) {
                                string marker = item.Attribute("marker").Value;
                                //    string value = item.FirstNode != null ? item.FirstNode.ToString() : string.Empty;

                                var els = item.Elements().ToList();
                                string st = string.Empty;
                                if(els.Count > 0) {
                                    st = string.Join(Environment.NewLine, els);
                                } else {
                                    st = item.Value;
                                }
                                //var els2 = els.Select(x => x.FirstAttribute);
                                //if(els2.Count() > 0) {
                                //    var d = 3;
                                //}


                                fileText = fileText.Replace(marker, st);
                            }
                        }
                    }
                    File.WriteAllText(filePath, fileText);
                }
            }
        }
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs) {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if(!dir.Exists) {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if(!Directory.Exists(destDirName)) {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach(FileInfo file in files) {
                string temppath = System.IO.Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if(copySubDirs) {
                foreach(DirectoryInfo subdir in dirs) {
                    string temppath = System.IO.Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);

                }
            }
        }
    }
}
