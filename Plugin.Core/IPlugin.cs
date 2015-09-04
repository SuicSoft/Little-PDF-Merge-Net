using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Plugin.Core
{
        public interface IPlugin
        {
            string Name { get; }
            
            void OnLoad();
        }
}
