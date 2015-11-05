using CefSharp;
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
            //Load the UI.
            InitializeComponent();
            this.DataContext = this;
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
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            HwndSource source = PresentationSource.FromVisual(this) as HwndSource;
            source.AddHook(WndProc);
        }

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            // Handle messages...
            switch (msg)
            {
                case NativeMethods.WM_COPYDATA:
                    NativeMethods.CopyDataStruct st = (NativeMethods.CopyDataStruct)Marshal.PtrToStructure(lParam, typeof(NativeMethods.CopyDataStruct));
                    string strData = Marshal.PtrToStringUni(st.lpData);
                    strData = strData.Remove(strData.Length - 1);
                    MessageBox.Show(strData);
                    OutOfProcessHelper.procdata = strData;

                    break;
            }
            return IntPtr.Zero;
        }

    }
}