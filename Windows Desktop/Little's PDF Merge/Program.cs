using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SuicSoft.LittlesPDFMerge.Windows
{
    class Program
    {
        [STAThread]
        public static int Main(string[] args)
        {
            
            //WARNING. Incorrect editing of this code can result in a PC Freeze , forcing you to hold down the power button and get Bad Sectors. You have been warned
            if (args.Count() > 1)
            {

                if (args[0] == "-verify" & File.Exists(args[1]))
                {
                    //TODO : Add PDF verification here
                    switch (Combiner.TestSourceFile(File.ReadAllBytes(args[1])))
                    {
                        case Combiner.SourceTestResult.Ok:
                            Console.WriteLine("ok");
                            break;
                        case Combiner.SourceTestResult.Unreadable:
                            Console.WriteLine("unread");
                            break;
                        case Combiner.SourceTestResult.Protected:
                            #region Protected
                            PdfReader.unethicalreading = false;
                            try
                            {
                                using (PdfReader pdfreader = new PdfReader(args[1]))
                                    if (!pdfreader.IsOpenedWithFullPermissions)
                                        Console.WriteLine("ok");
                            }
                            catch
                            {
                                try
                                {
                                    if (args.ElementAtOrDefault(2) != null)
                                        using (PdfReader pdfreader = new PdfReader(args[1], System.Text.Encoding.Default.GetBytes(args[2])))
                                        {
                                            Console.WriteLine("ok");
                                        }
                                    else
                                        Console.WriteLine("pn"); //The user needs to enter the password.
                                }
                                catch
                                {
                                    Console.WriteLine("p");
                                }
                            }
                            #endregion
                            break;
                        case Combiner.SourceTestResult.Image:
                            Console.WriteLine("img");
                            break;
                        case Combiner.SourceTestResult.Unknown:
                            Console.WriteLine("unread");
                            break;
                    }
                    
                }
                else if (args[0] == "-merge")
                {
                    //TODO : Add PDF merging here
                }
            }
            else
            {
                App.Main();
            }
            return 0;
        }
        
    }
}
