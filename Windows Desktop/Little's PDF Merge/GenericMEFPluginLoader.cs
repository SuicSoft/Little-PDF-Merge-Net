using System;
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
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "MEF")]
    public class GenericMEFPluginLoader<T> : System.IDisposable
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
            DirectoryCatalog directoryCatalog = null;
            AggregateCatalog catalog = null;
            try
            {
                directoryCatalog = new DirectoryCatalog(path);
                //An aggregate catalog that combines multiple catalogs
                catalog = new AggregateCatalog(directoryCatalog);
                // Create the CompositionContainer with all parts in the catalog (links Exports and Imports)
                _Container = new CompositionContainer(catalog);
                //Fill the imports of this object
                _Container.ComposeParts(this);
            }
            finally
            {
                directoryCatalog.Dispose();
                catalog.Dispose();
            }
        }

        #region IDisposable Members

        /// <summary>
        /// Internal variable which checks if Dispose has already been called
        /// </summary>
        private bool disposed;

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                //TODO: Managed cleanup code here, while managed refs still valid
                _Container.Dispose();
                _Container = null;
            }
            //TODO: Unmanaged cleanup code here

            disposed = true;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // Call the private Dispose(bool) helper and indicate 
            // that we are explicitly disposing
            this.Dispose(true);

            // Tell the garbage collector that the object doesn't require any
            // cleanup when collected since Dispose was called explicitly.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The destructor for the class.
        /// </summary>
        ~GenericMEFPluginLoader()
        {
            this.Dispose(false);
        }


        #endregion
        
    }
}
