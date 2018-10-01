namespace PieceMover.Pieces
{
    using ExternalInput;

    public class Queen : Piece
    {
        internal override ScanCodeShort Key { get; } = ScanCodeShort.KEY_Q;

        public Queen()
        {
            
        }

        internal Queen(ScanCodeShort id) : base(id)
        {
            
        }
    }
}