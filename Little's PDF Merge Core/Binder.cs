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

*File originally from https://github.com/schourode/pdfbinder/blob/master/src/PDFBinder/Binder.cs File has been modified by SuicSoft to take advantage of multicore CPUs, use memory instead of writing to disk, merge protected pdfs(law documents) and.
*This file is a modified file from a open source project.
*This file is part of Little's PDF Merge.
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
| Contact Infomation                 | Program Infomation                              | Tools Used                                                    | Libs Used                        | Software Requirements    | Hardware Requirements | Codes used             |  
|  *Email : mailto:suiciwd@gmail.com |  *Name : SuicSoft LittleSoft Little's PDF Merge |  *Microsoft Visual Studio  *Microsoft Blend for Visual Studio |  *iTextSharp (iText .NET Port)   |  *Windows Vista or newer |  *1Ghz or faster CPU  |  *http://goo.gl/3r5oj2 |
|  *Web : http://www.suicsoft.com    |  *Version : 2.2.1                               |  *Microsoft SDKs           *Microsoft .NET Framework 4.5      |                                  |  *.NET Framework 4.5.1   |  *512mb RAM           |  *http://goo.gl/anfIDg |
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
License.txt is included with the Visual Studio Project ,installer and portable.

*SUMMARY - THE SHORT EULA WHICH SAYS EVERYTHING:
*Thanks for using SuicSoft Software! All SuicSoft Software are FREE and don't have malware! This is the friendly & short license, You can read the full license below
*You can share our software by always linking directly to www.suicsoft.com, no - you can't distrubute our software - we're the ones who are distrubuting it, don't go and host our software on those websites with malware.
*If you don't listen to us and continue to use SuicSoft Software while doing one of those things, you must remove all SuicSoft Software from your machine(s)

