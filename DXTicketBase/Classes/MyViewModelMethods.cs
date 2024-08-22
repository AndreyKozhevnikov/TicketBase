using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using DXTicketBase.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using DataForSolutionNameSpace;



namespace DXTicketBase {
    public enum TestEnum { test1, test2 }

    public partial class MyViewModel {
        public MyViewModel() {
            ConnectToDataBase();
            CreateTicketList();
            CreateNewticket();
            //   IsWinAttached = true;
            SolutionType = ProjectTypeEnum.Core;
            //  SelectedModules = GetDefaultSelectedModules();
            PopulateAvailableModules();
        }
        List<object> GetDefaultSelectedModules() {
            return new List<object>() { "inmemory" };
        }
        private void PopulateAvailableModules() {
            var sourceSolutionPath = dropBoxPath + @"work\templates\MainSolution\dxTestSolution(Secur)\";
            var xDoc = XDocument.Load(sourceSolutionPath + "TextToReplace.txt");
            var files = xDoc.Element("Replace").Element("Files").Elements();
            var fileTokens = xDoc.Element("Replace").Element("Tokens").Elements();

            AvailableModules = fileTokens.Select(x => x.Attribute("name").Value).ToList();
        }

        private void CreateNewticket() {
            var v = generalEntity.Tickets.Create();
            ThisTicket = new MyTicket(v);
        }


        private void ConnectToDataBase() {
            string machineName = System.Environment.MachineName;
            if(machineName == "KOZHEVNIKOV-NBX") {
                generalEntity = new DXTicketsBaseEntities("DXTicketsBaseEntitiesWork");
                parentPath = @"C:\!Tickets\";
                dropBoxPath = @"C:\Dropbox\";
            } else {
                generalEntity = new DXTicketsBaseEntities("DXTicketsBaseEntitiesHome");
                parentPath = @"F:\temp\!Tickets\";
                dropBoxPath = @"F:\Dropbox\";
            }
            solvedPath = parentPath + @"!Solved";
            solvedPathOld = parentPath + @"!Solved\!Old";

        }

