using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DXTicketBase {
    /// <summary>
    /// Interaction logic for AddNewTicketWnd.xaml
    /// </summary>
    public partial class AddNewTicketWnd : Window {
        public AddNewTicketWnd(double _left) {
            InitializeComponent();
            var v = MainWindow.generalEntity.Tickets.Create();
            ThisTicket = new MyTicket(v);
            IsMakeFolder = true;
            DataContext = this;
            this.Top = 522;
            this.Left = _left;
        }
        public MyTicket ThisTicket { get; set; }
        public bool IsMakeFolder { get; set; }
        //public Ticket ReturnTicket() {
        //    return ThisTicket;
        //    this.Close();
        //}

        private void Button_Click_1(object sender, RoutedEventArgs e) {

            if (IsMakeFolder) {
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
                string path = @"c:\users\kozhevnikov.andrey\Dropbox\work\!Tickets\";

                string res = path + name;
                ThisTicket.SaveNewTicket();
                System.IO.Directory.CreateDirectory(res);
            }
            this.DialogResult = true;
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) {
            int j = 3;
        }
    }
}
