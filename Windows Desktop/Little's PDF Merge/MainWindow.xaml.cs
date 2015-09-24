//For changing themes.
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
//For the registry
using Microsoft.Win32;
using PluginBase;
using System;
using System.Collections.Generic;
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
    [CLSCompliant(false)]
    public partial class MainWindow
    {
        List<IPlugin> plugins;
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
            
        }
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            new GenericMEFPluginLoader<IPlugin>("Plugins").Plugins.ToList().ForEach(x => x.OnLoad());
        }

        /// <summary>
        /// Loads the color values from the registry.
        /// </summary>
        private static void LoadColors()
        {
            //Color swatches.
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
