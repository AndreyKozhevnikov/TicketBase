using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Xml.Linq;

namespace DXTicketBase.Classes {
    abstract class SolutionCreator {
        string folderNumber;
        private string folderPath;
        string gitBatchFile;
        string slnPathWithProjectName;
        private string ticketNumber;
        internal string dropBoxPath;
        internal string finalSolutionFolderPath;
        internal List<object> selectedModules;

        void AddAdditionalModules(string solutionPath) {
            List<string> tokens = GetTokens();

            CreateT4File<TextTemplates.Updater>(tokens);
            CreateT4File<TextTemplates.Module>(tokens);
            CreateT4File<TextTemplates.ModuleDesigner>(tokens);
            CreateT4File<TextTemplates.Contact>(tokens);
            CreateT4File<TextTemplates.ModuleCsproj>(tokens);
            CreateT4File<TextTemplates.WinModule>(tokens);
            CreateT4File<TextTemplates.WebModule>(tokens);
            CreateT4File<TextTemplates.ModuleWinCsproj>(tokens);
            CreateT4File<TextTemplates.ModuleWebCsproj>(tokens);
            CreateT4File<TextTemplates.WinApplicationDesigner>(tokens);
            CreateT4File<TextTemplates.WinApplication>(tokens);
            CreateT4File<TextTemplates.WinCsproj>(tokens);
            CreateT4File<TextTemplates.WebCsproj>(tokens);
            CreateT4File<TextTemplates.GlobalAsax>(tokens);
            CreateT4File<TextTemplates.WebApplication>(tokens);
            CreateT4File<TextTemplates.WebConfig>(tokens);



            // var m = new TextTemplates.Module();



        }

        void CreateT4File<T>(List<String> tokens) where T : new() {
            var upd = ((T)Activator.CreateInstance(typeof(T))) as TextTemplates.BaseTemplate;
            if(tokens.Contains("validation")) {
                upd.HasValidation = true;
            }
            if(tokens.Contains("report")) {
                upd.HasReports = true;
            }
            if(tokens.Contains("office")) {
                upd.HasOffice = true;
            }
            if(tokens.Contains("inmemory")) {
                upd.UseInMemory = true;
            }
            var updResult = upd.TransformText();
            string filePath2 = finalSolutionFolderPath + string.Format(upd.FileName, folderNumber);
            File.WriteAllText(filePath2, updResult);
        }

        void CopyServiceFiles() {
            File.Copy(Path.Combine(dropBoxPath, @"work\templates\MainSolution\delbinobj.bat"), Path.Combine(finalSolutionFolderPath, "delbinobj.bat"));
            gitBatchFile = Path.Combine(finalSolutionFolderPath, "createGit.bat");
            File.Copy(Path.Combine(dropBoxPath, @"work\templates\MainSolution\createGit.bat"), gitBatchFile);
            File.Copy(Path.Combine(dropBoxPath, @"work\templates\MainSolution\.gitignoreToCopy"), Path.Combine(finalSolutionFolderPath, ".gitignore"));
        }

        void CreateTargetFolder() {
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

        }

        void FileMove(string fromPath, string toPath) {
            var lstChar = fromPath[fromPath.Length - 1];
            if(lstChar == '\\') {
                Directory.Move(fromPath, toPath);
                return;
            }
            File.Move(fromPath, toPath);
        }

        void RenameSolutionFiles() {
            List<string> filesWithSolutionName = GetFilesWithSolutionNameInName();
            foreach(var fl in filesWithSolutionName) {
                Regex rgx = new Regex(SolutionPattern);
                MatchCollection matches = rgx.Matches(fl);
                var newFl = rgx.Replace(fl, folderNumber, 1, matches.Count - 1);
                var fullFileName = finalSolutionFolderPath + "\\" + fl;
                var fullNewFileName = finalSolutionFolderPath + "\\" + newFl;
                FileMove(fullFileName, fullNewFileName);
            }
        }

