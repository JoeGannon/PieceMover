namespace PieceMover.Pieces
{
    using ExternalInput;

    public class Knight : Piece
    {
        internal override ScanCodeShort Key { get; } = ScanCodeShort.KEY_N;

        public Knight()
        {
            
        }

        internal Knight(ScanCodeShort id) : base(id)
        {
            
        }
    }
}