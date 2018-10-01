namespace PieceMover
{
    using ExternalInput;
    using System.Runtime.InteropServices;
    using System.Threading;

    //https://stackoverflow.com/a/20493025/2612547
    public class External
    {
        public void SendMove(Input move)
        {
            var inputs = move.GetInputs();
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
