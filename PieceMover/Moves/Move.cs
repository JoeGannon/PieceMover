namespace PieceMover.Moves
{
    using System.Collections.Generic;
    using System.Linq;
    using ExternalInput;
    using Pieces;

    public class Move : Input
    {
        private readonly Square _square;
        private readonly Piece _piece;

        public Move(Square square)
        {
            _square = square;
        }

        public Move(Piece piece, Square square)
        {
            _piece = piece;
            _square = square;
        }

        public INPUT[] GetInputs()
        {
            var inputs = _piece?.GetInputs().ToList() ?? new List<INPUT>();

            inputs.AddRange(Actions());

            inputs.AddRange(_square.GetInputs());

            return inputs.ToArray();
        }

        public virtual INPUT[] Actions() => new INPUT[0];
    }
}