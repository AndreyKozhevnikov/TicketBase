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

namespace DXTicketBase {
    public partial class MainWindow : Window {
        MyViewModel vm;
        public MainWindow() {


            InitializeComponent();
            vm = new MyViewModel();
            DataContext = vm;
            ClipboardMonitor.Start();
            ClipboardMonitor.OnClipboardChange += ClipboardMonitor_OnClipboardChange;


        }
        ~MainWindow() {
            ClipboardMonitor.Stop();
        }
        private void ClipboardMonitor_OnClipboardChange(ClipboardFormat format, object data) {
            if (format == ClipboardFormat.Text)
                vm.ThisTicket.ComplexSubject = data.ToString();
        }
    }



}
