namespace PieceMover.ExternalInput
{
    using System.Runtime.InteropServices;

        // Declare the INPUT struct
    [StructLayout(LayoutKind.Sequential)]
    public struct INPUT
    {
        internal uint type;
        internal InputUnion U;

        internal static int Size
        {
            get { return Marshal.SizeOf(typeof(INPUT)); }
        }
    }
}
