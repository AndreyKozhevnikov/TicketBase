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
using System.Xml.Linq;

namespace DXTicketBase {
    public partial class MyViewModel : INotifyPropertyChanged, ISupportServices {

        static string totalCmdPath = @"C:\Program Files (x86)\totalcmd\TOTALCMD64.EXE";

        public event PropertyChangedEventHandler PropertyChanged;
        public static DXTicketsBaseEntities generalEntity;

        string parentPath;
        string dropBoxPath;
        string solvedPath;
        string solvedPathOld;
        string currentThreadFolder;
        string searchStringVM;

        MyTicket _thisTicket;
        MyTicket _selectedTicket;

        ICommand _windowLoadedCommand;
        ICommand _copyToClipBoardCommand;
        ICommand _addNewTicketCommand;
        ICommand _createAndOpenSolutionCommand;
        ICommand _saveAllCommand;
        ICommand _goToWebCommand;
        ICommand _openFolderCommand;
        ICommand _deleteFoldersCommand;
        ICommand _availableItemsChangedCommand;

        public ICommand GoToWebCommand {
            get {
                if(_goToWebCommand == null)
                    _goToWebCommand = new DelegateCommand(GoToWeb);
                return _goToWebCommand;
            }
        }
        public ICommand SaveAllCommand {
            get {
                if(_saveAllCommand == null)
                    _saveAllCommand = new DelegateCommand(SaveAll);
                return _saveAllCommand;
            }

        }
        public ICommand CreateAndOpenSolutionCommand {
            get {
                if(_createAndOpenSolutionCommand == null)
                    _createAndOpenSolutionCommand = new DelegateCommand(CreateAndOpenSolution);

                return _createAndOpenSolutionCommand;
            }
        }
        public ICommand AddNewTicketCommand {
            get {
                if(_addNewTicketCommand == null)
                    _addNewTicketCommand = new DelegateCommand(AddNewTicket);
                return _addNewTicketCommand;
            }
        }
        public ICommand WindowLoadedCommand {
            get {
                if(_windowLoadedCommand == null)
                    _windowLoadedCommand = new DelegateCommand(WindowLoaded);
                return _windowLoadedCommand;
            }
        }
        public ICommand CopyToClipBoardCommand {
            get {
                if(_copyToClipBoardCommand == null)
                    _copyToClipBoardCommand = new DelegateCommand<CopyingToClipboardEventArgs>(CopyToClipBoard);
                return _copyToClipBoardCommand;
            }
        }
        public ICommand OpenFolderCommand {
            get {
                if(_openFolderCommand == null)
                    _openFolderCommand = new DelegateCommand(OpenFolder);
                return _openFolderCommand;
            }

        }

        public ICommand DeleteFoldersCommand {
            get {
                if(_deleteFoldersCommand == null)
                    _deleteFoldersCommand = new DelegateCommand(DeleteFolders);
                return _deleteFoldersCommand;
            }

        }
        public ICommand AvailableItemsChangedCommand {
            get {
                if(_availableItemsChangedCommand == null)
                    _availableItemsChangedCommand = new DelegateCommand<EditValueChangedEventArgs>(AvailableItemsChanged);
                return _availableItemsChangedCommand;
            }

        }

        public ObservableCollection<MyTicket> ListTickets { get; set; }

        public List<String> AvailableModules { get; set; }
        public List<object> SelectedModules { get; set; }

        public MyTicket ThisTicket {
            get { return _thisTicket; }
            set {
                _thisTicket = value;
                NotifyPropertyChanged();
            }
        }
        public MyTicket SelectedTicket {
            get { return _selectedTicket; }
            set {
                _selectedTicket = value;
                NotifyPropertyChanged();
            }
        }
        public string SearchStringVM {
            get { return searchStringVM; }
            set {
                searchStringVM = value;
                if(value == null) {
                    MyManageGridControlService.MoveToLastRow();
                }
            }
        }
        IServiceContainer serviceContainer = null;
        protected IServiceContainer ServiceContainer {
            get {
                if(serviceContainer == null)
                    serviceContainer = new ServiceContainer(this);
                return serviceContainer;
            }
        }
        IServiceContainer ISupportServices.ServiceContainer { get { return ServiceContainer; } }
        IManageGridControl MyManageGridControlService { get { return ServiceContainer.GetService<IManageGridControl>(); } }

        string solutionPath = "";


    }

    public partial class MyViewModel {
        public MyViewModel() {
            ConnectToDataBase();
            CreateTicketList();
            CreateNewticket();
            //   IsWinAttached = true;
            FirstProjectType = FirstProjectEnum.Win;
            SelectedModules = new List<object>();
            SelectedModules.Add("inmemory");
            PopulateAvailableModules();
        }

