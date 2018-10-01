namespace PieceMover
{
    using ExternalInput;

    public class TakeMove : Move
    {
        public TakeMove(Square square) : base(square) { }
        public TakeMove(Piece piece, Square square) : base(piece, square) { }

        public override INPUT? Action()
        {
            var input = new INPUT { type = 1 };

            input.U.ki.wScan = ScanCodeShort.KEY_X;
            input.U.ki.dwFlags = KEYEVENTF.SCANCODE;

            return input;
        }
    }
}