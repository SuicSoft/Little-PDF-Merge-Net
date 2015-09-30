using System;
using System.Threading.Tasks;
using System.Windows;
namespace PluginBase
{
    /// <summary>
    /// Use this interface to create plugins for Little's PDF Merge
    /// </summary>
    public interface IPlugin
    {
        ResourceDictionary res { get; set; }
        /// <summary>
        /// The name of the plugin
        /// </summary>
        string Name { get; }
        /// <summary>
        /// The path to the icon of the plugin
        /// </summary>
        string Icon { get; }
        /// <summary>
        /// The author of the plugin
        /// </summary>
        string Author { get; }
        /// <summary>
        /// The version of the plugin
        /// </summary>
        System.Version Version { get; }
        /// <summary>
        /// When the user opens plugin settings
        /// </summary>
        void Settings();
        /// <summary>
        /// When the application is started
        /// </summary>
        void OnAppInit();
        /// <summary>
        /// When the MainWindow constructor is executed
        /// </summary>
        void OnLoad(IntPtr hwnd);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        string AddFile(string file);
        /// <summary>
        /// When the UI is loaded
        /// </summary>
        void OnUILoad();
        /// <summary>
        /// When a pdf is removed
        /// </summary>
        void OnRemove();
        /// <summary>
        /// When merge is clicked
        /// </summary>
        void OnMerge();
        /// <summary>
        /// When up is clicked
        /// </summary>
        void OnUp();
        /// <summary>
        /// When down is clicked
        /// </summary>
        void OnDown();
        /// <summary>
        /// When the plugin is unistalled
        /// </summary>
        void OnPluginRemove();
    }
}
