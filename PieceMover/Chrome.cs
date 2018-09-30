namespace PieceMover
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Threading;

    //https://stackoverflow.com/a/30156990/2612547
    public class Chrome
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        private const uint _keyDown = 0x100;
        private const uint _keyUp = 0x101;

        private readonly Process chromeProcess;

        public Chrome()
        {
            chromeProcess = Process.GetProcessesByName("chrome").First();
        }

        public void SendKey(char key)
        {
            if (chromeProcess.MainWindowHandle != IntPtr.Zero)
            {
                SendMessage(chromeProcess.MainWindowHandle, _keyDown, (IntPtr)key, IntPtr.Zero);
                SendMessage(chromeProcess.MainWindowHandle, _keyUp, (IntPtr)key, IntPtr.Zero);
            }
        }
    }

}