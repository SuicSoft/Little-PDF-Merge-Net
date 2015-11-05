using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Management;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SuicSoft.LittlesPDFMerge.Windows
{
    class OutOfProcessHelper
    {
        public enum SourceTestResult
        {
            Ok, Unreadable, PasswordNeeded, BadPassword, Image
        }
        public static string procdata = "";
        /// <summary>
        /// Kill a process, and all of its children, grandchildren, etc.
        /// </summary>
        /// <param name="pid">Process ID.</param>
        private static void KillProcessTree(int pid)
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher
              ("Select * From Win32_Process Where ParentProcessID=" + pid);
            ManagementObjectCollection moc = searcher.Get();
            foreach (ManagementObject mo in moc)
            {
                KillProcessTree(Convert.ToInt32(mo["ProcessID"]));
            }
            try
            {
                Process proc = Process.GetProcessById(pid);
                proc.Kill();
            }
            catch (ArgumentException)
            {
                // Process already exited.
            }
        }
        public static SourceTestResult TestSourceFile(string filepath)
        {
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = System.Reflection.Assembly.GetExecutingAssembly().Location,
                    Arguments = "-verify " + filepath,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            proc.Start();
            while (true)
            {
                if (proc.StandardOutput.ReadLine() == "ok")
                {
                    KillProcessTree(proc.Id);
                    //writer.WriteLineAsync("dispose");
                    return SourceTestResult.Ok;
                }
                else if (proc.StandardOutput.ReadLine() == "unread")
                {
                    KillProcessTree(proc.Id);
                    //writer.WriteLineAsync("dispose");
                    return SourceTestResult.Unreadable;
                }
                else if (proc.StandardOutput.ReadLine() == "pn")
                {
                    KillProcessTree(proc.Id);
                    //writer.WriteLineAsync("dispose");
                    return SourceTestResult.PasswordNeeded;
                }
                else if (proc.StandardOutput.ReadLine() == "p")
                {
                    KillProcessTree(proc.Id);
                    //writer.WriteLineAsync("dispose");
                    return SourceTestResult.BadPassword;
                }
                else if (proc.StandardOutput.ReadLine() == "img")
                {
                    KillProcessTree(proc.Id);
                    //writer.WriteLineAsync("dispose");
                    return SourceTestResult.Image;
                }
            }          
        }
        public static string GetHash(string file)
        {
            using (var md5 = MD5.Create())
                using (var stream = File.OpenRead(file))
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLower();
        }
    }
}
