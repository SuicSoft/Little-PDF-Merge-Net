using MahApps.Metro.Controls;
using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Linq;

namespace SuicSoft.LittlesPDFMerge.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            //Switch to dark if past 5:00 pm.
            if (DateTime.Now.TimeOfDay < new TimeSpan(7, 0, 0) | DateTime.Now.TimeOfDay > new TimeSpan(17, 0, 0))
                new PaletteHelper().SetLightDark(true);
        }
        protected override void OnSourceInitialized(EventArgs e)
        {
            try
            {
                new PaletteHelper().ReplaceAccentColor(new MaterialDesignColors.SwatchesProvider().Swatches.ToList()[(int)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\LittlePDFMerge", "Accent", 0)]);
                new PaletteHelper().ReplacePrimaryColor(new MaterialDesignColors.SwatchesProvider().Swatches.ToList()[(int)Registry.GetValue("HKEY_CURRENT_USER\\SOFTWARE\\LittlePDFMerge", "Primary", 0)]);
            }
            catch { }
            base.OnSourceInitialized(e);
        }
    }
}
