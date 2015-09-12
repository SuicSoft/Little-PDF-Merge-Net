using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using System.IO;
using System.Windows;
using Microsoft.Win32;
namespace SuicSoft.LittlesPDFMerge.Windows
{
    /// <summary>
    /// The view model for the palette selector.
    /// </summary>
    public class PaletteSelectorViewModel
    {
        #region Variables
        /// <summary>
        /// The index of the primary color
        /// </summary>
        public static int PrimaryIndex;
        /// <summary>
        /// The index if the accent color
        /// </summary>
        public static int AccentIndex;
        /// <summary>
        /// A list of all the Material Design swatches
        /// </summary>
        public static List<Swatch> Swatches { get; set; }
        #endregion

        #region Commands
        /// <summary>
        /// Save the color settings
        /// </summary>
        public ICommand SaveCommand { get; set; }
        /// <summary>
        /// Reset the color settings
        /// </summary>
        public ICommand ResetCommand { get; set; }
        /// <summary>
        /// Sets the accent color.
        /// </summary>
        public ICommand ApplyAccentCommand { get; set; }
        /// <summary>
        /// Sets the primary color
        /// </summary>
        public ICommand ApplyPrimaryCommand { get; set; }
        /// <summary>
        /// Sets light or dark
        /// </summary>
        public ICommand ToggleBaseCommand { get; set; }
        #endregion

        public PaletteSelectorViewModel()
        {
            Swatches = new SwatchesProvider().Swatches.ToList();
            ToggleBaseCommand = new ActionCommand(o => new PaletteHelper().SetLightDark((bool)o));
            ResetCommand = new ActionCommand(() => Reset());
            ApplyPrimaryCommand = new ActionCommand(o => ApplyPrimary((Swatch)o));
            ApplyAccentCommand = new ActionCommand(o => ApplyAccent((Swatch)o));
            SaveCommand = new ActionCommand(() => Save());
        }
        /// <summary>
        /// Save the color settings
        /// </summary>
        private static void Save()
        {
            //Save accent.
            Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\SuicSoft\\LittlePDFMerge", "Accent", AccentIndex);
            //Save primary.
            Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\SuicSoft\\LittlePDFMerge", "Primary", PrimaryIndex);
        }
        /// <summary>
        /// Reset the color settings
        /// </summary>
        private static void Reset()
        {
            //Replace primary with default.
            ApplyPrimary(Swatches[1]);
            //Replace accent with default.
            ApplyAccent(Swatches[9]);
            //Write the defaults to the registry.
            Save();
        }
        /// <summary>
        /// Sets the primary color.
        /// </summary>
        /// <param name="swatch">The primary color to set.</param>
        private static void ApplyPrimary(Swatch swatch)
        {
            //Replace the color.
            new PaletteHelper().ReplacePrimaryColor(swatch);
            //Set the color index
            PrimaryIndex = Swatches.FindIndex(x => x == swatch);
        }
        /// <summary>
        /// Sets the accent color.
        /// </summary>
        /// <param name="swatch">The accent color to set.</param>
        private static void ApplyAccent(Swatch swatch)
        {
            //Replace the color.
            new PaletteHelper().ReplacePrimaryColor(swatch);
            //Set the color index
            PrimaryIndex = Swatches.FindIndex(x => x == swatch);
        }
    }
}
