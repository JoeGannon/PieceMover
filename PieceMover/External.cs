namespace PieceMover
{
    using ExternalInput;
    using System.Runtime.InteropServices;

    //https://stackoverflow.com/a/20493025/2612547
    public class External
    {
        public void SendInputWithAPI()
        {
            INPUT[] Inputs = new INPUT[6];
            INPUT Input = new INPUT();

            Input.type = 1; // 1 = Keyboard Input
            Input.U.ki.wScan = ScanCodeShort.SHIFT;
            Input.U.ki.dwFlags = KEYEVENTF.SCANCODE;
            Inputs[0] = Input;

            Input.type = 1; // 1 = Keyboard Input
            Input.U.ki.wScan = ScanCodeShort.KEY_N;
            Input.U.ki.dwFlags = KEYEVENTF.SCANCODE;
            Inputs[1] = Input;

            Input.type = 1; // 1 = Keyboard Input
            Input.U.ki.wScan = ScanCodeShort.KEY_N;
            Input.U.ki.dwFlags = KEYEVENTF.SCANCODE | KEYEVENTF.KEYUP;
            Inputs[2] = Input;

            Input.type = 1; // 1 = Keyboard Input
            Input.U.ki.wScan = ScanCodeShort.SHIFT;
            Input.U.ki.dwFlags = KEYEVENTF.SCANCODE | KEYEVENTF.KEYUP;
            Inputs[3] = Input;

            Input.type = 1; // 1 = Keyboard Input
            Input.U.ki.wScan = ScanCodeShort.KEY_C;
            Input.U.ki.dwFlags = KEYEVENTF.SCANCODE;
            Inputs[4] = Input;

            Input.type = 1; // 1 = Keyboard Input
            Input.U.ki.wScan = ScanCodeShort.KEY_3;
            Input.U.ki.dwFlags = KEYEVENTF.SCANCODE;
            Inputs[5] = Input;

            SendInput(6, Inputs, INPUT.Size);
        }

        /// <summary>
        /// Declaration of external SendInput method
        /// </summary>
        [DllImport("user32.dll")]
        internal static extern uint SendInput(
            uint nInputs,
            [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs,
            int cbSize);
    }
}
