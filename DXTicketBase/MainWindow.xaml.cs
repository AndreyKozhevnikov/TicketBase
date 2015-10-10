using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using System.Collections.ObjectModel;
using System.Windows.Markup;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DevExpress.Xpf.Editors;
using DevExpress.Xpf.Grid;
using System.Diagnostics;

using System.IO;
using System.Windows.Threading;


namespace DXTicketBase {
    public partial class MainWindow : Window, INotifyPropertyChanged {
        public MainWindow() {
            InitializeComponent();
            ConnectToDataBase();
            CreateTicketList();
            DataContext = this;
            var v = generalEntity.Tickets.Create();
            ThisTicket = new MyTicket(v);

        }

        public static DXTicketsBaseEntities generalEntity;

        public ObservableCollection<MyTicket> ListTickets { get; set; }
        private void ConnectToDataBase() {
            string machineName = System.Environment.MachineName;
            if (machineName == "KOZHEVNIKOV-W8") {
                generalEntity = new DXTicketsBaseEntities("DXTicketsBaseEntitiesWork");
                parentPath = @"D\!Tickets\";
                dropBoxPath = @"D:\Dropbox\";
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

   
        string parentPath;// = @"f:\temp\!Tickets\";
        string dropBoxPath;// = @"f:\Dropbox\";
        string solvedPath;// = @"d:\!Tickets\!Solved";
        string solvedPathOld;// = @"!Solved\!Old";
       // string ticketPath = @"d:\!Tickets\";

        MyTicket _thisTicket;

        public MyTicket ThisTicket {
            get { return _thisTicket; }
            set {
                _thisTicket = value;
                NotifyPropertyChanged();
            }
        }


        public MyTicket SelectedTicket {
            get { return _selectedItem; }
            set {
                _selectedItem = value;
                NotifyPropertyChanged();
            }
        }

        MyTicket _selectedItem;

        private void SaveAllTicketsButton_Click_2(object sender, RoutedEventArgs e) {
            var unsavedtickets = ListTickets.Where(x => x.IsSaved == false).ToList();
            foreach (var ticket in unsavedtickets) {
                ticket.IsSaved = true;
            }
            generalEntity.SaveChanges();
        }
        private void GoToWebButton_Click_1(object sender, RoutedEventArgs e) {
            string n = SelectedTicket.Number;
            string adr = "http://www.devexpress.dev/Support/Center/Question/Details/" + n;
            System.Diagnostics.Process.Start(adr);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName]String propertyName = "") {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        bool CheckIftheTicketExist(string number) {
            var currTickect = ListTickets.Where(x => x.Number.TrimEnd() == number).FirstOrDefault();
            if (currTickect != null) {
                gridControlTickets.CurrentItem = currTickect;
                TableView tv = gridControlTickets.View as TableView;
                int rH = tv.FocusedRowHandle + 6;
                rH = Math.Min(gridControlTickets.VisibleRowCount - 1, rH);
                tv.ScrollIntoView(0);

                Dispatcher.BeginInvoke((Action)(() => {
                    tv.ScrollIntoView(rH);
                }), DispatcherPriority.Input);

              
                var allFiles = Directory.GetDirectories(solvedPath).ToList();
                var allFilesOld = Directory.GetDirectories(solvedPathOld).ToList();
                allFiles = allFiles.Concat(allFilesOld).ToList();
                var targetPath = allFiles.Find(x => x.Contains(number));
                if (targetPath != null) {
                    DirectoryInfo di = new DirectoryInfo(targetPath);
                    string fullTargetName = parentPath + di.Name;
                    Directory.Move(targetPath, fullTargetName);
                }
                ThisTicket.ComplexSubject = string.Empty;
                return true;
            }
            return false;
        }

        string currentThreadFolder;
        private void Button_Click_1_AddNewTicket(object sender, RoutedEventArgs e) {

            ThisTicket.ParseComplexSubject();
            if (ThisTicket.Number == null)
                return;
            var isAlreadeExist = CheckIftheTicketExist(ThisTicket.Number);
            if (isAlreadeExist)
                return;
            string name = string.Format("{0} {1}", ThisTicket.Number, ThisTicket.Subject);
            name = name.Replace("\\", "");
            name = name.Replace("/", "");
            name = name.Replace(":", "");
            name = name.Replace("*", "");
            name = name.Replace("?", "");
            name = name.Replace("\"", "");
            name = name.Replace("<", "");
            name = name.Replace(">", "");
            name = name.Replace("|", "");
            if (name.Length > 40)
                name = name.Remove(40);


            string res = parentPath + name;
            currentThreadFolder = res;



            ThisTicket.SaveNewTicket();
            System.IO.Directory.CreateDirectory(res);
            ListTickets.Add(ThisTicket);
            SelectedTicket = ThisTicket;

            var v = generalEntity.Tickets.Create();
            ThisTicket = new MyTicket(v);
            MainWindow.generalEntity.SaveChanges();
        }

        private void ico_Loaded(object sender, RoutedEventArgs e) {
            gridControlTickets.CurrentItem = ListTickets[ListTickets.Count - 1];
        }

        private void TableView_CopyingToClipboard_1(object sender, CopyingToClipboardEventArgs e) {
            Clipboard.Clear();
            Clipboard.SetText(SelectedTicket.Number);
            e.Handled = true;
        }

        private void Button_Click_CreateSolution(object sender, RoutedEventArgs e) {
            string folderPath = "";
            string number = SelectedTicket.Number;
            if (currentThreadFolder != null && currentThreadFolder.Contains(number)) { //find folder
                folderPath = currentThreadFolder;
            }
            else {
                var allFiles = Directory.GetDirectories(parentPath).ToList();//rewrite
                if (allFiles.Count > 0) {
                    var sel = allFiles.Where(x => x.Contains(number)).FirstOrDefault();
                    if (sel != null) {
                        folderPath = sel;
                    }
                }
                if (string.IsNullOrEmpty(folderPath)) {
                    MessageBox.Show("There is no directory");
                    return;
                }

            }
            string solutionPath = dropBoxPath + @"work\templates\dxSampleGrid\";
            folderPath = folderPath + @"\dxSampleGrid";
            DirectoryCopy(solutionPath, folderPath, true);
            
            string slnPath = folderPath + @"\dxSampleGrid.sln";
            Process.Start(slnPath);

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


    }



    //public class MyViewModel {
    //    public static DXTicketsBaseEntities generalEntity;
    //    public MyViewModel() {
    //        ConnectToDataBase();
    //    }
    //    public ObservableCollection<MyTicket> ListTickets { get; set; }
    //    private static void ConnectToDataBase() {
    //        string machineName = System.Environment.MachineName;
    //        if (machineName == "KOZHEVNIKOV-W8") {

    //            generalEntity = new DXTicketsBaseEntities();
    //        }
    //        else {
    //            generalEntity = new DXTicketsBaseEntities("DXTicketsBaseEntitiesHome");
    //        }
    //    }
    //    void CreateTicketList() {
    //        ListTickets = new ObservableCollection<MyTicket>();
    //        foreach (var v in generalEntity.Tickets) {
    //            ListTickets.Add(new MyTicket(v));
    //        }
    //    }
    //}




    public partial class DXTicketsBaseEntities {
        public DXTicketsBaseEntities(string connectionName)
            : base(connectionName) {
        }
    }

}
