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
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Windows.Forms;
using System.Threading;
using DevExpress.Logify.WPF;

namespace DXTicketBase {
    public partial class MainWindow : Window {
        MyViewModel vm;
        public MainWindow() {
           // LogifyAlert.Instance.ApiKey = "05D7BFD019A243CBA6E1EBC59C4E830C";
           // LogifyAlert.Instance.StartExceptionsHandling();
        

            InitializeComponent();
            vm = new MyViewModel();
            DataContext = vm;
            ClipboardMonitor.Start();
            ClipboardMonitor.OnClipboardChange += ClipboardMonitor_OnClipboardChange;

            //   MakeMajorFolderOld();
        }

        private static void MakeMajorFolderOld() {
            var drs = Directory.GetDirectories(@"C:\!Tickets\");
            foreach (string d in drs) {
                var dInfo = new DirectoryInfo(d);
                if (dInfo.Name[0] == '!') {
                    dInfo.LastWriteTime = new DateTime(2028, 12, 12);
                    var st = "sdf";
                }
            }
        }


        private void ClipboardMonitor_OnClipboardChange(ClipboardFormat format, object data) {
            if (format == ClipboardFormat.Text) {
                var st = data.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.None);
                if (st.Count() == 2) {
                    var preSubj = st[0];
                    string tmp;
                    var b = MyTicket.IsTicketSubject(preSubj, out tmp);
                    if (b)
                        vm.ThisTicket.ComplexSubject = st[0];
                }


            }
        }

        private void ico_Closed(object sender, EventArgs e) {
            ClipboardMonitor.Stop();
        }


    }



}
