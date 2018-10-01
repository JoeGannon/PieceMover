namespace PieceMover
{
    using System.Collections.Generic;
    using System.Linq;
    using ExternalInput;

    public class Move
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

        public INPUT[] Read()
        {
            var inputs = _piece?.GetInputs().ToList() ?? new List<INPUT>();

            var action = Action();

            if (action.HasValue)
                inputs.Add(action.Value);

            inputs.AddRange(_square.GetInputs());

            return inputs.ToArray();
        }

        public virtual INPUT? Action() => null;
    }
}