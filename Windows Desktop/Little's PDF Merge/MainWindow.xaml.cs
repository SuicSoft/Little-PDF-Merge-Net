//For changing themes.
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
//For the registry
using Microsoft.Win32;
using SuicSoft.LittlesPDFMerge.PluginBase;
using System;
using System.Diagnostics;
//For all the array stuff
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SuicSoft.LittlesPDFMerge.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    //[CLSCompliant(false)]
    public partial class MainWindow
    {
        System.Collections.Generic.List<IPlugin> plugins;
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
            Stopwatch stopwatch = new Stopwatch();
            //Init code is run as parallel. This software is optimized for CPUs with 2 or more cores (not 1 core and two threads).
            ThreadPool.QueueUserWorkItem(delegate
            {
                //Start it again.
                stopwatch.Start();
                //Try loading plugins
                try { plugins = new GenericMEFPluginLoader<IPlugin>("Plugins").Plugins.ToList(); }
                //Print error message if crashes
                catch { Debug.WriteLine("Failed to init plugins"); }
                Parallel.For(0, plugins.Count, new ParallelOptions() { MaxDegreeOfParallelism = 2 }, i =>
                    plugins[i].OnLoad());
                // Stop timing
                stopwatch.Stop();
                //Print time to load plugins code.
                Debug.WriteLine("Time to load plugins code: {0}", stopwatch.Elapsed);
            });
        }
        /// <summary>
        /// Loads the color values from the registry.
        /// </summary>
        private static void LoadColors()
        {
            var clr = new SwatchesProvider().Swatches.ToList();
            new Thread(() =>
                //Load accent.
                new PaletteHelper().ReplaceAccentColor(clr[(int)Registry.GetValue(Apppath, "Accent", 9)])
            ).Start();
            new Thread(() =>
                //Load primary.
                new PaletteHelper().ReplacePrimaryColor(clr[(int)Registry.GetValue(Apppath, "Primary", 1)])
            ).Start();
        }
    }
}
