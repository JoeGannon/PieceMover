namespace PieceMover
{
    using System.Dynamic;
    using System.Linq;
    using ExternalInput;
    using System.Runtime.InteropServices;
    using System.Threading;

    //https://stackoverflow.com/a/20493025/2612547
    public class External
    {
        public void SendMove(Move move)
        {
            var inputs = move.Read();
            SendInput((uint)inputs.Length, inputs, INPUT.Size);

            Thread.Sleep(30);
        }

        /// <summary>
        /// Declaration of external SendInput method
        /// </summary>
        [DllImport("user32.dll")]
        internal static extern uint SendInput(
            uint nInputs,
            [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs,
            int cbSize);
    }
}
