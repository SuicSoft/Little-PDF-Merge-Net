/*
 * File Name : GenericMEFPluginLoader.cs
 * Online link : https://github.com/SuicSoft/Little-PDF-Merge/blob/master/Windows%20Desktop/Little's%20PDF%20Merge/GenericMEFPluginLoader.cs
 * Language : C#.NET (.NET 4.5)
 * Description : Loads Managed Extensibility Framework (MEF) https://msdn.microsoft.com/en-us/library/dd460648(v=vs.110).aspx from a folder.
 *               MEF Plugins are used to extend .NET 4 and higher applications.
 */
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
namespace SuicSoft.LittlesPDFMerge.Windows
{
    public class GenericMEFPluginLoader<T>
    {
        private CompositionContainer _Container;
        /// <summary>
        /// A list of all the MEF plugins installed
        /// </summary>
        [ImportMany]
        public System.Collections.Generic.IEnumerable<T> Plugins {get; set;}
        /// <summary>
        /// Initailizes the plugin loader
        /// </summary>
        /// <param name="path">The folder to load plugins from</param>
        public GenericMEFPluginLoader(string path)
        {
            DirectoryCatalog directoryCatalog = new DirectoryCatalog(path);
            //An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog(directoryCatalog);
            // Create the CompositionContainer with all parts in the catalog (links Exports and Imports)
            _Container = new CompositionContainer(catalog);
            //Fill the imports of this object
            _Container.ComposeParts(this);
        }
    }
}
