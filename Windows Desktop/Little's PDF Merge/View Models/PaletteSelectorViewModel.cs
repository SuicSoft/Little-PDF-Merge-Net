/* SuicSoft 2014-2015
 * Contact : mailto:suiciwd@gmail.com
 * Web : http://suicsoft.com | http://suicsoft.github.io
 * Github : http://github.com/suicsoft/Little-PDF-Merge
 
 * Read more in LICENSE.md
 */

/* File Description
 * The view model used for the palette selector.
 */

//For palette.
using MaterialDesignColors;
//For palette
using MaterialDesignThemes.Wpf;
//For the arrays
using System.Collections.Generic;
//For the commands
using System.Windows.Input;
//For those linq stuff.
using System.Linq;
//For disk I/O.
using System.IO;
//WPF.
using System.Windows;
//Registry and dialogs.
using Microsoft.Win32;
using Microsoft.Practices.Prism.Commands;
using System;
using System.Windows.Media.Animation;
using System.Windows.Controls;
using System.Threading;
namespace SuicSoft.LittlesPDFMerge.Windows
{
    /// <summary>
    /// The view model for the palette selector.
    /// </summary>
    public class PaletteSelectorViewModel
    {
        #region Constructor
        /// <summary>
        /// Initailizes the palette selector view model.
        /// </summary>
        public PaletteSelectorViewModel()
        {
            //Set variables
            Swatches = new SwatchesProvider().Swatches.ToList();
            ToggleBaseCommand = new DelegateCommand<object>(SetIsDark);
            ResetCommand = new DelegateCommand(Reset);
            ApplyPrimaryCommand = new DelegateCommand<Swatch>(ApplyPrimary);
            ApplyAccentCommand = new DelegateCommand<Swatch>(ApplyAccent);
            SaveCommand = new DelegateCommand(Save);
        }
        public void SetIsDark(object o)
        {
            new PaletteHelper().SetLightDark((bool)o);
        }
        #endregion
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

        #region Methods
          #region Save / Reset
        /// <summary>
        /// Save the color settings
        /// </summary>
        public static void Save()
        {
            //Save accent.
            Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\SuicSoft\\LittlePDFMerge", "Accent", AccentIndex);
            //Save primary.
            Registry.SetValue("HKEY_CURRENT_USER\\SOFTWARE\\SuicSoft\\LittlePDFMerge", "Primary", PrimaryIndex);
        }
        /// <summary>
        /// Reset the color settings
        /// </summary>
        public static void Reset()
        {
            //Replace primary with default.
            ApplyPrimary(Swatches[1]);
            //Replace accent with default.
            ApplyAccent(Swatches[9]);
            //Write the defaults to the registry.
            Save();
        }
        #endregion

          #region Apply Colors
        /// <summary>
        /// Sets the primary color.
        /// </summary>
        /// <param name="swatch">The primary color to set.</param>
        public static void ApplyPrimary(Swatch swatch)
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                //Replace the color.
                new PaletteHelper().ReplacePrimaryColor(swatch);
                //Set the color index
                PrimaryIndex = Swatches.FindIndex(x => x == swatch);
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    ((MainWindow)Application.Current.MainWindow).clr.Mode = ColorZoneMode.PrimaryDark;
                    Panel.SetZIndex(((MainWindow)Application.Current.MainWindow).Ink, 1);
                    Grid.SetRow(((MainWindow)Application.Current.MainWindow).Ink, 0);
                    ((Storyboard)((MainWindow)Application.Current.MainWindow).Resources["InkSplash"]).Completed += PaletteSelectorViewModel_Completed;
                    ((Storyboard)((MainWindow)Application.Current.MainWindow).Resources["InkSplash"]).Begin();
                }));
                
            }, null);
        }

        static void PaletteSelectorViewModel_Completed(object sender, EventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).clr.Mode = ColorZoneMode.Accent;
            //Add some ink.
            Panel.SetZIndex(((MainWindow)Application.Current.MainWindow).Ink, 0);
            Grid.SetRow(((MainWindow)Application.Current.MainWindow).Ink, 1);
        }
        /// <summary>
        /// Sets the accent color.
        /// </summary>
        /// <param name="swatch">The accent color to set.</param>
        public static void ApplyAccent(Swatch swatch)
        {
            ThreadPool.QueueUserWorkItem(delegate
            {
                //Replace the color.
                new PaletteHelper().ReplaceAccentColor(swatch);
                //Set the color index
                AccentIndex = Swatches.FindIndex(x => x == swatch);
            }, null);
            
        }
        #endregion
        #endregion
    }
}
