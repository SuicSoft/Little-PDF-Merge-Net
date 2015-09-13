using iTextSharp.text.pdf;
using MahApps.Metro.Controls.Dialogs;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using MahApps.Metro.Controls;
using System.Windows.Data;
using System.ComponentModel;
namespace SuicSoft.LittlesPDFMerge.Windows
{
    class MergerViewModel
    {   
        #region Commands
        public static DelegateCommand MergeCommand { get; set; }
        public static ICommand AddFileCommand { get; set; }
        public static DelegateCommand MoveUpCommand { get; set; }
        public static DelegateCommand MoveDownCommand { get; set; }
        public static DelegateCommand RemoveCommand { get; set; }
        #endregion
        public MergerViewModel()
        {
            Files = new List<PDFItem>();
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
                    {
                        Parallel.For(0, openFileDialog.FileNames.Count(), i => AddInputFile(openFileDialog.FileNames[i]));
                    }
                })) { Name = "Open file dialog thread." }.Start();
            });
            #endregion
            MoveUpCommand = new DelegateCommand(MoveUp, CanMove);
            MoveDownCommand = new DelegateCommand(MoveDown, CanMove);
            RemoveCommand = new DelegateCommand(Remove, CanMerge);
        }
        public void MoveUp()
        {
            Files.MoveUp(SelectedIndex);
            Application.Current.Dispatcher.Invoke(new Action(() => ((MainWindow)Application.Current.MainWindow).merger.f.Items.Refresh()));
        }
        public void MoveDown()
        {
            Files.MoveDown(SelectedIndex);
            Application.Current.Dispatcher.Invoke(new Action(() => ((MainWindow)Application.Current.MainWindow).merger.f.Items.Refresh()));
        }
        public void Remove()
        {
            Files.RemoveAt(SelectedIndex); 
            RemoveCommand.RaiseCanExecuteChanged();
            Application.Current.Dispatcher.Invoke(new Action(() => ((MainWindow)Application.Current.MainWindow).merger.f.Items.Refresh()));
        }
        public bool CanMerge()
        {
            return Files.Count > 0;
        }
        public bool CanMove()
        {
            return Files.Count > 1;
        }
        public int SelectedIndex { get; set; }
        /// <summary>
        /// Shows a password box for a pdf
        /// </summary>
        /// <param name="file">The path of the pdf</param>
        private async void ShowPasswordBox(string file)
        {
            //Show the user the password dialog.
            string result = await ((MetroWindow)Application.Current.MainWindow).ShowInputAsync("PDF not allowed", "Enter the password for " + Path.GetFileName(file) + " to open the file. Enter the password 'hack' to crack the password", new LoginDialogSettings { UsernameWatermark = "Password", PasswordWatermark = "Enter Password Again", AffirmativeButtonText = "Ok", ColorScheme = MetroDialogColorScheme.Accented });
            if (!String.IsNullOrWhiteSpace(result))
            {
                try
                {
                    //Use iTextSharp.text.pdf.PdfReader to open the pdf.
                    new PdfReader(file, System.Text.Encoding.Default.GetBytes(result)).Dispose();
                    //Add the file to the listbox as a secure string. Won't reach here if password is wrong.
                    Files.Add(new PDFItem(file, null));
                }
                catch
                {
                    //If it isn't. Ask for the password again and return
                    ShowPasswordBox(file);
                }

                //Get GCHandle
                GCHandle gchandle = GCHandle.Alloc(result, GCHandleType.Pinned);
                //Clear the object with junk.
                //ClearIntPtr(gchandle.AddrOfPinnedObject(), result.Length * 2 /* x2 because of unicode.*/);
                //Free GCHandle
                gchandle.Free();
                MessageBox.Show(result);
            }
        }
        /// <summary>
        /// Add a input file.
        /// </summary>
        /// <param name="file">The path of the file</param>
        private async void AddInputFile(string file)
        {
            switch (Combiner.TestSourceFile(File.ReadAllBytes(file)))
            {
                //File is corrupt pdf.
                case Combiner.SourceTestResult.Unreadable:
                    //Tell the user the pdf is corrupt.
                    ((MetroWindow)Application.Current.MainWindow).Dispatcher.Invoke(new Action(() => ((MetroWindow)Application.Current.MainWindow).ShowMessageAsync("The file " + Path.GetFileName(file) + " could not be opened as a PDF or image", "Some thing went wrong when opening " + Path.GetFileName(file))));
                    break;
                //File is a protected pdf.
                case Combiner.SourceTestResult.Protected:
                    PdfReader.unethicalreading = false;
                    try
                    {
                        using (PdfReader reader = new PdfReader(file))
                            if (!reader.IsOpenedWithFullPermissions)
                                ((MetroWindow)Application.Current.MainWindow).Dispatcher.Invoke(new Action(async () =>
                                {
                                    if (MessageDialogResult.Affirmative == await ((MetroWindow)Application.Current.MainWindow).DonNotShowAgainDialog("The file " + " is a protected file", "Opening protected files may not be allowed by the pdf author", "Lawyer"))
                                        //That dog wants to open protected files.
                                        PdfReader.unethicalreading = true;
                                    else
                                        //Exit the method
                                        return;
                                }));
                    }
                    catch
                    {
                        ((MetroWindow)Application.Current.MainWindow).Dispatcher.Invoke(new Action(() => ShowPasswordBox(file)));
                        return;
                    }
                    break;
                //File is a valid pdf.
                case Combiner.SourceTestResult.Ok:
                    //Add the pdf to the ListBox.
                    Files.Add(new PDFItem(file, null));
                    break;
                //File is a image (maybe not valid!).
                case Combiner.SourceTestResult.Image:
                    break;
                //File is unknown
                case Combiner.SourceTestResult.Unknown:
                    //Show a metro dialog
                    await ((MetroWindow)Application.Current.MainWindow).Dispatcher.BeginInvoke(new Action(() => ((MetroWindow)Application.Current.MainWindow).ShowMessageAsync("Invalid format", "The file you selected is not a supported format. More supported formats coming soon.")));
                    break;
            }
            //Update Commands
            MergeCommand.RaiseCanExecuteChanged();
            MoveUpCommand.RaiseCanExecuteChanged();
            MoveDownCommand.RaiseCanExecuteChanged();
            RemoveCommand.RaiseCanExecuteChanged();
            Application.Current.Dispatcher.Invoke(new Action(() =>((MainWindow)Application.Current.MainWindow).merger.f.Items.Refresh()));
        }



        public List<PDFItem> Files { get; set; }
        
        public void Save()
        {
            //To get the button click animation to show. We need to open the Microsoft.Win32.SaveFileDialog in a new thread.
            new System.Threading.Thread(new System.Threading.ThreadStart(async () =>
            {
                //Initailize the open file dialog and title.
                SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog() { Title = Files.Count > 1 ? String.Format("Merging {0} File(s)", Files.Count) : String.Format("Converting {0}",Path.GetFileName(Files[0].path))};
                //If user clicks ok.
                if (saveFileDialog.ShowDialog() == true)
                using (Combiner comb = new Combiner())
                {
                    comb.Output = saveFileDialog.FileName;
                    comb.Password = Files.Cast<PDFItem>().Any(x => x.password != null) ? MessageDialogResult.Affirmative == await ((MetroWindow)Application.Current.MainWindow).ShowMessageAsync("Password protected pdf", "One or more of the pdfs you are merging are password protected. Do you want to protect the merged pdf with a pasword?", MessageDialogStyle.AffirmativeAndNegative, new MetroDialogSettings() { AffirmativeButtonText = "Yes", NegativeButtonText = "No" }) ? (await ((MetroWindow)Application.Current.MainWindow).ShowInputAsync("Enter the password for the merged pdf", "Password contain anything")).ToSecureString() : null : null;
                    foreach (var item in Files)
                        comb.AddFile(File.ReadAllBytes(item.path), null);

                }
                if (!String.IsNullOrEmpty(saveFileDialog.FileName))
                    Process.Start(saveFileDialog.FileName);
            })).Start();
        }
    }
}
