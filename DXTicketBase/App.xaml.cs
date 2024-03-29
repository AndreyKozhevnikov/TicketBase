﻿using DevExpress.Xpf.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Threading;

namespace DXTicketBase {
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application {
        public App() {
            //var sw = new StreamWriter("test22.txt");
            //sw.WriteLine("star1");
            //sw.Close();
            ApplicationThemeHelper.UseLegacyDefaultTheme = true;
        }
        protected override void OnStartup(StartupEventArgs e) {
            try {
                AssemblyResolverDll.AsseblyResolver.Attach("Dll2226");
            }catch (Exception ex) {
                var sw = new StreamWriter("test.txt");
                sw.WriteLine(ex.Message);
                sw.Write(ex.StackTrace);
                sw.Close();
            }
            var pLst = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
            if (pLst.Length > 1) {
                var p = pLst[0];
                Dispatcher.BeginInvoke((Action)(() => {
                    SetForegroundWindow(p.MainWindowHandle);
                    Environment.Exit(0);
                }), DispatcherPriority.Background);


            }
            else {
                base.OnStartup(e);
                new MainWindow().Show();
            }
        }
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
    }
}
