using Plugin.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuicSoft.LittleSoft.LittlesPDFMerge.Windows
{
    public class MEFPluginLoader
    {
        private CompositionContainer _Container;

        [ImportMany]
        public IEnumerable<IPlugin> Plugins
        {
            get;
            set;
        }

        public MEFPluginLoader(string path)
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
