using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SuicSoft.LittleSoft.LittlesPDFMerge.Online
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Combiner : ICombiner
    {
        #region Image Format Finder
        /// <summary>
        /// Image formats (including pdf)
        /// </summary>
        private enum ImageFormat
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
        private static ImageFormat GetImageFormat(byte[] bytes)
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
            if (bmp.SequenceEqual(bytes.Take(bmp.Length))) return ImageFormat.bmp;

            if (gif.SequenceEqual(bytes.Take(gif.Length))) return ImageFormat.gif;

            if (png.SequenceEqual(bytes.Take(png.Length))) return ImageFormat.png;

            if (tiff.SequenceEqual(bytes.Take(tiff.Length))) return ImageFormat.tiff;

            if (tiff2.SequenceEqual(bytes.Take(tiff2.Length))) return ImageFormat.tiff;

            if (jpeg.SequenceEqual(bytes.Take(jpeg.Length))) return ImageFormat.jpeg;

            if (jpeg2.SequenceEqual(bytes.Take(jpeg2.Length))) return ImageFormat.jpeg;
            if (pdf.SequenceEqual(bytes.Take(pdf.Length))) return ImageFormat.pdf;

            return ImageFormat.unknown;
        }
        #endregion

        //MemoryStream used to store document before it is saved to the disk.
        private MemoryStream ms = new MemoryStream();
        //Docuemnt used to add files to.
        private Document dc;
        //Used to write to the pdf.
        private PdfCopy pc;
        /// <summary>
        /// The output path.
        /// </summary>
        public string OutputPath;

        /// <summary>
        /// Initailizes the pdf combiner.
        /// </summary>
        public Combiner()
        {
            dc = new Document();
            pc = new PdfCopy(dc, ms);
            //Open the document
            dc.Open();
        }
        /// <summary>
        /// Adds a file to the combiner.
        /// </summary>
        /// <param name="fileName">The path of the file. The file can be a image, pdf or text file</param>
        public void AddFile(byte[] file, byte[] password)
        {
            //Check if the file contains the pdf header
            if (GetImageFormat(file) == ImageFormat.pdf)
            {
                using (PdfReader reader = password != null ? new PdfReader(file, password) : new PdfReader(file))
                {
                    //Copy the pages the new PDF doocument.
                    for (var i = 1; i <= reader.NumberOfPages; i++)
                    {
                        var size = reader.GetPageSizeWithRotation(i);
                        //Set the page size.
                        dc.SetPageSize(size);
                        //Create a new page.
                        dc.NewPage();
                        var page = pc.GetImportedPage(reader, i);
                        //Add the extracted page.
                        pc.AddPage(page);
                    }
                }
            }
            //Check if the file contains the image file header.
            else if (IsImage(file))
            {
                Image image = Image.GetInstance(file);
                dc.SetPageSize(new Rectangle(image.Width, image.Height));
            }
            //Clear password from memory
            if (password == new byte[0])
            {
                Array.Clear(password, 0, password.Length);
            }
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
                PdfString str = new PdfString("SuicSoft Little's PDF Merge 2.2.1 (http://www.suicsoft.com) using " + iTextSharp.text.Version.GetInstance().GetVersion);
                pc.Info.Put(PdfName.PRODUCER, str);
                pc.Info.Put(PdfName.CREATOR, str);
                str = null;
                // Dispose all resources that implement IDisposable
                if (pc != null)
                {
                    pc.Close();
                    pc = null;
                }
                if (dc != null)
                {
                    dc.Close();
                    dc = null;
                }
                if (ms != null)
                {
                    ms.Close();
                    File.WriteAllBytes(OutputPath, ms.GetBuffer());
                    ms = null;
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
            if (GetImageFormat(file) == ImageFormat.pdf)
            {
                try
                {
                    using (PdfReader reader = new PdfReader(file))
                    {
                        //Return Ok or Protected
                        return !reader.IsEncrypted() || (reader.Permissions & PdfWriter.ALLOW_COPY) == PdfWriter.ALLOW_COPY ? SourceTestResult.Ok : SourceTestResult.Protected;
                    }
                }
                catch (iTextSharp.text.exceptions.InvalidPdfException)
                {
                    //Bad pdf file
                    return SourceTestResult.Unreadable;
                }
                catch (IOException)
                {
                    //Ai Yoh error.
                    return SourceTestResult.IOError;
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
            var format = GetImageFormat(value);
            return format == ImageFormat.bmp | format == ImageFormat.gif | format == ImageFormat.jpeg | format == ImageFormat.png | format == ImageFormat.tiff;
        }
        public enum SourceTestResult
        {
            Ok, Unreadable, Protected, Image, Unknown, IOError
        }
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
