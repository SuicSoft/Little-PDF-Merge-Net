using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SuicSoft.LittlesPDFMerge.Windows
{
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
        public string Output
        {
            get { return d; }
            set { d = value; }
        }

        private string d;

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
        /// <summary>
        /// Initailizes the combiner with a password
        /// </summary>
        /// <param name="pass"></param>
        public Combiner(SecureString pass)
        {
            b = new Document();
            c = new PdfCopy(b, a);
            //Open the document
            Password = pass;
            b.Open();
        }
        private SecureString password = null;

        public SecureString Password
        {
            get { return password; }
            set { password = value; }
        }

        private static byte[] e;
        public static byte[] ProtectPassword(SecureString @string)
        {
            if (@string != null)
            {
                try
                {
                    byte[] f = new byte[15];
                    Random random = new Random();
                    random.NextBytes(f);
                    e = f;
                    random = null;
                    Array.Clear(f, 0, 15);
                    //Password
                    return ProtectedData.Protect(System.Text.Encoding.Default.GetBytes(@string.ToUnsecureString()), e, DataProtectionScope.CurrentUser);
                }
                finally
                {
                    @string.Dispose();
                }
            }
            return null;
        }
        public uint AddFile(string file, byte[] pass)
        {
            return AddFile(File.ReadAllBytes(file), pass, true);
        }
        public uint AddFile(byte[] file, byte[] pass)
        {
            return AddFile(file, pass, true);
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "1"), System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "protectedpass")]
        public uint AddFile(byte[] file, byte[] pass, bool protectedpass)
        {
            try
            {
                //Check if the file contains the pdf header
                    using (PdfReader reader = password != null ? new PdfReader(file, ProtectedData.Unprotect(pass, e, DataProtectionScope.CurrentUser)) : protectedpass ? new PdfReader(file) : new PdfReader(file, pass))
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



                //Clear password from memory
                Array.Clear(password != null ? pass : new byte[0], 0, password != null ? pass.Length : 0);
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
                    if (Password != null)
                        using (Stream output = new FileStream(d, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            using (PdfReader reader = new PdfReader(a.GetBuffer()))
                            {
                                PdfEncryptor.Encrypt(reader, output, true, Password.ToUnsecureString(), Password.ToUnsecureString(), PdfWriter.ALLOW_SCREENREADERS);
                            }
                        }
                    else
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
