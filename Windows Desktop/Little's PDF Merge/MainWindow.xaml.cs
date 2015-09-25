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
using System.Windows;

namespace SuicSoft.LittlesPDFMerge.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [CLSCompliant(false)]
    public partial class MainWindow
    {
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
            //Load the MEF Plugins
            using (var loader = new GenericMEFPluginLoader<IPlugin>("Plugins"))
                StaticVariables.Plugins = loader.Plugins.ToList();
            //Execute OnLoad.
            StaticVariables.Plugins.ForEach(x => x.OnLoad()); //Execute OnLoad() on all the plugins
            //Add handler for load event
            Loaded += (sender, e) =>  /*Execute OnUILoad() on all the plugins*/ StaticVariables.Plugins.ForEach(x => { x.OnUILoad(); Resources.MergedDictionaries.Add(x.res); });

        }

    }
}