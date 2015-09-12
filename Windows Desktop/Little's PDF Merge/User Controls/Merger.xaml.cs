using Microsoft.Practices.Prism.Commands;
using Microsoft.Win32;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Linq;
using SuicSoft.LittlesPDFMerge.Windows;
using MahApps.Metro.Controls.Dialogs;
using System.IO;
using System.Diagnostics;
using System.Windows;
using MahApps.Metro.Controls;
namespace SuicSoft.LittlesPDFMerge.Windows
{
    /// <summary>
    /// Interaction logic for Merger.xaml
    /// </summary>
    public partial class Merger : UserControl
    {
        #region Commands
        public static ICommand MergeCommand { get; set; }
        public static ICommand AddFileCommand { get; set; }
        public static ICommand MoveUpCommand { get; set; }
        public static ICommand MoveDownCommand { get; set; }
        #endregion

        public Merger()
        {
            InitializeComponent();
            MergeCommand = new DelegateCommand(Save, CanMerge);
            #region AddFileComand
            AddFileCommand = new ActionCommand(() =>
            {
                //To get the button click animation to show. We need to open the Microsoft.Win32.OpenFileDialog in a new thread.
                new System.Threading.Thread(new System.Threading.ThreadStart(delegate()
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.DefaultExt = ".pdf";
                    openFileDialog.Filter = "Portable Document Format (*.pdf)|*.pdf|Text files (*.txt)|*.txt";
                    openFileDialog.Multiselect = true;
                    if (openFileDialog.ShowDialog() == true)
                        Parallel.For(0, openFileDialog.FileNames.Count(), i => AddInputFile(openFileDialog.FileNames[i]));
                })).Start();
            });
            #endregion
            MoveUpCommand = new ActionCommand(() => f.Items.Cast<PDFItem>().MoveUp(f.SelectedIndex));
            MoveDownCommand = new ActionCommand(() => f.Items.Cast<PDFItem>().MoveDown(f.SelectedIndex));
        }
        public void Save()
        {
            //To get the button click animation to show. We need to open the Microsoft.Win32.SaveFileDialog in a new thread.
            new System.Threading.Thread(new System.Threading.ThreadStart(async () =>
            {
                //Initailize the open file dialog and title.
                SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog() { Title = f.Items.Count > 1 ? string.Format("Merging {0} File(s)", f.Items.Count) : string.Format("Converting {0}", Path.GetFileName(((PDFItem)f.Items[0]).path)) };
                //If user clicks ok.
                if (saveFileDialog.ShowDialog() == true)
                    using (Combiner comb = new Combiner())
                    {
                        comb.Output = saveFileDialog.FileName;
                        comb.Password = f.Items.Cast<PDFItem>().Any(x => x.password != null) ? MessageDialogResult.Affirmative == await ((MetroWindow)Window.GetWindow(this)).ShowMessageAsync("Password protected pdf", "One or more of the pdfs you are merging are password protected. Do you want to protect the merged pdf with a pasword?", MessageDialogStyle.AffirmativeAndNegative, new MetroDialogSettings() { AffirmativeButtonText = "Yes", NegativeButtonText = "No" }) ? (await ((MetroWindow)Window.GetWindow(this)).ShowInputAsync("Enter the password for the merged pdf", "Password contain anything")).ToSecureString() : null : null;
                        foreach (PDFItem item in f.Items)
                            comb.AddFile(File.ReadAllBytes(item.path), null);

                    }
                if (!string.IsNullOrEmpty(saveFileDialog.FileName))
                    Process.Start(saveFileDialog.FileName);
            })).Start();
        }
        public bool CanMerge()
        {
            return f.Items.Count > 0;
        }
    }
}
