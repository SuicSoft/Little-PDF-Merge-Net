using Squirrel;
using System.Windows;
namespace SuicSoft.LittlesPDFMerge.Windows
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static bool ShowTheWelcomeWizard;
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached) return;
            using (var mgr = new UpdateManager("http://suicsoft.com/updates/lpm/"))
            {
                // Note, in most of these scenarios, the app exits after this method
                // completes!
                SquirrelAwareApp.HandleEvents(
                  onInitialInstall: v => mgr.CreateShortcutForThisExe(),
                  onAppUpdate: v => mgr.CreateShortcutForThisExe(),
                  onAppUninstall: v => mgr.RemoveShortcutForThisExe(),
                  onFirstRun: () => ShowTheWelcomeWizard = true);
            }
        }
    }
}
