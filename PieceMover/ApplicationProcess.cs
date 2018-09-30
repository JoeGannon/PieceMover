namespace PieceMover
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Threading;

    //https://stackoverflow.com/a/30156990/2612547
    public class ApplicationProcess
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        private const uint _keyDown = 0x100;
        private const uint _keyUp = 0x101;

        private readonly Process _process;

        public ApplicationProcess(string processName)
        {
            _process = Process.GetProcessesByName(processName).First();
        }

        public void ConfirmMove()
        {
            if (_process.MainWindowHandle != IntPtr.Zero)
            {
                //send enter
                SendMessage(_process.MainWindowHandle, _keyDown, (IntPtr)(char)0x0D, IntPtr.Zero);
                SendMessage(_process.MainWindowHandle, _keyUp, (IntPtr)(char)0x0D, IntPtr.Zero);
            }
        }
    }

}