//For changing themes.
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
//For the registry
using Microsoft.Win32;
using System;
using System.Diagnostics;
//For all the array stuff
using System.Linq;
using System.Threading;

namespace SuicSoft.LittlesPDFMerge.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public const string apppath = "HKEY_CURRENT_USER\\SOFTWARE\\SuicSoft\\LittlePDFMerge";
        /// <summary>
        /// Initailizes the main window.
        /// </summary>
        public MainWindow()
        {
            //Load the UI.
            InitializeComponent();
            var sw = new Stopwatch();
            sw.Start();
            //Load the color palette from the registry.
            LoadColors();
            sw.Stop();
            Debug.WriteLine("Loaded colors in " + sw.Elapsed);
        }
        /// <summary>
        /// Loads the color values from the registry.
        /// </summary>
        private static void LoadColors()
        {
            new Thread(() =>
            {
                //Load accent.
                new PaletteHelper().ReplaceAccentColor(new SwatchesProvider().Swatches.ToList()[(int)Registry.GetValue(apppath, "Accent", 9)]);
            }).Start();
            new Thread(() =>
            {
                //Load primary.
                new PaletteHelper().ReplacePrimaryColor(new SwatchesProvider().Swatches.ToList()[(int)Registry.GetValue(apppath, "Primary", 1)]);
            }).Start();
        }
    }
}
