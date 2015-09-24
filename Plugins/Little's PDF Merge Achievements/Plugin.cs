using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using System.ComponentModel.Composition;
namespace SuicSoft.LittlesPDFMerge.Achievements
{
    public class Plugin : SuicSoft.LittlesPDFMerge.PluginBase.IPlugin //IPlugin
    {
        public string Name { get; set; }
        public BitmapImage icon { get; set; }
        public string Author { get; set; }
        public Version Version { get; set; }
        public void Settings()
        {

        }
        public void OnAppInit()
        {

        }
        public void OnLoad()
        {
            MessageBox.Show("Hello World");
        }
        public void OnUILoad()
        {

        }
        public void OnRemove()
        {

        }
        public void OnMerge()
        {

        }
        public void OnUp()
        {

        }
        public void OnDown()
        {

        }
    }
}
