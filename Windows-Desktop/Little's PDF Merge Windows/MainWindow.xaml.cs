               /*++++++ooo++-                                                                                                                             |
             :++-```````````.+y/                                                                                                                          |
           .ys``````    ```````:s+`                                                                                                                       |
          .mo``.-``      `oyo/``.-ss-                                                                                                                     |
         .h+`.dh+y       `ydhN.````.+s/                                                                                                                   |
       `+h-```oss+        `-:.```````.:so`                                                                                                                |
      +d+.````````   `.`     ``````````.-+/-                                                                                                              |
    `yh-````````    oooo/     ````.:``````.:o/`                                                                                                           |
   .dh.`````````    .+:.`      ```oyy-``````.+y+`                                                                                                         |
  -my.````os.```  -/-h+:o.     `.+``/d+```````.oy.                                                                                                        |
 `ds.```.ysod/```  ./y+-`    ``-:`   .hy:```````.d                                 ...                                           `.......`                |
-do````.h+  -+y/.```-+-`````.:od      `+d+.``````N     .:+++++++++/                ://              `-/+++++++++.               -ooo+++++.   /++          |
do````.s:     shhs+/:::::/+syyyd        ./s+:..:od    .os+---------  `..`     ...  ...   ``.......  +so:--------`   ``......`   /ss.-----`...oso....      |
m-```:y.      oyyyyhyyyhhhhyyyyh+         `.//+//.    -ss:````````   -ss-     os+  /ss` -+ooooooo+` oso.```````    -+oooooooo/  /ss:ooooo.+ooossooo+`     |
d...+o` :-::::+ooooooooooosssssss///////`              :+o++++++oo/` -ss-     os+  /ss` oso```````  ./o+++++++o+-  oso`````/ss. /ss`````` ```oso````      |
/+++-   ////////////+++++++++++++ooooooo.               ````````.os+ -ss:     os+  /ss` os+           ````````/ss. os+     :ss. /ss`         oso          |
        ////////////+++++++++++++ooooooo.             `::::::::::os/ `+so:::::os+  /ss` +so:::::::` -:::::::::+so` +so:::::+so` /ss`         oso          |
        //:://////-++//+///+++++//++/+oo. `````       .++++++++++/-   `-/+++++++:  :++  `:++++++++` /++++++++++:`  `:+++++++/.  :++          /++          |
        +/-:/-/://-+/-/+::/+:+:+./+/-+oo.``````                                                                                                           |
        +/:::::-//./+-:+//-+:/:o:ooo:/oo-`````                                                                                                            |
        +++++++++++++++++++++oooooooooos-``                                                                                                               |
        +++++++++++++++++++++oooooooooos-                                                                                                                 |
        +++++++++++++++++++ooooooooooooo.                                                                                                                 |  
        /+++///++++++++++++++++++++++oo+`                                                                                                                 |
         .--`````````.s//o```````````.`                                                                                                                   |
         .-.         od  N-          .:                                                                                                                   |
        ./`          oy  N/          .N                                                                                                                   |
        oh           +y  ds         .d/                                                                                                                   |
        .my`         os  .m:      -sN/                                                                                                                    |
         `+d/       -m+   `sooo+oo/.                                                                                                                      |
            :ooossooy:                                                                                                                                    | 
__________________________________________________________________________________________________________________________________________________________| 

 *This file is part of Little's PDF Merge. An open source software
 -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
 | Contact Infomation                 | Program Infomation                              | Tools Used                                                    | Libs Used                         | Software Requirements    | Hardware Requirements |
 |  *Email : mailto:suiciwd@gmail.com |  *Name : SuicSoft LittleSoft Little's PDF Merge |  *Microsoft Visual Studio  *Microsoft Blend for Visual Studio |  *iTextSharp (iText .NET Port)    |  *Windows Vista or newer |  *1Ghz or faster CPU  |
 |  *Web : http://www.suicsoft.com    |  *Version : 2.2.1                               |  *Microsoft SDKs           *Microsoft .NET Framework 4.5      |  *Material Design In Xaml Toolkit |  *.NET Framework 4.5.1   |  *512mb RAM           |
 -----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
 License.md is included with the Visual Studio Project ,installer and portable.
 The SuicSoft Open License (SOL)

 *Copyright (c) 2015 SuicSoft

 *SuicSoft Stuff is Names, Logos and Other Things which someone can identify as SuicSoft

 *You can't sell our code and software, and remove all SuicSoft stuff and if you're trying to just copy our UI - we'll BAN you from our website, Anyways if you like the UI check out Material-Design-in-XAML-Toolkit on Github, then use it yourself!

 *And Remember: NO USING OUR CODE IF YOU'RE USING IT IN A NON-OPEN SOURCE PROJECT

 *Keep the dog if you like! But if you do, say you found him on SuicSoft.com.

 *THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
 *INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
 *IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 *WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Input;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using SuicSoft.LittleSoft.LittlesPDFMerge.Core;
using iTextSharp.text.pdf;
using System.Collections.Generic;
using System.Threading;
using System.Reflection;
using System.Security;
using Plugin.Core;
using System.Windows.Threading;
namespace SuicSoft.LittleSoft.LittlesPDFMerge.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    [CLSCompliant(false)]
    partial class MainWindow : MetroWindow
    {
        #region Fullscreen Window
        private static WindowStyle _WindowStyle;
        private static WindowState _WindowState;
        private static Button b;
        void InitFW()
         {
             //Add state changed handler.
             StateChanged += (object sender, System.EventArgs e) =>
                 {
                     if ((bool)GetValue(IsFullscreenProperty) == true & WindowState == System.Windows.WindowState.Normal)
                         SetValue(IsFullscreenProperty, false);
                 };
             //Add fullscreen clicked handler
             b.Click += (object sender, RoutedEventArgs e) => {
                 if ((bool)GetValue(IsFullscreenProperty) == false)
                     SetValue(IsFullscreenProperty, true);
                 else
                     SetValue(IsFullscreenProperty, false);
             };
             var commands = new WindowCommands();
             commands.Items.Add(b);
             RightWindowCommands = commands;
         }
        public static bool GetIsFullscreen(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsFullscreenProperty);
        }

        public static void SetIsFullscreen(DependencyObject obj, bool value)
        {
            obj.SetValue(IsFullscreenProperty, value);
        }
        
        public static readonly DependencyProperty IsFullscreenProperty =
            DependencyProperty.RegisterAttached("Fullscreen",
            typeof(bool), typeof(MainWindow), new PropertyMetadata
            (false, new PropertyChangedCallback(IsFullscreenChangedChanged)));

        private static void IsFullscreenChangedChanged
        (DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue == true)
            {
                ((System.Windows.Shapes.Path)b.Content).Data = Geometry.Parse("M14,14H19V16H16V19H14V14M5,14H10V19H8V16H5V14M8,5H10V10H5V8H8V5M19,8V10H14V5H16V8H19Z");
                d.SetValue(IgnoreTaskbarOnMaximizeProperty, true);
                d.SetValue(ShowTitleBarProperty, false);
                _WindowStyle = (WindowStyle)d.GetValue(Window.WindowStyleProperty);
                _WindowState = (WindowState)d.GetValue(Window.WindowStateProperty);
                d.SetValue(Window.WindowStyleProperty, WindowStyle.None);
                d.SetValue(Window.WindowStateProperty, WindowState.Maximized);
            }
            else
            {
                ((System.Windows.Shapes.Path)b.Content).Data = Geometry.Parse("M5,5H10V7H7V10H5V5M14,5H19V10H17V7H14V5M17,14H19V19H14V17H17V14M10,17V19H5V14H7V17H10Z");
                d.SetValue(ShowTitleBarProperty, true);
                d.SetValue(IgnoreTaskbarOnMaximizeProperty, false);
                d.SetValue(Window.WindowStyleProperty, _WindowStyle);
                d.SetValue(Window.WindowStateProperty, _WindowState);

            }
        }

#endregion

        List<IPlugin> plugins;
        Dictionary<int, bool[]> dict;
        
        #region .ctor (Constructor)
        
        public MainWindow()
        {

            ctor();
        }
        [PreJit]
        public void ctor ()
        {
            Stopwatch all = new Stopwatch();
            all.Start();
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            Dispatcher.BeginInvoke(new Action(() =>
            {
                //Set fullscreen button.
                b = new Button() { Content = new System.Windows.Shapes.Path() { Fill = Brushes.White, Data = System.Windows.Media.Geometry.Parse("M5,5H10V7H7V10H5V5M14,5H19V10H17V7H14V5M17,14H19V19H14V17H17V14M10,17V19H5V14H7V17H10Z") } };
                //Initailize fullscreen buttons
                InitFW();
            }));
            dict = new Dictionary<int, bool[]>() { { 0, new bool[2] { false, false } }, { 1, new bool[2] { true, false } } };

            //Init code is run as parallel. This software is optimized for CPUs with 2 or more cores (not 1 core and two threads).
            ThreadPool.QueueUserWorkItem(delegate
            {
                //Start it again.
                stopwatch.Start();
                //Try loading plugins
                try { plugins = new GenericMEFPluginLoader<IPlugin>("Plugins").Plugins.ToList(); }
                //Print error message if crashes
                catch { Debug.WriteLine("Failed to init plugins"); }

                for (int i = 0; i < plugins.Count(); i++)
                {
                    plugins[i].OnLoad();
                }
                // Stop timing
                stopwatch.Stop();
                //Print time to load plugins code.
                Debug.WriteLine("Time to load plugins code: {0}", stopwatch.Elapsed);
            });

            stopwatch.Stop();
            Debug.WriteLine("Time to init variables: {0}", stopwatch.Elapsed);
            stopwatch.Reset();

            PdfReader.unethicalreading = true;

            // Begin timing
            stopwatch.Start();
            //Draw UI
            InitializeComponent();
            // Stop timing
            stopwatch.Stop();
            //Print UI draw time.
            Debug.WriteLine("Time to draw controls: {0}", stopwatch.Elapsed);
            Debug.WriteLine(all.Elapsed);
        }
        #endregion

        //If a dialog is open
        private static bool IsDialogOpen;
        //Reload the icon when resizing
        bool loadico;
        //Timer used for the mouse down on controls
        DispatcherTimer timer = new DispatcherTimer();

        #region Constants
        private const int WM_DWMCOLORIZATIONCOLORCHANGED = 800;
        #endregion

        #region Overrides
        protected override void OnSourceInitialized(EventArgs e)
        {

            base.OnSourceInitialized(e);
            HwndSource source = PresentationSource.FromVisual(this) as HwndSource;
            source.AddHook(WndProc);
        }
        #endregion

        #region Window Message Handler (WndProc)
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam,ref bool handled)
        {

            // Handle messages...
            if (msg == WM_DWMCOLORIZATIONCOLORCHANGED)
            {
                
            }
            return IntPtr.Zero;
        }
        #endregion

        #region Methods
        /// Updates the UI (disable and enable controls).
        private void UpdateUI()
        {
            bool[] @default = new bool[]{true,true};
            bm.IsEnabled = dict.GetValueOrDefault(FilesBox.Items.Count, @default )[0];
            rb.IsEnabled = dict.GetValueOrDefault(FilesBox.Items.Count, @default)[0];
            ub.IsEnabled = dict.GetValueOrDefault(FilesBox.Items.Count, @default)[1];
            db.IsEnabled = dict.GetValueOrDefault(FilesBox.Items.Count, @default)[1];
        }
        /// <summary>
        /// Shows a password box for a pdf
        /// </summary>
        /// <param name="file">The path of the pdf</param>
        private async void ShowPasswordBox(string file)
        {
            //Show the user the password dialog.
            string result = await this.ShowInputAsync("PDF not allowed", "Enter the password for " + Path.GetFileName(file) + " to open the file. Enter the password 'hack' to crack the password", new LoginDialogSettings { UsernameWatermark = "Password", PasswordWatermark = "Enter Password Again", AffirmativeButtonText = "Ok", ColorScheme = MetroDialogColorScheme.Accented });
            if (!String.IsNullOrWhiteSpace(result))
            {
                try
                {
                    //Use iTextSharp.text.pdf.PdfReader to open the pdf.
                    new PdfReader(file, System.Text.Encoding.Default.GetBytes(result)).Dispose();
                    //Check if passowrd is correct
                    //Add the file to the listbox as a secure string. Won't reach here if password is wrong.
                    AddFileToListBox(file,result.ToSecureString());
                }
                catch{
                    //If it isn't. Ask for the password again and return
                    ShowPasswordBox(file);}

                //Get GCHandle
                GCHandle gchandle = GCHandle.Alloc(result, GCHandleType.Pinned);
                //Clear the object with junk.
                ClearIntPtr(gchandle.AddrOfPinnedObject(), result.Length * 2 /* x2 because of unicode.*/);
                //Free GCHandle
                gchandle.Free();
                MessageBox.Show(result);
            }
        }
        /// <summary>
        /// Don't show this message again dialog.
        /// </summary>
        /// <param name="title">The title</param>
        /// <param name="message">The Message</param>
        /// <param name="id">A id that can be any string</param>
        /// <returns></returns>
        public async Task<MessageDialogResult> DonNotShowAgainDialog(string title, string message, string id)
        {
            const string regpath = "Software\\SuicSoft\\LittlePDFMerge"; //Example : Software\\Company\ProductName.
            //Open registry key for editing and reading.
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(regpath, true))
            {
                //Check if do not show this again has been clicked before
                if ((int)key.GetValue(id, 0) == 0)
                {
                    //Show message to user.
                    MessageDialogResult result = await this.ShowMessageAsync(title, message, MessageDialogStyle.AffirmativeAndNegativeAndSingleAuxiliary, new MetroDialogSettings { FirstAuxiliaryButtonText = "Don't show again", ColorScheme = MetroDialogColorScheme.Accented });
                    if (result == MessageDialogResult.FirstAuxiliary)
                    {
                        //Don't show again
                        key.SetValue(id, 1);
                        //Return ok button
                        return MessageDialogResult.Affirmative;
                    }
                    return result;
                }
            //Return ok button
            return MessageDialogResult.Affirmative;
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
                    Dispatcher.Invoke(new Action(() => this.ShowMessageAsync("The file " + Path.GetFileName(file) + " could not be opened as a PDF or image", "Some thing went wrong when opening " + Path.GetFileName(file))));
                    break;
                //File is a protected pdf.
                case Combiner.SourceTestResult.Protected:
                    PdfReader.unethicalreading = false;
                    try
                    {
                        using (PdfReader reader = new PdfReader(file))
                        {
                            if (!reader.IsOpenedWithFullPermissions)
                                Dispatcher.Invoke(new Action(async () =>
                                {
                                    if (MessageDialogResult.Affirmative == await this.DonNotShowAgainDialog("The file " + " is a protected file", "Opening protected files may not be allowed by the pdf author", "Lawyer"))
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
                        Dispatcher.Invoke(new Action(() => ShowPasswordBox(file)));
                        return;
                    }
                    break;
                //File is a valid pdf.
                case Combiner.SourceTestResult.Ok:
                    //Add the pdf to the ListBox.
                    AddFileToListBox(file, null);
                    break;
                //File is a image (maybe not valid!).
                case Combiner.SourceTestResult.Image:
                    break;
                //File is unknown
                case Combiner.SourceTestResult.Unknown:
                    await Dispatcher.BeginInvoke(new Action(() => this.ShowMessageAsync("Invalid format", "The file you selected is not a supported format. More supported formats coming soon.")));
                    break;
            }  
        }

        private void AddFileToListBox(string file,SecureString password)
        {
            Dispatcher.BeginInvoke(new Action(() => FilesBox.Items.Add(new ListBoxItem { Content = file, Tag = password })));
            Dispatcher.BeginInvoke(new Action(() => UpdateUI()));
            if (password != null)
            {
                password.MakeReadOnly();
            }
            
            
        }
        #endregion

        /// <summary>
        /// When the user clicks add file
        /// </summary>
        private void AddFile(object sender, RoutedEventArgs e)
        {
            //To get the button click animation to show. We need to open the Microsoft.Win32.OpenFileDialog in a new thread.
            new System.Threading.Thread(new System.Threading.ThreadStart(delegate(){

                //Tell the dialog is open.
                IsDialogOpen = true;
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.DefaultExt = ".pdf";
                openFileDialog.Filter = "Portable Document Format (*.pdf)|*.pdf|Text files (*.txt)|*.txt";
                openFileDialog.Multiselect = true;
                if (openFileDialog.ShowDialog() == true){
                    Parallel.For(0, openFileDialog.FileNames.Count(), i => AddInputFile(openFileDialog.FileNames[i]));
                }
                //Tell the dialog closed.
                IsDialogOpen = false;
                
            })) { Name = "Open file dialog thread." }.Start();
            
        }

        /// <summary>
        /// Moves the selected item up or down.
        /// </summary>
        /// <param name="sender">db for down and ub for up.</param>
        private void MI(object sender, RoutedEventArgs e)
        {
            //The old index
            int indexold = FilesBox.SelectedIndex;
            //The selected item
            object dataItem = FilesBox.SelectedItem;
            int index = FilesBox.SelectedIndex;
            if (sender == ub) index--;
            if (sender == db) index++;
            FilesBox.Items.Remove(dataItem);
            FilesBox.Items.Insert(index, dataItem);
            FilesBox.SelectedIndex = 0;
            FilesBox.SelectedIndex = index;
        }
        private static void ClearIntPtr (IntPtr address, int length)
        { 
            //Clear the memory address by coping s empty byte array.
            Marshal.Copy(new byte[length], 0, address, length); 
        }
        private async void Merge(object sender, RoutedEventArgs e)
        {
            //Encryption and security made this function more than two times bigger :).
            SecureString pass = null; 
            //The number of files.
            int count = 0;
            //Title of first item.
            string ci  = null, result = null;
            if (FilesBox.Items.Cast<ListBoxItem>().Any(x => x.Tag != null) & MessageDialogResult.Affirmative == await this.ShowMessageAsync("Password protected pdf", "One or more of the pdfs you are merging are password protected. Do you want to protect the merged pdf with a pasword?", MessageDialogStyle.AffirmativeAndNegative, new MetroDialogSettings() { AffirmativeButtonText = "Yes", NegativeButtonText = "No" }))
            {
                result = await this.ShowInputAsync("Enter the password for the merged pdf", "Password contain anything");
                if (!String.IsNullOrEmpty(result))
                {
                    //Set the password as the input text.
                    pass = result.ToSecureString();
                    //Get GCHandle of result.
                    GCHandle gchandle = GCHandle.Alloc(result, GCHandleType.Pinned);
                    //Clear it from memory and replace it with junk data.
                    ClearIntPtr(gchandle.AddrOfPinnedObject(), result.Length * sizeof(char));
                    //Free GCHandle
                    gchandle.Free();
                    pass.MakeReadOnly();
                }
            }
            else
                //Set the password to null if the user types nothing or clicks cancel.
                pass = null;
            //To get the button click animation to show. We need to open the Microsoft.Win32.SaveFileDialog in a new thread.
            new System.Threading.Thread(new System.Threading.ThreadStart(delegate()
            {
               
                Dispatcher.Invoke(new Action(() =>
                {
                    //Set count.
                    count = FilesBox.Items.Count;
                    //Set current item.
                    ci = ((ListBoxItem)FilesBox.Items[0]).Content.ToString();
                }));
                //Initailize the open file dialog and title.
                SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog() { Title = count > 1 ? String.Format("Merging {0} File(s)", count) : String.Format("Converting {0}", ci) };
                //If user clicks ok.
                if (saveFileDialog.ShowDialog() == true)
                    using (Combiner comb = new Combiner(pass))
                    {
                        //Set output path.
                        comb.Output = saveFileDialog.FileName;
                        //Name of the file.
                        string n = null;
                        Stopwatch sw = new Stopwatch();
                        //Start stopwatch to check merge time.
                        sw.Start();
                        Parallel.For(0, count, i =>
                        {
                            SecureString tag = null;
                            Dispatcher.Invoke(new Action(() =>
                            {
                                var item = ((ListBoxItem)FilesBox.Items[i]);
                                n = item.Content.ToString();
                                tag = (SecureString)item.Tag;
                            }));
                            comb.AddFile(File.ReadAllBytes(n), Combiner.ProtectPassword((SecureString)tag));
                            if (tag != null)
                                tag.Dispose();
                        });
                        //Stop stopwatch.
                        sw.Stop();
                        Debug.WriteLine("Time to merge pdfs in memory {0}", sw.Elapsed.ToString());
                    }
                if (!String.IsNullOrEmpty(saveFileDialog.FileName))
                    //Open the pdf file
                    System.Diagnostics.Process.Start(saveFileDialog.FileName);
            })).Start();
        }
        
        private void TitleResize(object sender, SizeChangedEventArgs e)
        {
            if (TitleText.ActualHeight < 70)
            {
                vb.Stretch = Stretch.None;
                ButtonsPanel.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                var anim = new ThicknessAnimation { To = new Thickness(55, 0, 0, 0), Duration = new Duration(new TimeSpan(0, 0, 0, 0, 100)) };
                ButtonsPanel.Margin = new Thickness(55, 0, 0, 0);
            }
            if (TitleText.ActualHeight > 70)
            {
                ButtonsPanel.VerticalAlignment = System.Windows.VerticalAlignment.Bottom;
                ButtonsPanel.Margin = new Thickness(0, 0, 0, 0);
            }
            if ((TitleText.ActualHeight < 84))
            {
                var anim = new DoubleAnimation
                {
                    To = 0,
                    Duration = new TimeSpan(0, 0, 0, 0, 150),
                };
                vb.Stretch = Stretch.None;
                TitleLabel.BeginAnimation(UIElement.OpacityProperty, anim);

            }

            else
            {
                vb.Stretch = Stretch.Uniform;
                var anim = new DoubleAnimation
                {
                    To = 1,
                    Duration = new TimeSpan(0, 0, 0, 0, 150),
                };
                TitleLabel.BeginAnimation(UIElement.OpacityProperty, anim);
            }
        }

        private void _Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (IsDialogOpen == true) e.Cancel = true;
        }

        private void _SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width < 320)
            {
                loadico = true;
                Icon = null;
            }
            else if (e.NewSize.Width > 320 & loadico)
                Icon = new System.Windows.Media.Imaging.BitmapImage(new Uri("pack://application:,,,/LPM.Windows;component/Fonts-Icons/Icon.ico", UriKind.Absolute));
        }

        void TimerClick(object sender, EventArgs e)
        {
            timer.Stop();
            timer.Tick -= TimerClick;
            MessageBox.Show("Test");
        }
    }
}

