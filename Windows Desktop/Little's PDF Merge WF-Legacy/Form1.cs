using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

namespace SuicSoft_LittleSoft_Little_s_PDF_Merge_WF_Legacy
{
    public partial class Form1 : Form
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();

        Font myFont;

        public Form1()
        {
            InitializeComponent();

            byte[] fontData = SuicSoft.LittleSoft.LittlesPDFMerge.Desktop.Legacy.Properties.Resources.Roboto_Regular;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, SuicSoft.LittleSoft.LittlesPDFMerge.Desktop.Legacy.Properties.Resources.Roboto_Regular.Length);
            AddFontMemResourceEx(fontPtr, (uint)SuicSoft.LittleSoft.LittlesPDFMerge.Desktop.Legacy.Properties.Resources.Roboto_Regular.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
            myFont = new Font(fonts.Families[0], 30);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Font = myFont;
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
    }

}
