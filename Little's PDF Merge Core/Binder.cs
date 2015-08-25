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

namespace SuicSoft.LittleSoft.LittlesPDFMerge.Core {
	public class Combiner: IDisposable {

		#region Image Format Finder
		/// <summary>
		/// Image formats (including pdf)
		/// </summary>
		private enum ImageFormat {
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
		private static ImageFormat GetImageFormat(byte[] bytes) {

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
		public Combiner() {
			dc = new Document();
			pc = new PdfCopy(dc, ms);
			//Open the document
			dc.Open();
		}
		/// <summary>
		/// Adds a file to the combiner.
		/// </summary>
		/// <param name="fileName">The path of the file. The file can be a image, pdf or text file</param>
		public void AddFile(byte[] file, byte[] password) {
			//Check if the file contains the pdf header
			if (GetImageFormat(file) == ImageFormat.pdf) {
				using(PdfReader reader = password != null ? new PdfReader(file, password):new PdfReader(file) ) {
                    //Copy the pages the new PDF doocument.
					for (var i = 1; i <= reader.NumberOfPages; i++) {
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
			else if (IsImage(file)) {
				Image image = Image.GetInstance(file);
				dc.SetPageSize(new Rectangle(image.Width, image.Height));
			}
			//Clear password from memory
            if (password == new byte[0]) {
                Array.Clear(password, 0, password.Length);
            }
		}
		/// <summary>
		/// Release all resources used by the pdf combiner and write the pdf a file.
		/// </summary>
		public void Dispose() {
			Dispose(true);
			System.GC.SuppressFinalize(this);
		}
		// NOTE: Leave out the finalizer altogether if this class doesn't 
		// own unmanaged resources itself, but leave the other methods
		// exactly as they are. 
		~Combiner() {
			// Finalizer calls Dispose(false)
			Dispose(false);
		}
		// The bulk of the clean-up code is implemented in Dispose(bool)
		protected virtual void Dispose(bool disposing) {
			if (disposing) {
				// Free managed resources.
                // Add producer as Little's PDF Merge using TextSharp
                PdfString str = new PdfString("SuicSoft Little's PDF Merge 2.2.1 (http://www.suicsoft.com) using " + iTextSharp.text.Version.GetInstance().GetVersion);
                pc.Info.Put(PdfName.PRODUCER,str);
                pc.Info.Put(PdfName.CREATOR,str);
                str = null;
                // Dispose all resources that implement IDisposable
				if (pc != null) {
					pc.Close();
					pc = null;
				}
				if (dc != null) {
					dc.Close();
					dc = null;
				}
				if (ms != null) {
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
		public static SourceTestResult TestSourceFile(byte[] file) {
			if (GetImageFormat(file) == ImageFormat.pdf) {
				try {
					using(PdfReader reader = new PdfReader(file)) {
                        //Return Ok or Protected
						return !reader.IsEncrypted() || (reader.Permissions & PdfWriter.ALLOW_COPY) == PdfWriter.ALLOW_COPY ? SourceTestResult.Ok : SourceTestResult.Protected;
					}
				} catch (iTextSharp.text.exceptions.InvalidPdfException) {
                    //Bad pdf file
					return SourceTestResult.Unreadable;
				}
                catch (IOException) {
                    //Ai Yoh error.
					return SourceTestResult.IOError;
				}
			}
            //Check if file is image
            else {
				return IsImage(file) ? SourceTestResult.Image : SourceTestResult.Unknown;
			}
		}
		/// <summary>
		/// Checks if a byte array or file is a image. Use IsImage(System.IO.File.ReadAllBytes(path)) to read from a file.
		/// </summary>
		/// <param name="bytes"></param>
		/// <returns></returns>
		public static bool IsImage(byte[] value) {
			var format = GetImageFormat(value);
			return format == ImageFormat.bmp | format == ImageFormat.gif | format == ImageFormat.jpeg | format == ImageFormat.png | format == ImageFormat.tiff;
		}
		public enum SourceTestResult {
			Ok, Unreadable, Protected, Image, Unknown, IOError
		}
	}
}