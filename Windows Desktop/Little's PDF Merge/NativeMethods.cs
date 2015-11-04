using System;
using System.Runtime.InteropServices;
namespace SuicSoft.LittlesPDFMerge.Windows
{
    static class NativeMethods
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

    }
}
