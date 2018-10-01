namespace PieceMover
{
    using System.Linq;
    using ExternalInput;
    using Moves;
    using Pieces;

    public class Promotion : Input
    {
        private readonly Move _move;
        private readonly Piece _piece;

        public Promotion(Move move, Piece piece)
        {
            _move = move;
            _piece = piece;
        }

        public INPUT[] GetInputs()
        {
            var input = new INPUT { type = 1 };

            var inputs = _move.GetInputs().ToList();

            input.U.ki.wScan = ScanCodeShort.OEM_PLUS;
            input.U.ki.dwFlags = KEYEVENTF.SCANCODE;

            inputs.Add(input);

            inputs.AddRange(_piece.GetInputs());

            return inputs.ToArray();
        }
    }
}