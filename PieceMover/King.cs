namespace PieceMover
{
    using ExternalInput;

    public class King : Piece
    {
        internal override ScanCodeShort Key { get; } = ScanCodeShort.KEY_K;
    }
}