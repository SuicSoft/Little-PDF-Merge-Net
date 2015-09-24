using PluginBase;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Achievements
{
    [Export(typeof(IPlugin))]
    public class Achievements : IPlugin
    {
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
            System.Windows.MessageBox.Show("Hello World. Hi novice");
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