        List<string> GetTextFilesWithSolutionNameInText() {
            List<string> res = new List<string>();
            res.AddRange(Directory.GetFiles(finalSolutionFolderPath, "*.cs", SearchOption.AllDirectories));
            res.AddRange(Directory.GetFiles(finalSolutionFolderPath, "*.csproj", SearchOption.AllDirectories));
            res.AddRange(Directory.GetFiles(finalSolutionFolderPath, "*.suo", SearchOption.AllDirectories));
            res.AddRange(Directory.GetFiles(finalSolutionFolderPath, "*.ide-wal", SearchOption.AllDirectories));
            res.AddRange(Directory.GetFiles(finalSolutionFolderPath, "*.ide", SearchOption.AllDirectories));
            res.AddRange(Directory.GetFiles(finalSolutionFolderPath, "*.asax", SearchOption.AllDirectories));
            res.AddRange(Directory.GetFiles(finalSolutionFolderPath, "*.config", SearchOption.AllDirectories));
            res.AddRange(Directory.GetFiles(finalSolutionFolderPath, "*.ets", SearchOption.AllDirectories));
            res.AddRange(Directory.GetFiles(finalSolutionFolderPath, "*.html", SearchOption.AllDirectories));
            res.AddRange(Directory.GetFiles(finalSolutionFolderPath, "*.sln", SearchOption.AllDirectories));
            res.AddRange(Directory.GetFiles(finalSolutionFolderPath, "*.xafml", SearchOption.AllDirectories));
            res.AddRange(Directory.GetFiles(finalSolutionFolderPath, "*.xml", SearchOption.AllDirectories));
            return res;
        }

        void ReplaceOldSolutionNameInTextFiles() {
            var alltxtFiles = GetTextFilesWithSolutionNameInText();
            foreach(var fl in alltxtFiles) {
                var txt = File.ReadAllText(fl);
                if(txt.Contains(SolutionPattern)) {
                    txt = txt.Replace(SolutionPattern, folderNumber);
                    File.WriteAllText(fl, txt);
                }
            }
        }

        internal abstract void CopySolutionFiles();

        internal void CreateSolution() {
            CreateTargetFolder();
            CopyServiceFiles();
            CopySolutionFiles();
            RenameSolutionFiles();
            AddAdditionalModules(SourceSolutionPath);
            RenameDataBaseName();
            ReplaceOldSolutionNameInTextFiles();
            Process.Start(gitBatchFile);
            slnPathWithProjectName = finalSolutionFolderPath + string.Format(@"{0}.sln", folderNumber);

        }

        void RenameDataBaseName() {
            List<string> configFiles = new List<string>();
            configFiles.AddRange(Directory.GetFiles(finalSolutionFolderPath, "app.config", SearchOption.AllDirectories));
            configFiles.AddRange(Directory.GetFiles(finalSolutionFolderPath, "web.config", SearchOption.AllDirectories));
            string dbName = GetDbName();
            foreach(string configFile in configFiles) {
                var txt = File.ReadAllText(configFile);
                if(txt.Contains(SolutionPattern)) {
                    txt = txt.Replace(SolutionPattern, dbName);
                    File.WriteAllText(configFile, txt);
                }
            }
        }
        string GetDbName() {
            var st = DateTime.Now.Day;
            var hrValue = DateTime.Now.Hour;
            var dbName = string.Format("d{0}-{1}-{2}", st, hrValue, folderNumber);
            return dbName;
        }
        internal void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs) {
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

        internal void DirectoryCopy(string sourceDirName, string destDirName, string subFolderName, bool copySubDirs) {
            DirectoryCopy(sourceDirName + subFolderName, destDirName + subFolderName, copySubDirs);
        }

        internal abstract List<string> GetFilesWithSolutionNameInName();
        internal abstract List<string> GetTokens();
        internal void SetParameters(string _ticketNumber, string _folderPath, string _dropBoxPath, List<object> _selectedModules) {
            this.ticketNumber = _ticketNumber;
            this.folderPath = _folderPath;
            this.dropBoxPath = _dropBoxPath;
            this.selectedModules = _selectedModules;
        }

        internal void StartSolution() {
            Process.Start(slnPathWithProjectName);
        }

        public abstract string SolutionPattern { get; }
        public abstract string SourceSolutionPath { get; }
    }
}
