//For changing themes.
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
//For the registry
using Microsoft.Win32;
using System;
//For all the array stuff
using System.Linq;

namespace SuicSoft.LittlesPDFMerge.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        /// <summary>
        /// Initailizes the main window.
        /// </summary>
        public MainWindow()
        {
            //Load the UI.
            InitializeComponent();
            //Switch to dark if past 5:00 pm.
            PaletteSelectorViewModel.IsChecked = DateTime.Now.TimeOfDay < new TimeSpan(7, 0, 0) | DateTime.Now.TimeOfDay > new TimeSpan(17, 0, 0) ? true : false;
            //Load the color palette from the registry.
            LoadColors();
        }
        /// <summary>
        /// Loads the color values from the registry.
        /// </summary>
        private static void LoadColors()
        {
            //Load accent.
            new PaletteHelper().ReplaceAccentColor(new SwatchesProvider().Swatches.ToList()[(int)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\SuicSoft\\LittlePDFMerge", "Accent",9)]);
            //Load primary.
            new PaletteHelper().ReplacePrimaryColor(new SwatchesProvider().Swatches.ToList()[(int)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\SuicSoft\\LittlePDFMerge", "Primary", 1)]);
        }
    }
}
