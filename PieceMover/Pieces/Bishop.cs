namespace PieceMover.Pieces
{
    using ExternalInput;

    public class Bishop : Piece
    {
        internal override ScanCodeShort Key { get; } = ScanCodeShort.KEY_B;

        public Bishop()
        {
            
        }

        internal Bishop(ScanCodeShort id) : base(id)
        {
            
        }
    }
}