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
using DophinMSSQLConnector;
using System.IO;


namespace DXTicketBase {
    public partial class MainWindow : Window, INotifyPropertyChanged {
        public MainWindow() {
            InitializeComponent();
            ConnectToDataBase();
            //MsSqlConnector.GetSettingsFromFile(@"C:\MSSQLSettings.ini");
            //MsSqlConnector.MsDataBase = "DXTicketsBase";
            //MsSqlConnector.Open();
         //   CreateTagsDictionary();
            CreateTicketList();
            DataContext = this;
          var v=  generalEntity.Tickets.Create();
            ThisTicket = new MyTicket(v);
           
        }

         public static DXTicketsBaseEntities generalEntity;
       
        public ObservableCollection<MyTicket> ListTickets { get; set; }
        private static void ConnectToDataBase() {
            generalEntity = new DXTicketsBaseEntities();
        }
        void CreateTicketList() {
           // DataTable table = MsSqlConnector.GetTable("select * from tickets order by AddDate");
            ListTickets = new ObservableCollection<MyTicket>();
            //for (int i = 0; i < table.Rows.Count; i++) {
            //    ListTickets.Add(new MyTicket(table.Rows[i]));
            //}
            foreach (var v in generalEntity.Tickets) {
                ListTickets.Add(new MyTicket(v));
            }
        }
        MyTicket _thisTicket;

        public MyTicket ThisTicket {
            get { return _thisTicket; }
            set { _thisTicket = value;
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

        //void CreateTicketList() {
        //    DataTable table = MsSqlConnector.GetTable("select * from tickets order by AddDate");
        //    ListTickets = new ObservableCollection<MyTicket>();
        //    for (int i = 0; i < table.Rows.Count; i++) {
        //        ListTickets.Add(new MyTicket(table.Rows[i]));
        //    }
        //}
        //void CreateTagsDictionary() {
        //    ListAllTags = new ObservableCollection<DXTicketBase.Tag>();
        //    DataTable tbl = MsSqlConnector.GetTable("select * from tags");
        //    for (int i = 0; i < tbl.Rows.Count; i++) {
        //        Tag t = new Tag(tbl.Rows[i]);
        //        ListAllTags.Add(t);
        //    }
        //}

        //private void AddTagButton_Click_1(object sender, RoutedEventArgs e) {
        //    int jf = 4;
        //    Tag tg = new Tag(textAddTag.Text);
        //    ListAllTags.Add(tg);
        //    SelectedTicket.AddTag(tg);
        //    textAddTag.Clear();
        //}
        //private void AllTagsListBoxEdit_MouseDoubleClick_1(object sender, MouseButtonEventArgs e) {
        //    if (SelectedTicket == null) return;
        //    Tag tg = (sender as ListBoxEdit).SelectedItem as Tag;
        //    SelectedTicket.AddTag(tg);

        //}
        private void SaveAllTicketsButton_Click_2(object sender, RoutedEventArgs e) {
            //foreach (MyTicket t in ListTickets)
            //    t.Save();
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
            var listNum = generalEntity.Tickets.Select(x => x.TicketNo).ToList();
            if (listNum.Contains(number)) {
                string solvedPath = @"d:\!Tickets\!Solved";
                string solvedPathOld = @"d:\!Tickets\!Solved\!Old";
                string ticketPath = @"d:\!Tickets\";
                var allFiles = Directory.GetDirectories(solvedPath).ToList();
                var allFilesOld = Directory.GetDirectories(solvedPathOld).ToList();
                allFiles = allFiles.Concat(allFilesOld).ToList();
                var targetPath = allFiles.Find(x => x.Contains(number));
                if (targetPath != null) {
                    DirectoryInfo di = new DirectoryInfo(targetPath);
                    string fullTargetName = ticketPath + di.Name;
                    Directory.Move(targetPath, fullTargetName);
                }
                ThisTicket.ComplexSubject = string.Empty;
                return true;
            }
            return false;   
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) {
            //AddNewTicketWnd AddNWnd = new AddNewTicketWnd(this.Left);
            //Ticket t = AddNWnd.ThisTicket;
            //bool? res = AddNWnd.ShowDialog();
            //if (res==true) {
            //    ListTickets.Add(t);
            //    SelectedTicket = t;
            //}
            
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
            string path = @"d:\!Tickets\";

            string res = path + name;

          


            ThisTicket.SaveNewTicket();
            System.IO.Directory.CreateDirectory(res);
            ListTickets.Add(ThisTicket);
            SelectedTicket = ThisTicket;

          var v=  generalEntity.Tickets.Create();
            ThisTicket = new MyTicket(v);
            MainWindow.generalEntity.SaveChanges();
        }

        private void ico_Loaded(object sender, RoutedEventArgs e) {
            gridControlTickets.CurrentItem = ListTickets[ListTickets.Count - 1];
        }

        private void TableView_CopyingToClipboard_1(object sender, CopyingToClipboardEventArgs e) {
            Debug.Print("co");
            Clipboard.Clear();
            
            Clipboard.SetText(SelectedTicket.Number);
            e.Handled = true;
        }


    }

    //public class IsSavedToColorConverter : MarkupExtension, IValueConverter {
    //    public IsSavedToColorConverter() { }
    //    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
    //        Ticket tick = value as Ticket;
    //        if (tick.IsSaved == false)
    //            return new SolidColorBrush(Colors.PaleTurquoise);
    //        if (tick.IsConsider)
    //            return new SolidColorBrush(Colors.PaleGreen);
    //        return null;
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
    //        throw new NotImplementedException();
    //    }

    //    public override object ProvideValue(IServiceProvider serviceProvider) {
    //        return this;
    //    }
    //}

    public class MyViewModel {
        public static DXTicketsBaseEntities generalEntity;
        public MyViewModel() {
            ConnectToDataBase();
        }
        public ObservableCollection<MyTicket> ListTickets { get; set; }
        private static void ConnectToDataBase() {
            generalEntity = new DXTicketsBaseEntities();
        }
        void CreateTicketList() {
            DataTable table = MsSqlConnector.GetTable("select * from tickets order by AddDate");
            ListTickets = new ObservableCollection<MyTicket>();
            //for (int i = 0; i < table.Rows.Count; i++) {
            //    ListTickets.Add(new MyTicket(table.Rows[i]));
            //}
            foreach (var v in generalEntity.Tickets) {
                ListTickets.Add(new MyTicket(v));
            }
        }
    }

    public class IsSavedToColorConverter : MarkupExtension, IMultiValueConverter {
        public IsSavedToColorConverter() { }
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            MyTicket tick = values[0] as MyTicket;
            if (tick == null) return null;
            if (tick.IsSaved == false)
                return new SolidColorBrush(Colors.PaleTurquoise);
            //if (tick.IsConsider)
            //    return new SolidColorBrush(Colors.PaleGreen);
            if (tick.IsToDelete)
                return new SolidColorBrush(Colors.PaleVioletRed);
            return null;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture) {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider) {
            return this;
        }
    }


    public partial class DXTicketsBaseEntities {
        public DXTicketsBaseEntities(string connectionName)
            : base(connectionName) {
        }
    }

}
