namespace PieceMover.Pieces
{
    using ExternalInput;

    public class Rook : Piece
    {
        internal override ScanCodeShort Key { get; } = ScanCodeShort.KEY_R;

        public Rook()
        {
            
        }

        internal Rook(ScanCodeShort id) : base(id)
        {
            
        }
    }
}