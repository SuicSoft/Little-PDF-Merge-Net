using Plugin.Core;
using System.ComponentModel.Composition;
using System.Windows.Threading;

namespace PluginExample
{
    [Export(typeof(IPlugin))]
    public class Hello : IPlugin
    {
        #region IPlugin Members

        public string Name
        {
            get
            {
                return "Example";
            }
        }
        public void OnLoad()
        {
            try
            {
                System.Windows.MessageBox.Show("Hello World");
                
            }catch
            {
                System.Windows.MessageBox.Show("The Plugin " + Name + " Crashed!");
            }
        }

        #endregion
    }
}