        void CreateTicketList() {
            var lst = generalEntity.Tickets.Where(x => !x.IsFolderDelete).ToList();
            ListTickets = new ObservableCollection<MyTicket>();
            foreach(var v in lst) {
                ListTickets.Add(new MyTicket(v));
            }
        }
        private void WindowLoaded() {
            SelectedTicket = ListTickets[ListTickets.Count - 1];
        }
        private void CopyToClipBoard(CopyingToClipboardEventArgs e) {
            Clipboard.Clear();
            Clipboard.SetText(SelectedTicket.Number);
            e.Handled = true;
        }
        protected internal string NormalizeTitle(string st) {
            var lst = Path.GetInvalidFileNameChars().ToList();
            lst.Add(';');
            lst.Add('&');
            lst.Add('.');
            var b = st.IndexOfAny(lst.ToArray()) >= 0;
            if(b) {
                foreach(var ch in lst) {
                    st = st.Replace(new string(new char[] { ch }), "");
                }
            }
            if(st.Length > 40)
                st = st.Remove(40);
            return st;
        }
        private void AddNewTicket() {
            if(string.IsNullOrEmpty(ThisTicket.ComplexSubject))
                return;

            MyManageGridControlService.ClearFilter();

            ThisTicket.ParseComplexSubject();
            if(ThisTicket.Number == null)
                return;
            var isAlreadeExist = CheckIftheTicketExist(ThisTicket.Number);
            if(isAlreadeExist)
                return;
            string name = string.Format("{0} {1}", ThisTicket.Number, ThisTicket.Subject);
            name = NormalizeTitle(name);



            string res = parentPath + name;
            res = res.Trim();
            currentThreadFolder = res;



            ThisTicket.SaveNewTicket();
            System.IO.Directory.CreateDirectory(res);
            ListTickets.Add(ThisTicket);
            Dispatcher.CurrentDispatcher.BeginInvoke((Action)(() => {
                SelectedTicket = ThisTicket;
                CreateNewticket();
                generalEntity.SaveChanges();
            }), DispatcherPriority.Background);
            //  SelectedModules = GetDefaultSelectedModules();
        }
        List<string> GetAllDirectories() {
            var allFiles = Directory.GetDirectories(solvedPath).ToList();
            var allFilesOld = Directory.GetDirectories(solvedPathOld).ToList();
            allFiles = allFiles.Concat(allFilesOld).ToList();
            return allFiles;
        }
        bool CheckIftheTicketExist(string number) {
            var currTickect = ListTickets.Where(x => x.Number == number).FirstOrDefault();
            if(currTickect != null) {
                Dispatcher.CurrentDispatcher.BeginInvoke((Action)(() => {
                    SelectedTicket = currTickect;
                    MyManageGridControlService.Move();
                }), DispatcherPriority.Input);




                var allFiles = GetAllDirectories();
                var targetPath = allFiles.Find(x => x.Contains(number));
                if(targetPath != null) {
                    DirectoryInfo di = new DirectoryInfo(targetPath);
                    string fullTargetName = parentPath + di.Name;
                    Directory.Move(targetPath, fullTargetName);
                    MakeFolderYoung(fullTargetName);
                    OpenFolderInTotalCommander(fullTargetName);
                } else {
                    string currentTicketPath = GetFolderInCurrentTickets(number);
                    if(currentTicketPath != null) {
                        MakeFolderYoung(currentTicketPath);
                        OpenFolderInTotalCommander(currentTicketPath);
                    } else {
                        var dst = string.Format("{0}{1}", parentPath, number);
                        System.IO.Directory.CreateDirectory(dst);
                        OpenFolderInTotalCommander(dst);
                    }
                }
                ThisTicket.ComplexSubject = string.Empty;
                return true;
            }
            return false;
        }

        void OpenFolderInTotalCommander(string path) {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = totalCmdPath;
            startInfo.Arguments = string.Format("/O /T /R=\"{0}\"", path);
            Process.Start(startInfo);
        }

        private string GetFolderInCurrentTickets(string number) {
            var currentFolderList = Directory.GetDirectories(parentPath).ToList();
            string currentTicketPath = currentFolderList.Find(x => x.Contains(number));
            return currentTicketPath;
        }

        private static void MakeFolderYoung(string fullTargetName) {
            var newDirInfo = new DirectoryInfo(fullTargetName);
            try {
                newDirInfo.LastWriteTime = DateTime.Now;
            }
            catch { }
        }


        public ProjectTypeEnum SolutionType { get; set; }
        public ORMEnum ORMType { get; set; }
        private void CreateSolutionCLI() {
            if(SolutionType != ProjectTypeEnum.Core) {
                return;
            }
            DataForSolution dataSolution = CreateDataForSolution();
            if(dataSolution == null) {
                return;
            }
            CLIBuilder cLI = new CLIBuilder();
            var command = "/C " + cLI.GetCLIString(dataSolution);

            using(StreamWriter sw = File.AppendText("mylogs.log")) {
                sw.WriteLine(command);
            
            }

            var st = System.Diagnostics.Process.Start("CMD.exe", command); 
            st.WaitForExit();

            var solutionDirectory = Path.Combine(dataSolution.FolderName, dataSolution.Name);
            string mySolutionName = dataSolution.Name;

            CopyServiceClasses(solutionDirectory, mySolutionName, dataSolution);
            CopyBOClasses(solutionDirectory, mySolutionName, dataSolution, dataSolution.ORMType);
            if(dataSolution.ORMType == ORMEnum.EF) {
                AddBOToDBContext(solutionDirectory, mySolutionName);
            }
            if(dataSolution.HasWebAPISeparate) {
                AddBOToWebApi(solutionDirectory, mySolutionName);
            }
            AddUpdaterToSolution(solutionDirectory, mySolutionName);
            FixConfig(solutionDirectory, mySolutionName, dataSolution);
            CreateGit(solutionDirectory);

            OpenVSSolution(solutionDirectory, mySolutionName);

        }
        public void OpenVSSolution(string folderName, string solutionName) {
            var path= Path.Combine(folderName, solutionName)+".sln";
            System.Diagnostics.Process.Start(path);

        }

