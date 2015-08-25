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
namespace SuicSoft.LittleSoft.LittlesPDFMerge.Windows
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        #region P/Invoke
        public static class MINIDUMP_TYPE
        {
            public const int MiniDumpNormal = 0x00000000;
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
            public const int MiniDumpWithCodeSegs = 0x00002000;
        }

        [DllImport("dbghelp.dll")]
        public static extern bool MiniDumpWriteDump(IntPtr hProcess,
        Int32 ProcessId,
        IntPtr hFile,
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

            var smtp = new SmtpClient
            {
                //Gmail SMTP server.
                Host = "smtp.gmail.com",
                Port = 587,
                //Enable Secure Sockets Layer.
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address,"")
            };
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
        private static string CreateMiniDump()
        {
            string filepath = Path.Combine(Path.GetTempPath(), "LPM.Windows.DumpingDog.dmp");
            using (FileStream fs = new FileStream(filepath, FileMode.Create))
            {
                using (System.Diagnostics.Process process = System.Diagnostics.Process.GetCurrentProcess())
                {
                    MiniDumpWriteDump(process.Handle,
                    process.Id,
                    fs.SafeFileHandle.DangerousGetHandle(),
                    MINIDUMP_TYPE.MiniDumpNormal,
                    IntPtr.Zero,
                    IntPtr.Zero,
                    IntPtr.Zero);
                }
            }
            return filepath;
        }
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
           
        }
    }
}