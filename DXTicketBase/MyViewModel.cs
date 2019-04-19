using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;
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
        public ObservableCollection<MyTicket> ListTickets { get; set; }
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




    }

    public partial class MyViewModel {
        public MyViewModel() {
            ConnectToDataBase();
            CreateTicketList();
            CreateNewticket();
            //   IsWinAttached = true;
            FirstProjectType = FirstProjectEnum.Win;
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
        public FirstProjectEnum FirstProjectType{ get; set; }
        public bool IsSecurity { get; set; }
        public bool IsReport { get; set; }
        public bool IsXPO { get; set; }
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
            do {

                var isAlreadyExist = Directory.Exists(finalSolutionFolderPath);
                if(isAlreadyExist) {
                    if(needCreateNewOne == null)
                        needCreateNewOne = MessageBox.Show("Solution exists. Create a new one?", "Already exists", MessageBoxButton.YesNo);
                    if(needCreateNewOne.Value == MessageBoxResult.Yes) {
                        var tmpFolderNumber = folderNumber + "v" + ++tmpCount;
                        finalSolutionFolderPath = folderPath + string.Format(@"\{0}\", tmpFolderNumber);
                    } else {
                        return;
                    }
                } else {
                    canNotCreateSolution = false;
                }
            } while(canNotCreateSolution);
            Directory.CreateDirectory(finalSolutionFolderPath);
            string solutionPath = "";
            string slnPathWithProjectName = "";
            if(IsXPO) {
                solutionPath = dropBoxPath + @"work\templates\MainSolution\ConsoleApp1\";
                DirectoryCopy(solutionPath, finalSolutionFolderPath, true);
                slnPathWithProjectName = finalSolutionFolderPath + "ConsoleApp1.sln";
            } else {
                solutionPath = dropBoxPath + @"work\templates\MainSolution\dxTestSolution(Secur)\";
                //   DirectoryCopy(solutionPath, folderPath, true);

                DirectoryCopy(solutionPath, finalSolutionFolderPath, "dxTestSolution.Module", true);
                File.Copy(solutionPath + "dxTestSolution.sln", finalSolutionFolderPath + "dxTestSolution.sln", true);
                DirectoryCopy(solutionPath, finalSolutionFolderPath, "dxTestSolution.Module.Win", true);
                DirectoryCopy(solutionPath, finalSolutionFolderPath, "dxTestSolution.Win", true);
                DirectoryCopy(solutionPath, finalSolutionFolderPath, "dxTestSolution.Module.Web", true);
                DirectoryCopy(solutionPath, finalSolutionFolderPath, "dxTestSolution.Web", true);
                //add projects to sln
                string projectString = "";
                string webProjectString = "";
                string winProjectString = "";
                webProjectString = webProjectString + @"Project(""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"")=""dxTestSolution.Web"",""dxTestSolution.Web\dxTestSolution.Web.csproj"",""{82A6DBC9-B1B4-44E4-9718-55DF930CD349}""";
                webProjectString += Environment.NewLine;
                webProjectString = webProjectString + "EndProject";
                webProjectString += Environment.NewLine;
                webProjectString = webProjectString + @"Project(""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"")=""dxTestSolution.Module.Web"",""dxTestSolution.Module.Web\dxTestSolution.Module.Web.csproj"",""{0C729AAD-7626-4668-A7F1-35F7D240489D}""";
                webProjectString += Environment.NewLine;
                webProjectString = webProjectString + "EndProject";
                webProjectString += Environment.NewLine;
                winProjectString = winProjectString + @"Project(""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"")=""dxTestSolution.Win"",""dxTestSolution.Win\dxTestSolution.Win.csproj"",""{D05D93DF-312D-4D4E-B980-726871EC7833}""";
                winProjectString += Environment.NewLine;
                winProjectString = winProjectString + "EndProject";
                winProjectString += Environment.NewLine;
                winProjectString = winProjectString + @"Project(""{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}"")=""dxTestSolution.Module.Win"",""dxTestSolution.Module.Win\dxTestSolution.Module.Win.csproj"",""{7964F87D-BC5D-4C4E-8B2F-71E89739AA97}""";
                winProjectString += Environment.NewLine;
                winProjectString = winProjectString + "EndProject";
                winProjectString += Environment.NewLine;
                switch(FirstProjectType){
                    case FirstProjectEnum.Web:
                        projectString = webProjectString + winProjectString;
                        break;
                    case FirstProjectEnum.Win:
                        projectString = winProjectString + webProjectString;
                        break;
                }
                string slnPath = finalSolutionFolderPath + "dxTestSolution.sln";
                string slnText = File.ReadAllText(slnPath);
                slnText = slnText.Replace("<ReplaceString>", projectString);
                File.WriteAllText(slnPath, slnText);


                //rename folders
                //1 folders/files
                var lst = new List<string>();
                lst.Add(@"dxTestSolution.Module\dxTestSolution.Module.csproj");
                lst.Add("dxTestSolution.Module\\");
                lst.Add(@"dxTestSolution.Module.Win\dxTestSolution.Module.Win.csproj");
                lst.Add("dxTestSolution.Module.Win\\");
                lst.Add(@"dxTestSolution.Win\dxTestSolution.Win.csproj");
                lst.Add("dxTestSolution.Win\\");
                lst.Add(@"dxTestSolution.Module.Web\dxTestSolution.Module.Web.csproj");
                lst.Add("dxTestSolution.Module.Web\\");
                lst.Add(@"dxTestSolution.Web\dxTestSolution.Web.csproj");
                lst.Add("dxTestSolution.Web\\");
                lst.Add("dxTestSolution.sln");
                var pattern = "dxTestSolution";

                foreach(var fl in lst) {
                    Regex rgx = new Regex(pattern);
                    MatchCollection matches = rgx.Matches(fl);
                    var newFl = rgx.Replace(fl, folderNumber, 1, matches.Count - 1);
                    var fullFileName = finalSolutionFolderPath + "\\" + fl;
                    var fullNewFileName = finalSolutionFolderPath + "\\" + newFl;
                    Move(fullFileName, fullNewFileName);
                }

                void Move(string fromPath, string toPath) {
                    var lstChar = fromPath[fromPath.Length - 1];
                    if(lstChar == '\\') {
                        Directory.Move(fromPath, toPath);
                        return;
                    }
                    File.Move(fromPath, toPath);
                }

                //4 replace old solution name in text files
                var alltxtFiles = Directory.GetFiles(finalSolutionFolderPath, "*.*", SearchOption.AllDirectories);
                foreach(var fl in alltxtFiles) {
                    var txt = File.ReadAllText(fl);
                    if(txt.Contains(pattern)) {
                        txt = txt.Replace(pattern, folderNumber);
                        File.WriteAllText(fl, txt);
                    }
                }

                //5 add security
                List<string> tokens = new List<string>();

                if(IsSecurity) {
                    tokens.Add("security");
                }
                if(IsReport) {
                    tokens.Add("report");
                }
                if(!(IsSecurity || IsReport)) {
                    tokens.Add("inmemory");
                }
                if(tokens.Count > 0) {
                    var xDoc = XDocument.Load(solutionPath + "TextToReplace.txt");
                    var files = xDoc.Element("Replace").Element("Files").Elements();
                    var items = xDoc.Element("Replace").Element("Items").Elements();
                    foreach(var file in files) {
                        string fileName = file.Value;
                        string filePath = finalSolutionFolderPath + string.Format(fileName, folderNumber);
                        if(!File.Exists(filePath))
                            continue;
                        string fileText = File.ReadAllText(filePath);
                        foreach(var item in items) {
                            string token = item.Attribute("token").Value;
                            if(tokens.Contains(token)) {
                                string marker = item.Attribute("marker").Value;
                                string value = item.Value;
                                fileText = fileText.Replace(marker, value);
                            }
                        }
                        File.WriteAllText(filePath, fileText);
                    }
                }
                slnPathWithProjectName = finalSolutionFolderPath + string.Format(@"\{0}.sln", folderNumber);
            }
           // Process.Start(slnPathWithProjectName);

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
