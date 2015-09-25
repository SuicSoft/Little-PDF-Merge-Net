using PluginBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Achievements
{
    [Export(typeof(IPlugin))]
    public class Achievements : IPlugin
    {
        public Achievements()
        {
            res = new ResourceDictionary();
            // Create a LinearGradientBrush and use it to
            // paint the rectangle.
            LinearGradientBrush myBrush = new LinearGradientBrush();
            myBrush.GradientStops.Add(new GradientStop(Colors.Gold, 0.0));
            myBrush.GradientStops.Add(new GradientStop(Colors.LightYellow, 1.0));
            LinearGradientBrush myBrush2 = new LinearGradientBrush();
            myBrush2.GradientStops.Add(new GradientStop(Colors.DarkGoldenrod, 0.0));
            myBrush2.GradientStops.Add(new GradientStop(Colors.LightYellow, 1.0));
            res.Add("PrimaryHueMidBrush", myBrush);
            res.Add("WindowTitleColorBrush", Brushes.DarkGoldenrod);
            res.Add("SecondaryAccentBrush", myBrush2);
        }
        public ResourceDictionary res { get; set; }
        /// <summary>
        /// The name of the plugin
        /// </summary>
        public string Name { get { return "Little's PDF Merge Achievements"; } }
        /// <summary>
        /// The path to the icon of the plugin
        /// </summary>
        public string Icon { get { return ""; } }
        /// <summary>
        /// The author of the plugin
        /// </summary>
        public string Author { get { return "SuicSoft"; } }
        /// <summary>
        /// The version of the plugin
        /// </summary>
        public System.Version Version { get { return new Version(0, 0, 5); } }
        /// <summary>
        /// When the user opens plugin settings
        /// </summary>
        public void Settings()
        {

        }
        /// <summary>
        /// When the application is started
        /// </summary>
        public void OnAppInit()
        {

        }
        /// <summary>
        /// When the MainWindow constructor is executed
        /// </summary>
        public void OnLoad()
        {
            new Thread(() => System.Windows.MessageBox.Show("Hello World. Hi novice")).Start();
        }
        /// <summary>
        /// When the UI is loaded
        /// </summary>
        public void OnUILoad()
        {

        }
        /// <summary>
        /// When a pdf is removed
        /// </summary>
        public void OnRemove()
        {

        }
        /// <summary>
        /// When merge is clicked
        /// </summary>
        public void OnMerge()
        {

        }
        /// <summary>
        /// When up is clicked
        /// </summary>
        public void OnUp()
        {

        }
        /// <summary>
        /// When down is clicked
        /// </summary>
        public void OnDown()
        {

        }
        /// <summary>
        /// When the plugin is unistalled
        /// </summary>
        public void OnPluginRemove()
        {

        }
    }
}
