namespace PieceMover
{
    using System;
    using System.Collections.Generic;
    using ExternalInput;

    public class Castle : Input
    {
        private bool longCastles = false;

        private Castle()
        {
            
        }

        public static Castle Long() => new Castle { longCastles = true};
        public static Castle Short() => new Castle();

        public INPUT[] GetInputs()
        {
            var inputs = new List<INPUT>();

            var input = new INPUT { type = 1 };

            input.U.ki.wScan = ScanCodeShort.KEY_O;
            input.U.ki.dwFlags = KEYEVENTF.SCANCODE;

            inputs.Add(input);

            input.U.ki.wScan = ScanCodeShort.OEM_MINUS;
            input.U.ki.dwFlags = KEYEVENTF.SCANCODE;

            inputs.Add(input);

            input.U.ki.wScan = ScanCodeShort.KEY_O;
            input.U.ki.dwFlags = KEYEVENTF.SCANCODE;

            inputs.Add(input);

            if (longCastles)
            {
                input.U.ki.wScan = ScanCodeShort.OEM_MINUS;
                input.U.ki.dwFlags = KEYEVENTF.SCANCODE;

                inputs.Add(input);

                input.U.ki.wScan = ScanCodeShort.KEY_O;
                input.U.ki.dwFlags = KEYEVENTF.SCANCODE;

                inputs.Add(input);
            }

            return inputs.ToArray();
        }
    }
}