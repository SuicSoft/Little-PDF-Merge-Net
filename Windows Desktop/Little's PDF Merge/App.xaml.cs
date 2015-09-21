using Squirrel;
using System.Windows;
namespace SuicSoft.LittlesPDFMerge.Windows
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static bool Welcome = false;
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                //Return if we are debugging.
                if (System.Diagnostics.Debugger.IsAttached) return;
                using (var mgr = new UpdateManager("http://suicsoft.com/updates/lpm/"))
                {
                    // Note, in most of these scenarios, the app exits after this method
                    // completes!
                    SquirrelAwareApp.HandleEvents(
                      onInitialInstall: v => mgr.CreateShortcutForThisExe(),
                      onAppUpdate: v => mgr.CreateShortcutForThisExe(),
                      onAppUninstall: v => mgr.RemoveShortcutForThisExe(),
                      onFirstRun: () => Welcome = true);
                }
            }catch
            {
                MessageBox.Show("Failed to check for updates");
            }
        }
    }
}
