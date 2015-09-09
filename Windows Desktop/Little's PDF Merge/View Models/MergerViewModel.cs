using System.Collections.Generic;
using System.IO;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Linq;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Controls;
using Microsoft.Win32;
using System;
using System.Windows;
using iTextSharp.text.pdf;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.CompilerServices;
namespace SuicSoft.LittlesPDFMerge.Windows
{
    class MergerViewModel 
    {
        public static MetroWindow window;
        public MergerViewModel()
        {
            MergeCommand = new ActionCommand(() => Save());
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
        }
        public List<PDFItem> _Files = new List<PDFItem>();
        public IEnumerable<PDFItem> Files { get; set; }
        public static ICommand MergeCommand { get; set; }
        public static ICommand AddFileCommand { get; set; }
        /// <summary>
        /// Shows a password box for a pdf
        /// </summary>
        /// <param name="file">The path of the pdf</param>
        private async void ShowPasswordBox(string file)
        {
            //Show the user the password dialog.
            string result = await window.ShowInputAsync("PDF not allowed", "Enter the password for " + Path.GetFileName(file) + " to open the file. Enter the password 'hack' to crack the password", new LoginDialogSettings { UsernameWatermark = "Password", PasswordWatermark = "Enter Password Again", AffirmativeButtonText = "Ok", ColorScheme = MetroDialogColorScheme.Accented });
            if (!String.IsNullOrWhiteSpace(result))
            {
                try
                {
                    //Use iTextSharp.text.pdf.PdfReader to open the pdf.
                    new PdfReader(file, System.Text.Encoding.Default.GetBytes(result)).Dispose();
                    //Check if passowrd is correct
                    //Add the file to the listbox as a secure string. Won't reach here if password is wrong.
                    _Files.Add(new PDFItem(file, null));
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
                    window.Dispatcher.Invoke(new Action(() => window.ShowMessageAsync("The file " + Path.GetFileName(file) + " could not be opened as a PDF or image", "Some thing went wrong when opening " + Path.GetFileName(file))));
                    break;
                //File is a protected pdf.
                case Combiner.SourceTestResult.Protected:
                    PdfReader.unethicalreading = false;
                    try
                    {
                        using (PdfReader reader = new PdfReader(file))
                        {
                            if (!reader.IsOpenedWithFullPermissions)
                                window.Dispatcher.Invoke(new Action(async () =>
                                {
                                    if (MessageDialogResult.Affirmative == await window.DonNotShowAgainDialog("The file " + " is a protected file", "Opening protected files may not be allowed by the pdf author", "Lawyer"))
                                        //That dog wants to open protected files.
                                        PdfReader.unethicalreading = true;
                                    else
                                        //Exit the method
                                        return;
                                }));
                        }
                    }
                    catch
                    {
                        window.Dispatcher.Invoke(new Action(() => ShowPasswordBox(file)));
                        return;
                    }
                    break;
                //File is a valid pdf.
                case Combiner.SourceTestResult.Ok:
                    //Add the pdf to the ListBox.
                    _Files.Add(new PDFItem(file, null));
                    break;
                //File is a image (maybe not valid!).
                case Combiner.SourceTestResult.Image:
                    break;
                //File is unknown
                case Combiner.SourceTestResult.Unknown:
                    await window.Dispatcher.BeginInvoke(new Action(() => window.ShowMessageAsync("Invalid format", "The file you selected is not a supported format. More supported formats coming soon.")));
                    break;
            }
            Files = _Files;
            window.Dispatcher.Invoke(new Action(() => ((MainWindow)App.Current.MainWindow).merger.f.ItemsSource = _Files));
        }
        public void Save()
        {
            //To get the button click animation to show. We need to open the Microsoft.Win32.SaveFileDialog in a new thread.
            new System.Threading.Thread(new System.Threading.ThreadStart(async () =>
            {
                //Initailize the open file dialog and title.
                SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog() { Title = _Files.Count > 1 ? String.Format("Merging {0} File(s)", _Files.Count) : String.Format("Converting {0}",Path.GetFileName(_Files[0].path))};
                //If user clicks ok.
                if (saveFileDialog.ShowDialog() == true)
                using (Combiner comb = new Combiner())
                {
                    comb.Output = saveFileDialog.FileName;
                    comb.Password = _Files.Cast<PDFItem>().Any(x => x.password != null) ? MessageDialogResult.Affirmative == await window.ShowMessageAsync("Password protected pdf", "One or more of the pdfs you are merging are password protected. Do you want to protect the merged pdf with a pasword?", MessageDialogStyle.AffirmativeAndNegative, new MetroDialogSettings() { AffirmativeButtonText = "Yes", NegativeButtonText = "No" }) ? (await window.ShowInputAsync("Enter the password for the merged pdf", "Password contain anything")).ToSecureString() : null : null;
                    Parallel.For(0, _Files.Count, i =>
                        {
                            comb.AddFile(File.ReadAllBytes(_Files[i].path), null);
                        });
                }
                if (!String.IsNullOrEmpty(saveFileDialog.FileName))
                    Process.Start(saveFileDialog.FileName);
            })).Start();
        }
    }
}
