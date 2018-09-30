namespace PieceMover
{
    using System.Collections.Generic;
    using ExternalInput;

    public class Square : Input
    {
        private readonly ScanCodeShort _file;
        private readonly ScanCodeShort _rank;

        internal Square(ScanCodeShort file, ScanCodeShort rank)
        {
            _file = file;
            _rank = rank;
        }

        public INPUT[] GetInputs()
        {
            var inputs = new List<INPUT>();

            var input = new INPUT { type = 1 };

            input.U.ki.wScan = _file;
            input.U.ki.dwFlags = KEYEVENTF.SCANCODE;

            inputs.Add(input);

            input.U.ki.wScan = _rank;
            input.U.ki.dwFlags = KEYEVENTF.SCANCODE;

            inputs.Add(input);

            return inputs.ToArray();
        }
    }
}