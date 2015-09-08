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
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Controls;
using System.Net.Mail;
using System.Net;
using System.Runtime.InteropServices;
using System.IO;
using System.IO.Compression;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Media;
using System.Reflection;
namespace SuicSoft.LittleSoft.LittlesPDFMerge.Windows
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region P/Invoke
        [SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "MINIDUMP"),System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "TYPE")]
        [SuppressMessage("Microsoft.Naming", "CA1707:IdentifiersShouldNotContainUnderscores")]
        static internal class MINIDUMP_TYPE
        {
            public const int MiniDumpNormal = 0x00000000;
            [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Segs")]
            public const int MiniDumpWithDataSegs = 0x00000001;
            public const int MiniDumpWithFullMemory = 0x00000002;
            public const int MiniDumpWithHandleData = 0x00000004;
            public const int MiniDumpFilterMemory = 0x00000008;
            public const int MiniDumpScanMemory = 0x00000010;
            public const int MiniDumpWithUnloadedModules = 0x00000020;
            public const int MiniDumpWithIndirectlyReferencedMemory = 0x00000040;
            public const int MiniDumpFilterModulePaths = 0x00000080;
            public const int MiniDumpWithProcessThreadData = 0x00000100;
            public const int MiniDumpWithPrivateReadWriteMemory = 0x00000200;
            public const int MiniDumpWithoutOptionalData = 0x00000400;
            public const int MiniDumpWithFullMemoryInfo = 0x00000800;
            public const int MiniDumpWithThreadInfo = 0x00001000;
            [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Segs")]
            public const int MiniDumpWithCodeSegs = 0x00002000;
        }

        [DllImport("dbghelp.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool MiniDumpWriteDump(IntPtr hProcess,
        Int32 ProcessId,
        SafeHandle hFile,
        int DumpType,
        IntPtr ExceptionParam,
        IntPtr UserStreamParam,
        IntPtr CallackParam);
        #endregion

        private async void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            try
            {
                SendCrashDump(e.Exception);
                await ((MetroWindow)App.Current.MainWindow).ShowMessageAsync("Something went wrong :(", "A error occured. We will automaticaly send a crash dump to SuicSoft");


            }
            catch
            {
                SendCrashDump(e.Exception);
                MessageBox.Show("A error occured. The metro message box couldn't be shown.We will automaticaly send a crash dump to SuicSoft", "Something went wrong :(");
            }
        }
        private void SendCrashDump(Exception e)
        {
            //Don't spam him
            var fromAddress = new MailAddress("suiciwd@gmail.com", "SuicSoft error reporting");
            var toAddress = new MailAddress("suiciwd@gmail.com", "Suici Doga");
            string subject = "SuicSoft error reporting " + e.Source;
            string body = "The HResult code is " + e.HResult + " , the exception message is " + e.Message + " ,the stack trace is " + e.StackTrace;

            using (var smtp = new SmtpClient
            {
                //Gmail SMTP server.
                Host = "smtp.gmail.com",
                Port = 587,
                //Enable Secure Sockets Layer.
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, "")
            })
            {
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    message.Attachments.Add(new Attachment(Compress(new FileInfo(CreateMiniDump()))));
                    smtp.Send(message);
                }
            }
        }
        private static string CreateMiniDump()
        {
            string filepath = Path.Combine(Path.GetTempPath(), "LPM.Windows.DumpingDog.dmp");
            using (FileStream fs = new FileStream(filepath, FileMode.Create))
            {
                using (System.Diagnostics.Process process = System.Diagnostics.Process.GetCurrentProcess())
                {
                    MiniDumpWriteDump(process.Handle,
                    process.Id,
                    fs.SafeFileHandle,
                    MINIDUMP_TYPE.MiniDumpNormal,
                    IntPtr.Zero,
                    IntPtr.Zero,
                    IntPtr.Zero);
                }
            }
            return filepath;
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0")]
        public static string Compress(FileInfo fi)
        {
            // Get the stream of the source file.
            using (FileStream inFile = fi.OpenRead())
            {
                // Prevent compressing hidden and 
                // already compressed files.
                if ((File.GetAttributes(fi.FullName) & FileAttributes.Hidden) != FileAttributes.Hidden & fi.Extension != ".gz")
                {
                    // Create the compressed file.
                    using (FileStream outFile = File.Create(fi.FullName + ".gz"))
                    {
                        using (GZipStream Compress = new GZipStream(outFile,
                        CompressionMode.Compress))
                        {
                            // Copy the source file into 
                            // the compression stream.
                            inFile.CopyTo(Compress);

                            Console.WriteLine("Compressed {0} from {1} to {2} bytes.",
                            fi.Name, fi.Length.ToString(), outFile.Length.ToString());
                        }
                    }
                }
            }
            File.Delete(fi.FullName);
            return fi.FullName + ".gz";
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //Pre JIT code in background. Takes around 0.04 seconds on Intel(R) Core(TM) i3-2350m @ 2.30GHz (4 threads and 2 cores) CPU.
            //Jitter.BeginPreJitAll<SuicSoft.LittleSoft.LittlesPDFMerge.Core.Combiner>();
            //Jitter.PreJit<MainWindow>();
        }
        
    }
}