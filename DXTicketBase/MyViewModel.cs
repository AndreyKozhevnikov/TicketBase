using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;
using DevExpress.Xpf.Grid;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

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
        public ICommand GoToWebCommand {
            get {
                if (_goToWebCommand == null)
                    _goToWebCommand = new DelegateCommand(GoToWeb);
                return _goToWebCommand;
            }
        }
        public ICommand SaveAllCommand {
            get {
                if (_saveAllCommand == null)
                    _saveAllCommand = new DelegateCommand(SaveAll);
                return _saveAllCommand;
            }

        }
        public ICommand CreateAndOpenSolutionCommand {
            get {
                if (_createAndOpenSolutionCommand == null)
                    _createAndOpenSolutionCommand = new DelegateCommand(CreateAndOpenSolution);

                return _createAndOpenSolutionCommand;
            }
        }
        public ICommand AddNewTicketCommand {
            get {
                if (_addNewTicketCommand == null)
                    _addNewTicketCommand = new DelegateCommand(AddNewTicket);
                return _addNewTicketCommand;
            }
        }
        public ICommand WindowLoadedCommand {
            get {
                if (_windowLoadedCommand == null)
                    _windowLoadedCommand = new DelegateCommand(WindowLoaded);
                return _windowLoadedCommand;
            }
        }
        public ICommand CopyToClipBoardCommand {
            get {
                if (_copyToClipBoardCommand == null)
                    _copyToClipBoardCommand = new DelegateCommand<CopyingToClipboardEventArgs>(CopyToClipBoard);
                return _copyToClipBoardCommand;
            }
        }
        public ICommand OpenFolderCommand {
            get {
                if (_openFolderCommand == null)
                    _openFolderCommand = new DelegateCommand(OpenFolder);
                return _openFolderCommand;
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
                if (value == null) {
                    MyManageGridControlService.MoveToLastRow();
                }
            }
        }
        IServiceContainer serviceContainer = null;
        protected IServiceContainer ServiceContainer {
            get {
                if (serviceContainer == null)
                    serviceContainer = new ServiceContainer(this);
                return serviceContainer;
            }
        }
        IServiceContainer ISupportServices.ServiceContainer { get { return ServiceContainer; } }
        IManageGridControl MyManageGridControlService { get { return ServiceContainer.GetService<IManageGridControl>(); } }

        void OpenFolder() {
            var num = SelectedTicket.Number;
            string currentTicketPath = GetFolderInCurrentTickets(num);
            if (currentTicketPath != null) {
                Process.Start(currentTicketPath);
                MakeFolderYoung(currentTicketPath);
            }
        }
    
    }

    public partial class MyViewModel {
        public MyViewModel() {
            ConnectToDataBase();
            CreateTicketList();
            CreateNewticket();
        }

        private void CreateNewticket() {
            var v = generalEntity.Tickets.Create();
            ThisTicket = new MyTicket(v);
        }


        private void ConnectToDataBase() {
            string machineName = System.Environment.MachineName;
            if (machineName == "KOZHEVNIKOV-W10") {
                generalEntity = new DXTicketsBaseEntities("DXTicketsBaseEntitiesWork");
                parentPath = @"C:\!Tickets\";
                dropBoxPath = @"C:\Dropbox\";
            }
            else {
                generalEntity = new DXTicketsBaseEntities("DXTicketsBaseEntitiesHome");
                parentPath = @"F:\temp\!Tickets\";
                dropBoxPath = @"F:\Dropbox\";
            }
            solvedPath = parentPath + @"!Solved";
            solvedPathOld = parentPath + @"!Solved\!Old";

        }

        void CreateTicketList() {
            ListTickets = new ObservableCollection<MyTicket>();
            foreach (var v in generalEntity.Tickets) {
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
        private void AddNewTicket() {
            if (string.IsNullOrEmpty(ThisTicket.ComplexSubject))
                return;

            MyManageGridControlService.ClearFilter();

            ThisTicket.ParseComplexSubject();
            if (ThisTicket.Number == null)
                return;
            var isAlreadeExist = CheckIftheTicketExist(ThisTicket.Number);
            if (isAlreadeExist)
                return;
            string name = string.Format("{0} {1}", ThisTicket.Number, ThisTicket.Subject);
            var lst = Path.GetInvalidFileNameChars();
            var b = name.IndexOfAny(lst) >= 0;
            if (b) {
                foreach (var ch in lst) {
                    name = name.Replace(new string(new char[] { ch }), "");
                    //var ind2 = fileName.IndexOf(ch);
                    //if (ind2 >= 0) {
                    //    fileName = fileName.Remove(ind2, 1);
                    //}
                }
            }
            //name = name.Replace("\\", "");
            //name = name.Replace("/", "");
            //name = name.Replace(":", "");
            //name = name.Replace("*", "");
            //name = name.Replace("?", "");
            //name = name.Replace("\"", "");
            //name = name.Replace("<", "");
            //name = name.Replace(">", "");
            //name = name.Replace("|", "");
            if (name.Length > 40)
                name = name.Remove(40);


            string res = parentPath + name;
            res = res.Trim();
            currentThreadFolder = res;



            ThisTicket.SaveNewTicket();
            System.IO.Directory.CreateDirectory(res);
            ListTickets.Add(ThisTicket);
            SelectedTicket = ThisTicket;
            CreateNewticket();
            generalEntity.SaveChanges();
        }

        bool CheckIftheTicketExist(string number) {
            var currTickect = ListTickets.Where(x => x.Number == number).FirstOrDefault();
            if (currTickect != null) {
                SelectedTicket = currTickect;
                MyManageGridControlService.Move();

                var allFiles = Directory.GetDirectories(solvedPath).ToList();
                var allFilesOld = Directory.GetDirectories(solvedPathOld).ToList();
                allFiles = allFiles.Concat(allFilesOld).ToList();
                var targetPath = allFiles.Find(x => x.Contains(number));
                if (targetPath != null) {
                    DirectoryInfo di = new DirectoryInfo(targetPath);
                    string fullTargetName = parentPath + di.Name;
                    Directory.Move(targetPath, fullTargetName);
                    MakeFolderYoung(fullTargetName);
                    OpenFolderInTotalCommander(fullTargetName);
                }
                else {
                    string currentTicketPath = GetFolderInCurrentTickets(number);
                    if (currentTicketPath != null) {
                        MakeFolderYoung(currentTicketPath);
                        OpenFolderInTotalCommander(currentTicketPath);
                    }
                    else {
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
            startInfo.Arguments = string.Format("/O /T /R=\"{0}\"",path);
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

        private void CreateAndOpenSolution() {
            string folderPath = "";
            string number = SelectedTicket.Number;
            if (currentThreadFolder != null && currentThreadFolder.Contains(number)) { //find folder
                folderPath = currentThreadFolder;
            }
            else {
                var allFiles = Directory.GetDirectories(parentPath).ToList();
                if (allFiles.Count > 0) {
                    var sel = allFiles.Where(x => x.Contains(number)).FirstOrDefault();
                    if (sel != null) {
                        folderPath = sel;
                    }
                    else {
                        MessageBox.Show("There is no directory");
                        return;
                    }
                }
            }
            string folderNumber = number + "dx";
            string solutionPath = dropBoxPath + @"work\templates\dxSampleGrid\";
            folderPath = folderPath + string.Format(@"\{0}", folderNumber);

            var isAlreadyExist = Directory.Exists(folderPath);
            if (isAlreadyExist) {
                return;
            }
            DirectoryCopy(solutionPath, folderPath, true);
            string csProjPath = folderPath + @"\dxSampleGrid\dxSampleGrid.csproj";
            string csProjPathWithName = folderPath + string.Format(@"\dxSampleGrid\{0}.csproj\", folderNumber);
            System.IO.File.Move(csProjPath, csProjPathWithName);

            string projPath = folderPath + @"\dxSampleGrid\";
            string projPathWithName = folderPath + string.Format(@"\{0}\", folderNumber);
            var s = projPath;
            var s2 = projPathWithName;

            var b1 = Directory.Exists(s);
            var b2 = Directory.Exists(s2);
            var st = b1.ToString() + b2;
            try {
                System.IO.Directory.Move(projPath, projPathWithName);
            }
            catch {
                var er = Marshal.GetLastWin32Error();
                string st555 = er.ToString();
                Directory.Delete(folderPath);
                //    System.IO.Directory.Move(projPath, projPathWithName);



                //return;
            }

            string slnPath = folderPath + @"\dxSampleGrid.sln";
            string slnPathWithProjectName = folderPath + string.Format(@"\{0}.sln", folderNumber);
            System.IO.File.Move(slnPath, slnPathWithProjectName);

            string slnText = File.ReadAllText(slnPathWithProjectName);
            slnText = slnText.Replace("dxSampleGrid", folderNumber);
            File.WriteAllText(slnPathWithProjectName, slnText);

           

            Process.Start(slnPathWithProjectName);

        }
        private void SaveAll() {
            var unsavedtickets = ListTickets.Where(x => x.IsSaved == false).ToList();
            foreach (var ticket in unsavedtickets) {
                ticket.IsSaved = true;
            }
            generalEntity.SaveChanges();
        }
        private void GoToWeb() {
            string n = SelectedTicket.Number;
            string adr = "https://isc.devexpress.com/Thread/WorkplaceDetails/" + n;
            System.Diagnostics.Process.Start(adr);
        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs) {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists) {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName)) {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files) {
                string temppath = System.IO.Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs) {
                foreach (DirectoryInfo subdir in dirs) {
                    string temppath = System.IO.Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);

                }
            }
        }
        private void NotifyPropertyChanged([CallerMemberName]String propertyName = "") {
            if (PropertyChanged != null) {
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