*DISCLAIMER:
*THE APPLICATION AND ANY RELATED DOCUMENTATION IS PROVIDED "AS IS" WITHOUT ANY WARRANTIES. AND THAT THE VENDOR DOES NOT WARRANT THAT THIS SUICSOFT SOFTWARE WILL RUN UNINTERRUPTED OR ERROR FREE NOR THAT THIS SUICSOFT SOFTWARE WILL OPERATE WITH HARDWARE AND/OR SOFTWARE NOT PROVIDED BY THE VENDOR, EITHER EXPRESS OR IMPLIED, INCLUDING, BUT NOT LIMITED TO, IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR PURPOSE. THE ENTIRE RISK ARISING OUT OF USE OR PERFORMANCE OF THE SOFTWARE REMAINS WITH YOU
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
*THE FULL EULA:
*This SuicSoft Software is released as freeware. 
*You are NOT allowed to: 
*Distribute this program through floppy disks, CD-ROMs, Internet Services, or any other way
*Link SuicSoft Software download links to a website which is not www.suicsoft.com
*Link SuicSoft Software to websites which host malware, adware or spyware
|---------------------------------------------------------------------------------------------------------|
|*If you AGREE and do one of those bad things, you must remove any SuicSoft Software from your machine(s) |
|---------------------------------------------------------------------------------------------------------|
*DISCLAIMER:
*THE APPLICATION AND ANY RELATED DOCUMENTATION IS PROVIDED "AS IS" WITHOUT ANY WARRANTIES. AND THAT THE VENDOR DOES NOT WARRANT THAT THIS SUICSOFT SOFTWARE WILL RUN UNINTERRUPTED OR ERROR FREE NOR THAT THIS SUICSOFT SOFTWARE WILL OPERATE WITH HARDWARE AND/OR SOFTWARE NOT PROVIDED BY THE VENDOR, EITHER EXPRESS OR IMPLIED, INCLUDING, BUT NOT LIMITED TO, IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR PURPOSE. THE ENTIRE RISK ARISING OUT OF USE OR PERFORMANCE OF THE SOFTWARE REMAINS WITH YOU

 
* This file is used to merge PDF, text and image files in to one pdf file.
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
* Example usage in C#.
* 
* using SuicSoft.LittleSoft.LittlesPDFMerge.Core
* 
* ...
* 
* using(Combiner pdfbinder = new Combiner()
* {
*     pdfbinder.OutputPath = "C:\Merged.pdf"
*     pdfbinder.AddFile("C:\Dogs\BeardedCollie.pdf",null); //Replace null with password as byte array
*     pdfbinder.AddFile("C:\Dogs\BorderCollie.pdf,null);
* }
* Use a code converter to convert the code to any other language.Place the using stuff at the very top of your code.Do not keep the ...
*
* 
* 
*/
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Text;
//We use Linq.
using System.Linq;
//For all the disk I/O stuff.
using System.IO;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Security;

namespace SuicSoft.LittleSoft.LittlesPDFMerge.Core
{
    public static class Exension
    {
        public static string ConvertToUnsecureString(this SecureString securePassword)
        {
            if (securePassword == null)
                throw new ArgumentNullException("securePassword");

            IntPtr unmanagedString = IntPtr.Zero;
            try
            {
                unmanagedString = Marshal.SecureStringToGlobalAllocUnicode(securePassword);
                return Marshal.PtrToStringUni(unmanagedString);
            }
            finally
            {
                Marshal.ZeroFreeGlobalAllocUnicode(unmanagedString);
            }
        }
        public static SecureString ToSecureString(this string Source)
        {
            if (string.IsNullOrWhiteSpace(Source))
                return null;
            else
            {
                SecureString Result = new SecureString();
                foreach (char c in Source.ToCharArray())
                    Result.AppendChar(c);
                return Result;
            }
        }
    }
    public class Combiner : IDisposable
    {

        #region Image Format Finder
        /// <summary>
        /// Image formats (including pdf)
        /// </summary>
        private enum h
        {
            bmp,
            jpeg,
            gif,
            tiff,
            png,
            pdf,
            unknown
        }
        /// <summary>
        /// Gets the image format (including pdf) of a file.
        /// </summary>
        /// <param name="bytes">The bytes of the image or document. Use System.IO.File.ReadAllBytes("path");</param>
        /// <returns>The format of the image</returns>
        private static h i(byte[] bytes)
        {

            // see http://www.mikekunz.com/image_file_header.html

            //PDF document file header.
            var pdf = Encoding.Default.GetBytes("%PDF-1"); // Adobe PDF Document
            // BMP image file header.
            var bmp = Encoding.ASCII.GetBytes("BM"); // BMP
            // GIF image file header.
            var gif = Encoding.ASCII.GetBytes("GIF"); // GIF
            // PNG image file header
            var png = new byte[] {
				137, 80, 78, 71
			}; // PNG
            // TIFF image file header.
            var tiff = new byte[] {
				73, 73, 42
			}; // TIFF
            // TIFF2 image file header.
            var tiff2 = new byte[] {
				77, 77, 42
			}; // TIFF
            // JPG/JPEG image file header.
            var jpeg = new byte[] {
				255, 216, 255, 224
			}; // JPG/JPEG
            //JPEG Canon image file header.
            var jpeg2 = new byte[] {
				255, 216, 255, 225
			}; // JPEG Canon
            //Check the image format
            if (bmp.SequenceEqual(bytes.Take(bmp.Length))) return h.bmp;

            if (gif.SequenceEqual(bytes.Take(gif.Length))) return h.gif;

            if (png.SequenceEqual(bytes.Take(png.Length))) return h.png;

            if (tiff.SequenceEqual(bytes.Take(tiff.Length))) return h.tiff;

            if (tiff2.SequenceEqual(bytes.Take(tiff2.Length))) return h.tiff;

            if (jpeg.SequenceEqual(bytes.Take(jpeg.Length))) return h.jpeg;

            if (jpeg2.SequenceEqual(bytes.Take(jpeg2.Length))) return h.jpeg;
            if (pdf.SequenceEqual(bytes.Take(pdf.Length))) return h.pdf;

            return h.unknown;
        }
        #endregion

        //MemoryStream used to store document before it is saved to the disk.
        private MemoryStream a = new MemoryStream();
        //Docuemnt used to add files to.
        private Document b;
        //Used to write to the pdf.
        private PdfCopy c;
        /// <summary>
        /// The output path.
        /// </summary>
        public string d;

        /// <summary>
        /// Initailizes the pdf combiner.
        /// </summary>
        public Combiner()
        {
            b = new Document();
            c = new PdfCopy(b, a);
            //Open the document
            b.Open();
        }
        private static byte[] e;
        public static byte[] ProtectPassword(SecureString s)
        {
            try
            {
                byte[] f = new byte[15];
                Random random = new Random();
                random.NextBytes(f);
                e = f;
                random = null;
                //Password
                byte[] g = ProtectedData.Protect(System.Text.Encoding.Default.GetBytes(s.ConvertToUnsecureString()), e, DataProtectionScope.CurrentUser);
                return g;
            }
            finally
            {
                s.Dispose();
                GC.Collect();
            }
        }
     

        /// <summary>
        /// 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="password">The password of the pdf as a encrypted byte array.</param>
        /// <example>AddFile("somefile.pdf",</example>
        /// <returns></returns>
        public uint AddFile(byte[] file, byte[] password)
        {
            try
            {
                //Check if the file contains the pdf header
                if (i(file) == h.pdf)
                    using (PdfReader reader = password != null ? new PdfReader(file, ProtectedData.Unprotect(password, e, DataProtectionScope.CurrentUser)) : new PdfReader(file))
                    {
                        //Copy the pages the new PDF doocument.
                        for (var j = 1; j <= reader.NumberOfPages; j++)
                        {
                            var size = reader.GetPageSizeWithRotation(j);
                            //Set the page size.
                            b.SetPageSize(size);
                            //Create a new page.
                            b.NewPage();
                            var k = c.GetImportedPage(reader, j);
                            //Add the extracted page.
                            c.AddPage(k);
                        }
                    }
                //Check if the file contains the image file header.
                else if (IsImage(file))
                {
                    Image image = Image.GetInstance(file);
                    b.SetPageSize(new Rectangle(image.Width, image.Height));
                }
                //Clear password from memory
                Array.Clear(password != null ? password : new byte[0], 0, password != null ? password.Length : 0);
                Array.Clear(e, 0, 15);
                if (password != null)
                {
                    GC.Collect();
                }
            }
            catch
            {
                //The pdf binder ate a bad pdf or image.
                return 0xBADF00D;
            }
            //The pdf binder ate good food.
            return 0x0F00D;
        }
        /// <summary>
        /// Release all resources used by the pdf combiner and write the pdf a file.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
        // NOTE: Leave out the finalizer altogether if this class doesn't 
        // own unmanaged resources itself, but leave the other methods
        // exactly as they are. 
        ~Combiner()
        {
            // Finalizer calls Dispose(false)
            Dispose(false);
        }
        // The bulk of the clean-up code is implemented in Dispose(bool)
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Free managed resources.
                // Add producer as Little's PDF Merge using TextSharp
                PdfString l = new PdfString("SuicSoft Little's PDF Merge 2.2.1 (http://www.suicsoft.com) using " + iTextSharp.text.Version.GetInstance().GetVersion);
                c.Info.Put(PdfName.PRODUCER, l);
                c.Info.Put(PdfName.CREATOR, l);
                l = null;
                // Dispose all resources that implement IDisposable
                if (c != null)
                {
                    c.Close();
                    c = null;
                }
                if (b != null)
                {
                    b.Close();
                    b = null;
                }
                if (a != null)
                {
                    a.Close();
                    File.WriteAllBytes(d, a.GetBuffer());
                    a = null;
                }
            }
            // Free native resources if there are any. But Doga isn't using them

        }
        ///<summary>
        /// Check's if file is pdf, image or text.
        /// </summary>
        /// <param name="fileName">The file to text</param>
        /// <returns></returns>
        public static SourceTestResult TestSourceFile(byte[] file)
        {
            if (i(file) == h.pdf)
            {
                try
                {
                    using (PdfReader m = new PdfReader(file))
                    {
                        //Return Ok or Protected
                        return !m.IsEncrypted() || (m.Permissions & PdfWriter.ALLOW_COPY) == PdfWriter.ALLOW_COPY ? SourceTestResult.Ok : SourceTestResult.Protected;
                    }
                }
                catch (iTextSharp.text.exceptions.InvalidPdfException)
                {
                    //Bad pdf file
                    return SourceTestResult.Unreadable;
                }
                catch (iTextSharp.text.exceptions.BadPasswordException)
                {
                    //Ai Yoh error.
                    return SourceTestResult.Protected;
                }
            }
            //Check if file is image
            else
            {
                return IsImage(file) ? SourceTestResult.Image : SourceTestResult.Unknown;
            }
        }
        /// <summary>
        /// Checks if a byte array or file is a image. Use IsImage(System.IO.File.ReadAllBytes(path)) to read from a file.
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static bool IsImage(byte[] value)
        {
            var format = i(value);
            return format == h.bmp | format == h.gif | format == h.jpeg | format == h.png | format == h.tiff;
        }
        public enum SourceTestResult
        {
            Ok, Unreadable, Protected, Image, Unknown, IOError
        }
    }
}