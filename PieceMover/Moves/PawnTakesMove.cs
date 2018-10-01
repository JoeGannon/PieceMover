namespace PieceMover.Moves
{
    using ExternalInput;

    public class PawnTakesMove : TakeMove
    {
        private readonly ScanCodeShort _file;

        internal PawnTakesMove(ScanCodeShort file, Square square) : base (square)
        {
            _file = file;
        }

        public override INPUT[] Actions()
        {
            var input = new INPUT { type = 1 };

            input.U.ki.wScan = _file;
            input.U.ki.dwFlags = KEYEVENTF.SCANCODE;

            var takes = base.Actions()[0];

            return new[] { input, takes };
        }
    }
}