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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CefSharp;
namespace SuicSoft.LittlesPDFMerge.Windows
{
    /// <summary>
    /// Interaction logic for Merger.xaml
    /// </summary>
    public partial class Merger : UserControl
    {
        public Merger()
        {
            InitializeComponent();
            b.MouseRightButtonUp += b_MouseRightButtonUp;
            b.Address = Environment.CurrentDirectory + @"\html\loader.html";
        }

        void b_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).merger.b.GetBrowser().GetHost().ShowDevTools();
        }


        private async void UserControl_Drop(object sender, DragEventArgs e)
        {
            
            foreach (string file in (string[])e.Data.GetData(DataFormats.FileDrop))
	{
        await ((MergerViewModel)DataContext).AddInputFile(file); 
	}
            ((Storyboard)Resources["DropExit"]).Begin();

        }

        private void UserControl_DragEnter(object sender, DragEventArgs e)
        {
    
        }
    }
}
