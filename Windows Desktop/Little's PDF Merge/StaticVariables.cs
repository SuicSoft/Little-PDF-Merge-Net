namespace SuicSoft.LittlesPDFMerge.Windows
{
    /// <summary>
    /// Static variables used by Little's PDF Merge
    /// </summary>
    public static class StaticVariables
    {
        /// <summary>
        /// A list of all the MEF plugins installed
        /// </summary>
        public static System.Collections.Generic.List<PluginBase.IPlugin> Plugins { get; set; }
        /// <summary>
        /// If LPM is downloading updates
        /// </summary>
        public static bool HasUpdates { get; set; }
    }
}
