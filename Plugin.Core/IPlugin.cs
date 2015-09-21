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
            System.Windows.Media.Imaging.BitmapImage icon { get; }
            string Author { get; }
            Version Version { get; }
            void Settings();
            void OnAppInit();
            void OnLoad();
            void OnUILoad();
            void OnRemove();
            void OnMerge();
            void OnUp();
            void OnDown();
        }
}
