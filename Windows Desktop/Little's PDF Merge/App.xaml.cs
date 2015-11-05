using Squirrel;
using System;
using System.Reflection;
using System.Windows;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;
using EasyHook;
using System.Collections.Generic;
using iTextSharp.text.pdf;
using System.IO.Pipes;
namespace SuicSoft.LittlesPDFMerge.Windows
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {

        }
        //Client
        static NamedPipeClientStream client;

        StreamReader reader;
        StreamWriter writer;

        public static bool Welcome = false;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            new MainWindow().Show();
            //It's safe to edit below. Don't hack our update server
            try
            {
                //Return if we are debugging.
                if (System.Diagnostics.Debugger.IsAttached) return;
                using (var mgr = new UpdateManager("http://suicsoft.com/updates/lpm/"))
                    // Note, in most of these scenarios, the app exits after this method
                    // completes!
                    SquirrelAwareApp.HandleEvents(
                      onInitialInstall: v => mgr.CreateShortcutForThisExe(),
                      onAppUpdate: v => mgr.CreateShortcutForThisExe(),
                      onAppUninstall: v => mgr.RemoveShortcutForThisExe(),
                      onFirstRun: () => Welcome = true);
            }catch
            {
                MessageBox.Show("Failed to check for updates");
            }
        }
      
      

    }
   

}
