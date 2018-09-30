namespace PieceMover
{
    using System.Collections.Generic;
    using ExternalInput;

    public abstract class Piece : Input
    {
        internal abstract ScanCodeShort Key { get; }
        internal  ScanCodeShort? Id { get; set; }

        protected Piece()
        {
            
        }

        internal Piece(ScanCodeShort id)
        {
            Id = id;
        }

        public INPUT[] GetInputs()
        {
            var inputs = new List<INPUT>();

            var input = new INPUT { type = 1 };

            input.U.ki.wScan = ScanCodeShort.SHIFT;
            input.U.ki.dwFlags = KEYEVENTF.SCANCODE;

            inputs.Add(input);

            input.U.ki.wScan = Key;
            input.U.ki.dwFlags = KEYEVENTF.SCANCODE;
            inputs.Add(input);

            input.U.ki.wScan = Key;
            input.U.ki.dwFlags = KEYEVENTF.SCANCODE | KEYEVENTF.KEYUP;
            inputs.Add(input);

            input.U.ki.wScan = ScanCodeShort.SHIFT;
            input.U.ki.dwFlags = KEYEVENTF.SCANCODE | KEYEVENTF.KEYUP;
            inputs.Add(input);

            if (Id.HasValue)
            {
                input.U.ki.wScan = Id.Value;
                input.U.ki.dwFlags = KEYEVENTF.SCANCODE;
                inputs.Add(input);
            }

            return inputs.ToArray();
        }
    }
}