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
        private static void ConnectToDataBase() {
            generalEntity = new DXTicketsBaseEntities();
        }
        void CreateTicketList() {
            ListTickets = new ObservableCollection<MyTicket>();
            foreach (var v in generalEntity.Tickets) {
                ListTickets.Add(new MyTicket(v));
            }
        }
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
            var listNum = generalEntity.Tickets.Select(x =>x.TicketNo.TrimEnd()).ToList();
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
            string path = @"d:\!Tickets\";

            string res = path + name;




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
            Debug.Print("co");
            Clipboard.Clear();

            Clipboard.SetText(SelectedTicket.Number);
            e.Handled = true;
        }


    }



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
            ListTickets = new ObservableCollection<MyTicket>();
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
            if (tick == null)
                return null;
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
