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
using System.Windows.Media;
using System.ComponentModel;
using System.Diagnostics;
using System.Collections.ObjectModel;
namespace SuicSoft.LittlesPDFMerge.Windows
{
    /// <summary>
    /// The view model for the palette selector.
    /// </summary>
    public class PaletteSelectorViewModel : INotifyPropertyChanged
    {
        #region Constructor
        /// <summary>
        /// Initailizes the palette selector view model.
        /// </summary>
        public PaletteSelectorViewModel()
        {
            var sw = new Stopwatch();
            sw.Start();
            //Set variables using 3 threads.
            new Thread(() =>
            {
                Swatches = new SwatchesProvider().Swatches.ToList();
                ResetCommand = new DelegateCommand(Reset);
            }).Start();
            new Thread(() =>
            {
                ApplyPrimaryCommand = new DelegateCommand<Swatch>(ApplyPrimary);
                ApplyAccentCommand = new DelegateCommand<Swatch>(ApplyAccent);
                SaveCommand = new DelegateCommand(Save);
            }).Start();
            sw.Stop();
            Debug.WriteLine("Set values in " + sw.Elapsed);
            sw.Reset();
            sw.Start();
            new Thread(() =>
            {
                PrimaryIndex = (int)Registry.GetValue(MainWindow.Apppath, "Primary", 1);
                AccentIndex = (int)Registry.GetValue(MainWindow.Apppath, "Accent", 9);
                Auto = (int)Registry.GetValue(MainWindow.Apppath, "Auto", 1) == 1;
                //Switch to dark if past 5:00 pm.
                IsChecked = Auto ? DateTime.Now.TimeOfDay < new TimeSpan(7, 0, 0) /*7:00am*/ | DateTime.Now.TimeOfDay > new TimeSpan(17, 0, 0) /*5:00pm*/ ? true : false : (int)Registry.GetValue(MainWindow.Apppath, "Dark", 0) == 1 ? true : false;
            }).Start();
            sw.Stop();
            Debug.WriteLine("Loaded settings in " + sw.Elapsed);
        }
        #endregion

        #region Variables
        /// <summary>
        /// The index of the primary color
        /// </summary>
        private static int PrimaryIndex;
        /// <summary>
        /// The index if the accent color
        /// </summary>
        private static int AccentIndex;
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
        #endregion

        #region Methods
          #region Save / Reset
        /// <summary>
        /// Save the color settings
        /// </summary>
        private void Save()
        {
            var sw = new Stopwatch();
            sw.Start();
            //Save accent.
            Registry.SetValue(MainWindow.Apppath, "Accent", AccentIndex);
            //Save primary.
            Registry.SetValue(MainWindow.Apppath, "Primary", PrimaryIndex);
            //Save is auto.
            Registry.SetValue(MainWindow.Apppath, "Auto", Auto ? 1 : 0);
            //Save light dark.
            Registry.SetValue(MainWindow.Apppath, "Dark", IsChecked ? 1 : 0);
            sw.Stop();
            Debug.WriteLine("Wrote settings to registry in " + sw.Elapsed);
        }
        private static bool _ischecked;
        public bool IsChecked
        {
            get { return _ischecked; }
            set
            {
                OnPropertyChanged("IsChecked");
                new PaletteHelper().SetLightDark(value);
                _ischecked = value;
            }
        }
        /// <summary>
        /// Reset the color settings
        /// </summary>
        private static void Reset()
        {
            //Replace primary with default.
            ApplyPrimary(Swatches[1]/*Blue*/);
            //Replace accent with default.
            ApplyAccent(Swatches[9]/*Indigo*/);
            //Write the defaults to the registry.
            //Save();
        }
        #endregion
        private bool _auto;
        public bool Auto
        {
            get { return _auto; }
            set
            {
                //Switch to dark if past 5:00 pm.
                IsChecked = DateTime.Now.TimeOfDay < new TimeSpan(7, 0, 0) /*7:00am*/ | DateTime.Now.TimeOfDay > new TimeSpan(17, 0, 0) /*5:00pm*/ ? true : false;
                _auto = value;
            }
        }
          #region Apply Colors
        /// <summary>
        /// Sets the primary color.
        /// </summary>
        /// <param name="swatch">The primary color to set.</param>
        private static void ApplyPrimary(Swatch swatch)
        {
            EventHandler h = (sender, e) =>
            {
                ((ColorZone)((VisualBrush)((MainWindow)Application.Current.MainWindow).Ink.Fill).Visual).Mode = ColorZoneMode.Accent;
                //Add some ink.
                Panel.SetZIndex(((MainWindow)Application.Current.MainWindow).Ink, 0);
                Grid.SetRow(((MainWindow)Application.Current.MainWindow).Ink, 1);
            };
            //Multithreading to get a smooth ink effect
            ThreadPool.QueueUserWorkItem(delegate
            {
                //Replace the color.
                new PaletteHelper().ReplacePrimaryColor(swatch);
                //Set the color index
                PrimaryIndex = Swatches.FindIndex(x => x == swatch);
                //Start the animation
                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    ((ColorZone)((VisualBrush)((MainWindow)Application.Current.MainWindow).Ink.Fill).Visual).Mode  = ColorZoneMode.PrimaryDark;
                    Panel.SetZIndex(((MainWindow)Application.Current.MainWindow).Ink, 1);
                    Grid.SetRow(((MainWindow)Application.Current.MainWindow).Ink, 0);
                    ((Storyboard)((MainWindow)Application.Current.MainWindow).Resources["InkSplash"]).Completed += h;
                    ((Storyboard)((MainWindow)Application.Current.MainWindow).Resources["InkSplash"]).Begin();
                }));
                
            }, null);
        }
        /// <summary>
        /// Sets the accent color.
        /// </summary>
        /// <param name="swatch">The accent color to set.</param>
        private static void ApplyAccent(Swatch swatch)
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
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }
    }
}
