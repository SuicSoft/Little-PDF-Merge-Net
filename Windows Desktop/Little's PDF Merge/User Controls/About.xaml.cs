using Squirrel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SuicSoft.LittlesPDFMerge.Windows
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : UserControl
    {
        public About()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var mgr = new UpdateManager("http://suicsoft.com/updates/lpm/"))
            {
                var info = await mgr.CheckForUpdate();
                MessageBox.Show(info.FutureReleaseEntry.Version.ToString());

                MessageBox.Show(info.CurrentlyInstalledVersion.Version.ToString());
                MessageBox.Show(info.PackageDirectory);
                foreach (ReleaseEntry item in info.ReleasesToApply)
                {
                    MessageBox.Show(item.Filename);
                }
            }
        }
    }
}
