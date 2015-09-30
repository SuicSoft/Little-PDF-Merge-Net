using Squirrel;
using System;
using System.Reflection;
using System.Windows;
using System.Linq;
using System.IO;
using System.Diagnostics;
namespace SuicSoft.LittlesPDFMerge.Windows
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolve;
        }
        public static bool Welcome = false;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //WARNING. Incorrect editing of this code can result in a PC Freeze , forcing you to hold down the power button and get Bad Sectors. You have been warned
            if (e.Args.Count() > 1)
            {
                
                if (e.Args[0] == "-plugin" & File.Exists(e.Args[1]))
                {
                    MainWindow = null;
                    new GenericMEFPluginLoader<PluginBase.IPlugin>(e.Args[1]).Plugins.ToList()[0].OnLoad(new IntPtr(0));
                }
            }
            else
            {
                Process.Start(Assembly.GetExecutingAssembly().Location, @"-plugin ""C:\Users\Prince96\documents\visual studio 2013\Projects\Little's PDF Merge\Little's PDF Merge Achievements\bin\Release\LPM.Achievements.dll""");
            }
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
        private static Assembly AssemblyResolve(object sender, ResolveEventArgs args)
        {
            return AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.FullName == args.Name);
        }
    }
}
