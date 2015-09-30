using CefSharp;
using CefSharp.WinForms;
//For changing themes.
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
//For the registry
using Microsoft.Win32;
using PluginBase;
using Squirrel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
//For all the array stuff
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;

namespace SuicSoft.LittlesPDFMerge.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [CLSCompliant(false)]
    public partial class MainWindow
    {
        public bool HasUpdates { get; set; }
        /// <summary>
        /// The path used for writing to the windows registry.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Apppath")] //Ignore bad naming
        public const string Apppath = "HKEY_CURRENT_USER\\SOFTWARE\\SuicSoft\\LittlePDFMerge"; //This path is used for registry writing.
        /// <summary>
        /// Initailizes the main window.
        /// </summary>
        public MainWindow()
        {
            //Start the plugin server
            //StartServer();
            //Start the plugin Process
            var proc =Process.Start(@"C:\Users\Prince96\Documents\visual studio 2013\Projects\Little's PDF Merge\PluginProcess\bin\Debug\PluginProcess.exe", @"""C:\Users\Prince96\Documents\visual studio 2013\Projects\Little's PDF Merge\LPM.Achievements.dll""");
            
            //Load the UI.
            InitializeComponent();
            this.DataContext = this;
            //ChromiumWebBrowser myBrowser = new ChromiumWebBrowser(@"C:\Users\Prince96\Pictures\htmlsnow.html");
            //FormsHost.Child = myBrowser;
            SendMessageToWindowAsync(FindWindowByCaption(IntPtr.Zero,"Form1"),"OnLoad");
            try
            {
                //Return if we are debugging.
                if (System.Diagnostics.Debugger.IsAttached) return;
                UpdateInfo info = null;
                using (var mgr = new UpdateManager("http://suicsoft.com/updates/lpm/"))
                    info = mgr.CheckForUpdate().Result;
                HasUpdates = info.FutureReleaseEntry.Version > info.CurrentlyInstalledVersion.Version;
            }
            catch
            {
                MessageBox.Show("Failed to check for updates");
            }
            
        }
        #region PInvoke
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, ref COPYDATASTRUCT lParam);
        // Find window by Caption only. Note you must pass IntPtr.Zero as the first parameter.
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);
        #endregion

        #region PInvoke Structs
        public struct COPYDATASTRUCT
        {
            /// <summary>
            /// The length of lpData + 1.
            /// </summary>
            public int cbData;
            public IntPtr dwData;
            /// <summary>
            /// The string message to send.
            /// </summary>
            [MarshalAs(UnmanagedType.LPStr)]
            public string lpData;
        }
        #endregion

        #region PInvoke Constants
        /// <summary>
        /// WM-COPYDATA
        /// </summary>
        const int WM_COPYDATA = 0x004A;
        #endregion
        public static void SendMessageToWindow(IntPtr hwnd, string message)
        {
            SendMessageToWindowAsync(hwnd, message).RunSynchronously();
        }
        /// <summary>
        /// Sends a message to a window
        /// </summary>
        /// <param name="hwnd">The target window handle</param>
        /// <param name="message">The message</param>
        /// <returns>The return code of SendMessage(user32.dll)</returns>
        public static async Task<IntPtr> SendMessageToWindowAsync(IntPtr hwnd, string message)
        {
            //Copy data structure.
            var cds = new COPYDATASTRUCT
            {
                dwData = new IntPtr(message.Length * sizeof(char)),
                cbData = message.Length * sizeof(char),
                lpData = message
            };
            //Send message and return
            return SendMessage(hwnd, WM_COPYDATA, IntPtr.Zero, ref cds);
        }
        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Process.GetProcesses().Where(x => x.ProcessName.Contains("PluginP")).ToList().ForEach(x => x.Kill());
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //writer.WriteLine("OnLoad " + new WindowInteropHelper(this).Handle.ToString());
        }

    }
}