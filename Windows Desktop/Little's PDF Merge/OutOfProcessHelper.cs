using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        public static SourceTestResult TestSourceFile(string filepath)
        {
            SourceTestResult returnvalue = SourceTestResult.Unreadable;
            var proc = Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location, "-verify " + filepath);
            proc.Exited += (sender, e) =>
                {
                    if (proc.ExitCode == 0x0) returnvalue = SourceTestResult.Ok;
                    else if (proc.ExitCode == 0xBADF00D) returnvalue = SourceTestResult.Unreadable;
                    else if (proc.ExitCode == 0xBAD) returnvalue = SourceTestResult.PasswordNeeded;
                    else if (proc.ExitCode == 0xBADBAD) returnvalue = SourceTestResult.BadPassword;
                    else if (proc.ExitCode == 0x01) returnvalue = SourceTestResult.Image;
                    else returnvalue = SourceTestResult.Unreadable;

                };
            return returnvalue;
        }
    }
}
