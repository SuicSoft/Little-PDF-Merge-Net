using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
namespace SuicSoft.LittlesPDFMerge.Windows
{
    public class PaletteSelectorViewModel
    {
        public PaletteSelectorViewModel()
        {
            Swatches = new SwatchesProvider().Swatches;
            ToggleBaseCommand = new ActionCommand(o => ApplyBase((bool)o));
            ApplyPrimaryCommand = new ActionCommand(o => ApplyPrimary((Swatch)o));
            ApplyAccentCommand = new ActionCommand(o => ApplyAccent((Swatch)o));
        }
        public ICommand SaveCommand { get; set; }

        private static void Save(Swatch swatch)
        {
            new PaletteHelper().ReplacePrimaryColor(swatch);
        }

        public ICommand ToggleBaseCommand { get; set; }

        private static void ApplyBase(bool isDark)
        {
            new PaletteHelper().SetLightDark(isDark);
        }

        public IEnumerable<Swatch> Swatches { get; set; }

        public ICommand ApplyPrimaryCommand { get; set; }

        private static void ApplyPrimary(Swatch swatch)
        {
            new PaletteHelper().ReplacePrimaryColor(swatch);
        }

        public ICommand ApplyAccentCommand { get; set; }

        private static void ApplyAccent(Swatch swatch)
        {
            new PaletteHelper().ReplaceAccentColor(swatch);
        }
    }
}