        public void CreateGit(string folderName) {
            var st = Path.Combine(folderName, @"createGit.bat");
            System.Diagnostics.Process.Start(st);
        }
        public void FixConfig(string folderName, string solutionName, DataForSolution dataSolution) {
            List<string> configFiles = new List<string>();
            string dataBaseName;
            DataBaseCreatorLib.DataBaseCreator.CreateSQLDataBaseIfNotExists(solutionName, out dataBaseName);

            var configPath = Path.Combine(folderName, solutionName + ".Blazor.Server", "appsettings.json");
            configFiles.Add(configPath);
            var configPathWin = Path.Combine(folderName, solutionName + ".Win", "app.config");
            configFiles.Add(configPathWin);
            if(dataSolution.HasWebAPISeparate) {
                var configPathWebAPI = Path.Combine(folderName, solutionName + ".WebApi", "appsettings.json");
                configFiles.Add(configPathWebAPI);
            }

            foreach(var file in configFiles) {
                string text = File.ReadAllText(file);
                string intialText = string.Format("Initial Catalog={0}", solutionName);
                string newText = string.Format("Initial Catalog={0}", dataBaseName);
                text = text.Replace(intialText, newText);
                File.WriteAllText(file, text);
            }
        }
        public void AddUpdaterToSolution(string folderName, string solutionName) {
            var updaterPath = Path.Combine(folderName, solutionName + @".Module\Module.cs");
            string text = File.ReadAllText(updaterPath);
            text = text.Replace("using DevExpress.ExpressApp;", "using DevExpress.ExpressApp;\r\nusing dxTestSolution.Module.DatabaseUpdate;");
            text = text.Replace("return new ModuleUpdater[] { updater };", "return new ModuleUpdater[] { updater, new MyUpdater(objectSpace,versionFromDB) };");
            File.WriteAllText(updaterPath, text);
        }
        public void AddBOToWebApi(string folderName, string solutionName) {
            var dbContextPah = Path.Combine(folderName, solutionName + string.Format(@".WebApi\Startup.cs", solutionName));
            string text = File.ReadAllText(dbContextPah);
            text = text.Replace("using Microsoft.OpenApi.Models;", "using Microsoft.OpenApi.Models;\r\nusing dxTestSolution.Module.BusinessObjects;");
            text = text.Replace("options.BusinessObject<YourBusinessObject>();",
              @"options.BusinessObject<YourBusinessObject>();
                options.BusinessObject<Contact>();
                options.BusinessObject<MyTask>();
");
            File.WriteAllText(dbContextPah, text);
        }
        public void AddBOToDBContext(string folderName, string solutionName) {
            var dbContextPah = Path.Combine(folderName, solutionName + string.Format(@".Module\BusinessObjects\{0}DBContext.cs", solutionName));
            string text = File.ReadAllText(dbContextPah);
            text = text.Replace("using Microsoft.EntityFrameworkCore;", "using Microsoft.EntityFrameworkCore;\r\nusing dxTestSolution.Module.BusinessObjects;");
            text = text.Replace("public DbSet<ModuleInfo> ModulesInfo { get; set; }",
                @"public DbSet<ModuleInfo> ModulesInfo { get; set; }
                  public DbSet<MyTask> MyTasks { get; set; }
                  public DbSet<Contact> Contacts { get; set; }
");
            File.WriteAllText(dbContextPah, text);
        }
        public void CopyServiceClasses(string folderName, string solutionName, DataForSolution dataSolution) {
            File.Copy(Path.Combine(sourceSolutionPath, @"delbinobj.bat"), Path.Combine(folderName, @"delbinobj.bat"));
            File.Copy(Path.Combine(sourceSolutionPath, @"delbinobjWOVS.bat"), Path.Combine(folderName, @"delbinobjWOVS.bat"));
            File.Copy(Path.Combine(sourceSolutionPath, @".gitignore"), Path.Combine(folderName, @".gitignore"));
            File.Copy(Path.Combine(sourceSolutionPath, @"createGit.bat"), Path.Combine(folderName, @"createGit.bat"));
        }
        public void CopyBOClasses(string folderName, string solutionName, DataForSolution dataSolution, ORMEnum ormType) {

            List<Tuple<String, string>> addedFiles = new List<Tuple<String, string>>();
            var modulePath = Path.Combine(folderName, solutionName + ".Module");
            var moduleBlazorCorePath = Path.Combine(folderName, solutionName + ".Blazor.Server");
            var moduleWinCorePath = Path.Combine(folderName, solutionName + ".Win");

            var modulecsProjName = Path.Combine(folderName, solutionName + ".Module", solutionName + ".Module.csproj");



            var fileNames = new List<string>();
            switch(ormType) {
                case ORMEnum.XPO:
                fileNames.Add(@"BusinessObjects\Contact.cs");
                fileNames.Add(@"BusinessObjects\MyTask.cs");
                fileNames.Add(@"BusinessObjects\CustomClass.cs");
                break;
                case ORMEnum.EF:
                fileNames.Add(@"BusinessObjects\EFBusinessClasses.cs");

                break;
            }
            foreach(string file in fileNames) {
                var filePath = Path.Combine(modulePath, file);
                File.Copy(Path.Combine(sourceSolutionPath, file), filePath);
                //  addedFiles.Add(file);
                addedFiles.Add(new Tuple<string, string>(file, modulecsProjName));
            }

            File.Copy(Path.Combine(sourceSolutionPath, @"BusinessObjects\MyUpdater.cs"), Path.Combine(folderName, solutionName + @".Module\DatabaseUpdate\MyUpdater.cs"));
            addedFiles.Add(new Tuple<string, string>(@"DatabaseUpdate\MyUpdater.cs", modulecsProjName));
            File.Copy(Path.Combine(sourceSolutionPath, @"Controllers\CustomControllers.cs"), Path.Combine(folderName, solutionName + @".Module\Controllers\CustomControllers.cs"));
            addedFiles.Add(new Tuple<string, string>(@"Controllers\CustomControllers.cs", modulecsProjName));


            if(dataSolution.Modules.Contains(ModulesEnum.Reports)) {
                File.Copy(Path.Combine(sourceSolutionPath, @"Controllers\ClearReportCacheController.cs"), Path.Combine(folderName, solutionName + @".Module\Controllers\ClearReportCacheController.cs"));
                addedFiles.Add(new Tuple<string, string>(@"Controllers\ClearReportCacheController.cs", modulecsProjName));
            }
            if(dataSolution.Type == ProjectTypeEnum.Core) {
                File.Copy(Path.Combine(sourceSolutionPath, @"Controllers\CustomControllerWin.cs"), Path.Combine(moduleWinCorePath, @"Controllers\CustomControllerWin.cs"));
                File.Copy(Path.Combine(sourceSolutionPath, @"Controllers\GridViewControllerWin.cs"), Path.Combine(moduleWinCorePath, @"Controllers\GridViewControllerWin.cs"));
                File.Copy(Path.Combine(sourceSolutionPath, @"Controllers\CustomControllerBlazor.cs"), Path.Combine(moduleBlazorCorePath, @"Controllers\CustomControllerBlazor.cs"));
                File.Copy(Path.Combine(sourceSolutionPath, @"Controllers\GridViewControllerBlazor.cs"), Path.Combine(moduleBlazorCorePath, @"Controllers\GridViewControllerBlazor.cs"));
            }
        }
        DataForSolution CreateDataForSolution() {
            var dataSolution = new DataForSolution();

            dataSolution.Type = SolutionType;
            dataSolution.ORMType = ORMType;
            dataSolution.HasSecurity = IsSecurity;
            dataSolution.HasWebAPISeparate = HasWebAPI;
            dataSolution.HasWebAPIIntegrate = HasWebAPIIntegrate;
            dataSolution.HasMultitenant = HasMultitenant;
            dataSolution.Modules = new List<ModulesEnum>();
            if(selectedModules != null) {
                dataSolution.Modules = SelectedModules.Cast<ModulesEnum>().ToList();
            }


            string folderPath = "";
            string ticketNumber = SelectedTicket.Number;
            if(currentThreadFolder != null && currentThreadFolder.Contains(ticketNumber)) { //find folder
                folderPath = currentThreadFolder;
            } else {
                var allFiles = Directory.GetDirectories(parentPath).ToList();
                if(allFiles.Count > 0) {
                    var sel = allFiles.Where(x => x.Contains(ticketNumber)).FirstOrDefault();
                    if(sel != null) {
                        folderPath = sel;
                    } else {
                        MessageBox.Show("There is no directory");
                        return null;
                    }
                }
            }
            var tmpSolutionName = "dx" + ticketNumber;
            dataSolution.FolderName = folderPath;

            var res = SolutionCreator.GetFinalFolderName(folderPath, ref tmpSolutionName, folderPath);
            if(res == null) {
                return null;
            }
            dataSolution.Name = tmpSolutionName;
            return dataSolution;
        }

        private void PrepareDataForSolution() {
            if(SolutionType == ProjectTypeEnum.XPO) {
                CreateAndOpenSolution();
                return;
            }
            DataForSolution dataSolution = CreateDataForSolution();
            if(dataSolution == null) {
                return;
            }


            string fileName = Properties.Settings.Default.SolutionDataFileName;
            XmlSerializer serializer = new XmlSerializer(typeof(DataForSolution));
            string xmlString;
            using(var sww = new StringWriter()) {
                using(XmlWriter writer = XmlWriter.Create(sww)) {
                    serializer.Serialize(writer, dataSolution);
                    xmlString = sww.ToString(); // Your XML
                }
            }
            File.WriteAllText(fileName, xmlString);
            OpenVS();


            SelectedModules = new List<object>();
            IsSecurity = false;
            HasWebAPI = false;
        }


        public void OpenVS() {
            Process.Start(@"C:\Program Files\Microsoft Visual Studio\2022\Professional\Common7\IDE\devenv.exe");
        }

        private void CreateAndOpenSolution() {
            string folderPath = "";
            string ticketNumber = SelectedTicket.Number;
            if(currentThreadFolder != null && currentThreadFolder.Contains(ticketNumber)) { //find folder
                folderPath = currentThreadFolder;
            } else {
                var allFiles = Directory.GetDirectories(parentPath).ToList();
                if(allFiles.Count > 0) {
                    var sel = allFiles.Where(x => x.Contains(ticketNumber)).FirstOrDefault();
                    if(sel != null) {
                        folderPath = sel;
                    } else {
                        MessageBox.Show("There is no directory");
                        return;
                    }
                }
            }
            SolutionCreator creator = CreateSolutionCreator();

            creator.SetParameters(ticketNumber, folderPath, dropBoxPath, SelectedModules);
            creator.CreateSolution();
            creator.StartSolution();
        }

        SolutionCreator CreateSolutionCreator() {
            switch(SolutionType) {
                case ProjectTypeEnum.XPO:
                return new XPOSolutionCreator();
                //case SolutionTypeEnum.Win:
                //    return new XAFWinSolutionCreator();
                //case SolutionTypeEnum.Web:
                //    return new XAFWebSolutionCreator();
                default:
                throw new ArgumentOutOfRangeException();
            }
        }




        private void SaveAll() {
            var unsavedtickets = ListTickets.Where(x => x.IsSaved == false).ToList();
            foreach(var ticket in unsavedtickets) {
                ticket.IsSaved = true;
            }
            generalEntity.SaveChanges();
        }
        private void GoToWeb() {
            string n = SelectedTicket.Number;
            string adr = "https://supportcenter.devexpress.com/internal/ticket/details/" + n;
            System.Diagnostics.Process.Start(adr);
        }


        void OpenFolder() {
            var num = SelectedTicket.Number;
            string currentTicketPath = GetFolderInCurrentTickets(num);
            if(currentTicketPath != null) {
                OpenFolderInTotalCommander(currentTicketPath);
                MakeFolderYoung(currentTicketPath);
            }
        }

        void SelectedModulesChanged(EditValueChangedEventArgs e) {
            var newLst = e.NewValue != null ? ((List<object>)e.NewValue) : new List<object>();
            var oldLst = e.OldValue != null ? ((List<object>)e.OldValue) : new List<object>();

            if(oldLst.Contains("inmemory") && newLst.Count > 1 && newLst.Contains("inmemory")) {
                newLst.Remove("inmemory");
                //  SelectedModules = newLst;
            }


        }

        void DeleteFolders() {
            var stDate = DateTime.Today.AddMonths(-12);
            var ticketsToDelet = ListTickets.Where(x => x.AddDate < stDate).ToList();
            var res = MessageBox.Show(string.Format("delete {0} folders?", ticketsToDelet.Count), "Delete", MessageBoxButton.YesNo);
            if(res == MessageBoxResult.Yes) {
                var allDirectories = GetAllDirectories();
                foreach(var ticket in ticketsToDelet) {
                    var tNumber = ticket.Number;
                    string st;
                    var isRealTicketNumber = MyTicket.IsTicketSubject(tNumber, out st);
                    if(isRealTicketNumber) {
                        var targetPath = allDirectories.Find(x => x.Contains(ticket.Number + " "));
                        if(targetPath != null)
                            try {
                                Directory.Delete(targetPath, true);
                            }
                            catch { }
                    }
                    ticket.IsIsFolderDeleted = true;
                }
            }
        }


        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "") {
            if(PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    public partial class DXTicketsBaseEntities {
        public DXTicketsBaseEntities(string connectionName)
            : base(connectionName) {
        }
    }

    interface IManageGridControl {
        void Move();
        void ClearFilter();
        void MoveToLastRow();
    }

    public class ManageGridControlService :ServiceBase, IManageGridControl {
        public TableView MyTableView {
            get { return (TableView)GetValue(MyTableViewProperty); }
            set { SetValue(MyTableViewProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyTableView.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyTableViewProperty =
            DependencyProperty.Register("MyTableView", typeof(TableView), typeof(ManageGridControlService), new PropertyMetadata(null));


        public void Move() {

            int rH = MyTableView.FocusedRowHandle + 6;
            rH = Math.Min(MyTableView.DataControl.VisibleRowCount - 1, rH);
            MyTableView.ScrollIntoView(0);

            Dispatcher.BeginInvoke((Action)(() => {
                MyTableView.ScrollIntoView(rH);
            }), DispatcherPriority.Input);
        }
        public void ClearFilter() {
            MyTableView.SearchString = string.Empty; //to fix
            MyTableView.Grid.FilterString = null;
        }


        public void MoveToLastRow() {
            Dispatcher.BeginInvoke((Action)(() => {
                int maxRow = MyTableView.Grid.VisibleRowCount;
                var rh = MyTableView.Grid.GetRowHandleByVisibleIndex(maxRow - 1);
                MyTableView.FocusedRowHandle = rh;
            }), DispatcherPriority.Background);
        }
    }
}
