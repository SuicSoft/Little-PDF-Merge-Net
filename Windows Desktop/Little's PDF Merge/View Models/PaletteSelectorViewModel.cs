using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using Microsoft.Win32;
namespace SuicSoft.LittlesPDFMerge.Windows
{
    public class PaletteSelectorViewModel
    {
        public PaletteSelectorViewModel()
        {
            Swatches = new SwatchesProvider().Swatches.ToList();
            ToggleBaseCommand = new ActionCommand(o => ApplyBase((bool)o));
            ResetCommand = new ActionCommand(() => Reset());
            ApplyPrimaryCommand = new ActionCommand(o => ApplyPrimary((Swatch)o));
            ApplyAccentCommand = new ActionCommand(o => ApplyAccent((Swatch)o));
            SaveCommand = new ActionCommand(() => Save());
        }
        public ICommand SaveCommand { get; set; }
        public static int PrimaryIndex;
        public static int AccentIndex;
        private static void Save()
        {
            Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\LittlePDFMerge", "Accent", AccentIndex);
            Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\LittlePDFMerge", "Primary", PrimaryIndex);
        }
        public ICommand ResetCommand { get; set; }

        private static void Reset()
        {
            new PaletteHelper().ReplacePrimaryColor(Swatches[1]);
            new PaletteHelper().ReplaceAccentColor(Swatches[9]);
            PrimaryIndex = 1;
            AccentIndex = 9;
            Save();
        }
        public ICommand ToggleBaseCommand { get; set; }

        private static void ApplyBase(bool isDark)
        {
            new PaletteHelper().SetLightDark(isDark);
        }

        public static List<Swatch> Swatches { get; set; }

        public ICommand ApplyPrimaryCommand { get; set; }

        private static void ApplyPrimary(Swatch swatch)
        {
            new PaletteHelper().ReplacePrimaryColor(swatch);
            PrimaryIndex = Swatches.FindIndex(x => x == swatch);
        }

        public ICommand ApplyAccentCommand { get; set; }

        private static void ApplyAccent(Swatch swatch)
        {
            new PaletteHelper().ReplaceAccentColor(swatch);
            AccentIndex = Swatches.FindIndex(x => x == swatch);
        }
    }
}
