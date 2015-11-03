/* SuicSoft 2014-2015
 * Contact : mailto:suiciwd@gmail.com
 * Web : http://suicsoft.com | http://suicsoft.github.io
 * Github : http://github.com/suicsoft/Little-PDF-Merge
 
 * Read more in LICENSE.md
 */

/* File
 * File Name : PaletteSelectorViewModel.cs
 * Language : C# 5
 * The view model used for the palette selector.
 */

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
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SuicSoft.LittlesPDFMerge.Windows
{
    public class PaletteSelectorViewModel : INotifyPropertyChanged
    {
        #region INofityPropertyChanged
            public event PropertyChangedEventHandler PropertyChanged;

            private void NotifyPropertyChanged(String info)
            {
                if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        #endregion

        #region Private Variables
            /// <summary>
            /// Internal IsAuto variable.
            /// </summary>
            private static bool isauto;
            /// <summary>
            /// Internal IsDark variable.
            /// </summary>
            private static bool isdark;
            /// <summary>
            /// Internal PrimaryIndex variable.
            /// </summary>
            private static int primaryindex = 30;
            /// <summary>
            /// Internal AccentIndex variable.
            /// </summary>
            private static int accentindex = 30;
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
            /// Sets the primary color
            /// </summary>
            public ICommand ApplyPrimaryCommand { get; set; }
            /// <summary>
            /// Sets the accent color
            /// </summary>
            public ICommand ApplyAccentCommand { get; set; }
            /// <summary>
            /// Sets dark or light
            /// </summary>
            public ICommand ToggleBaseCommand { get; set; }
        #endregion

        #region Properties
            /// <summary>
            /// The index of the primary color
            /// </summary>
            private static int PrimaryIndex
            {
                get
                {
                    return primaryindex;
                }
                set
                {
                    new Thread(() =>
                    {
                        primaryindex = value;
                        new PaletteHelper().ReplacePrimaryColor(Swatches[primaryindex]);
                    }).Start();
                }
            }
            /// <summary>
            /// The index of the accent color
            /// </summary>
            private static int AccentIndex
            {
                get
                {
                    return accentindex;
                }
                set
                {
                    
                    new Thread(() =>
                    {
                        accentindex = value;
                        new PaletteHelper().ReplaceAccentColor(Swatches[accentindex]);
                    }).Start();
                }
            }

            public bool IsAuto { get; set; }

            public bool IsDark 
            {
                get
                {
                    return isdark;
                }
                set
                {
                    isdark = value;
                    new PaletteHelper().SetLightDark(isdark);
                    NotifyPropertyChanged("IsDark");
                }
            }  
        #endregion

        #region Methods
            /// <summary>
            /// A list of all the Material Design swatches
            /// </summary>
            public static List<Swatch> Swatches { get; set; }

        #endregion

        public PaletteSelectorViewModel()
        {
            Swatches = new SwatchesProvider().Swatches.ToList();
            ApplyPrimaryCommand = new DelegateCommand<Swatch>(o => PrimaryIndex = Swatches.IndexOf(o));
            ApplyAccentCommand = new DelegateCommand<Swatch>(o => AccentIndex = Swatches.IndexOf(o));
        }

        
    }
}