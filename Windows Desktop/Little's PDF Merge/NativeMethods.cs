using System;
using System.Runtime.InteropServices;
namespace SuicSoft.LittlesPDFMerge.Windows
{
    static class NativeMethods
    {
        /// <summary>
        /// WM_COPYDATA constant
        /// </summary>
        public const int WM_COPYDATA = 0x004A;
        /// <summary>
        /// The SendMessage function sends the specified message to a
        /// window or windows. It calls the window procedure for the specified
        /// window and does not return until the window procedure
        /// has processed the message.
        /// </summary>
        /// <param name="hWnd">handle to destination window</param>
        /// <param name="Msg">message</param>
        /// <param name="wParam">first message parameter</param>
        /// <param name="lParam">second message parameter</param>
        /// <returns></returns>
        [DllImport("User32.dll", CharSet = CharSet.Ansi)]
        public static extern Int32 SendMessage(int hWnd, int Msg, int wParam, [MarshalAs(UnmanagedType.LPStr)] string lParam);

        /// <summary>
        /// Send Message
        /// </summary>
        /// <param name="hWnd">handle to destination window</param>
        /// <param name="Msg">message</param>
        /// <param name="wParam">first message parameter</param>
        /// <param name="lParam">second message parameter</param>
        /// <returns></returns>
        [DllImport("User32.dll")]
        public static extern Int32 SendMessage(int hWnd, int Msg, int wParam, int lParam);

        /// <summary>
        /// The SendMessage API
        /// </summary>
        /// <param name="hWnd">handle to the required window</param>
        /// <param name="msg">the system/Custom message to send</param>
        /// <param name="wParam">first message parameter</param>
        /// <param name="lParam">second message parameter</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(int hWnd, int msg, int wParam, IntPtr lParam);

        /// <summary>
        /// The SendMessage API
        /// </summary>
        /// <param name="hWnd">handle to the required window</param>
        /// <param name="Msg">the system/Custom message to send</param>
        /// <param name="wParam">first message parameter</param>
        /// <param name="lParam">second message parameter</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, ref CopyDataStruct lParam);

        public struct CopyDataStruct : IDisposable
        {
            public IntPtr dwData;
            public int cbData;
            public IntPtr lpData;

            public void Dispose()
            {
                if (this.lpData != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(this.lpData);
                    this.lpData = IntPtr.Zero;
                }
            }
        }
    }
}