        private void PopulateAvailableModules() {
            solutionPath = dropBoxPath + @"work\templates\MainSolution\dxTestSolution(Secur)\";
            var xDoc = XDocument.Load(solutionPath + "TextToReplace.txt");
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
            if(machineName == "KOZHEVNIKOV-NB") {
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

        //public bool IsWinAttached { get; set; }
        //public bool IsWebAttached { get; set; }
        public FirstProjectEnum FirstProjectType { get; set; }

        string folderPath = "";
        string folderNumber = "";
        string finalSolutionFolderPath = "";
        private void CreateAndOpenSolution() {
            string number = SelectedTicket.Number;
            if(currentThreadFolder != null && currentThreadFolder.Contains(number)) { //find folder
                folderPath = currentThreadFolder;
            } else {
                var allFiles = Directory.GetDirectories(parentPath).ToList();
                if(allFiles.Count > 0) {
                    var sel = allFiles.Where(x => x.Contains(number)).FirstOrDefault();
                    if(sel != null) {
                        folderPath = sel;
                    } else {
                        MessageBox.Show("There is no directory");
                        return;
                    }
                }
            }
            folderNumber = "dx" + number;
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

            string slnPathWithProjectName = "";
            List<string> filesWithSolutionName = new List<string>();
            string pattern;
            List<string> tokens = new List<string>();
            if(FirstProjectType == FirstProjectEnum.XPO) {
                pattern = "dxTestSolutionXPO";
                solutionPath = dropBoxPath + @"work\templates\MainSolution\ConsoleApp1\";
                DirectoryCopy(solutionPath, finalSolutionFolderPath, true);
                filesWithSolutionName.Add(@"dxTestSolutionXPO\dxTestSolutionXPO.csproj");
                filesWithSolutionName.Add(@"dxTestSolutionXPO\\");
                filesWithSolutionName.Add(@"dxTestSolutionXPO.sln");
                if(SelectedModules != null && SelectedModules.Contains("inmemory")) {
                    tokens.Add("inmemory");
                }
            } else {
                pattern = "dxTestSolution";

                DirectoryCopy(solutionPath, finalSolutionFolderPath, "dxTestSolution.Module", true);
                File.Copy(solutionPath + "dxTestSolution.sln", finalSolutionFolderPath + "dxTestSolution.sln", true);
                DirectoryCopy(solutionPath, finalSolutionFolderPath, "dxTestSolution.Module.Win", true);
                DirectoryCopy(solutionPath, finalSolutionFolderPath, "dxTestSolution.Win", true);
                DirectoryCopy(solutionPath, finalSolutionFolderPath, "dxTestSolution.Module.Web", true);
                DirectoryCopy(solutionPath, finalSolutionFolderPath, "dxTestSolution.Web", true);
                if(SelectedModules != null && SelectedModules.Contains("report")) {
                    File.Copy(solutionPath + @"Controllers\ClearReportCacheController.cs", finalSolutionFolderPath + @"dxTestSolution.Module\Controllers\ClearReportCacheController.cs");
                }
                if(SelectedModules != null && SelectedModules.Contains("office")) {
                    File.Copy(solutionPath + @"Controllers\ClearMailMergeCacheController.cs", finalSolutionFolderPath + @"dxTestSolution.Module.Win\Controllers\ClearMailMergeCacheController.cs");
                }
                switch(FirstProjectType) {
                    case FirstProjectEnum.Web:
                        DirectoryCopy(solutionPath + ".vsWeb", finalSolutionFolderPath + ".vs", true);
                        break;
                    case FirstProjectEnum.Win:
                        DirectoryCopy(solutionPath + ".vsWin", finalSolutionFolderPath + ".vs", true);
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
                Move(fullFileName, fullNewFileName);
            }

            AddAdditionalModules(tokens, solutionPath);


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
            Process.Start(slnPathWithProjectName);
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

        void Move(string fromPath, string toPath) {
            var lstChar = fromPath[fromPath.Length - 1];
            if(lstChar == '\\') {
                Directory.Move(fromPath, toPath);
                return;
            }
            File.Move(fromPath, toPath);
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
            string adr = "https://isc.devexpress.com/Thread/WorkplaceDetails/" + n;
            System.Diagnostics.Process.Start(adr);
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, string subFolderName, bool copySubDirs) {
            DirectoryCopy(sourceDirName + subFolderName, destDirName + subFolderName, copySubDirs);
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
        void OpenFolder() {
            var num = SelectedTicket.Number;
            string currentTicketPath = GetFolderInCurrentTickets(num);
            if(currentTicketPath != null) {
                OpenFolderInTotalCommander(currentTicketPath);
                MakeFolderYoung(currentTicketPath);
            }
        }

        void AvailableItemsChanged(EditValueChangedEventArgs e) {
            //todo change inmemory when a module added
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


        private void NotifyPropertyChanged([CallerMemberName]String propertyName = "") {
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

    public class ManageGridControlService : ServiceBase, IManageGridControl {
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
