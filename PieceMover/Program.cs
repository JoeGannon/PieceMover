namespace PieceMover
{
    using System.Threading;
    using ExternalInput;

    class Program
    {
        private static readonly External _external = new External();
        private static readonly ApplicationProcess _applicationProcess = new ApplicationProcess("sublime_text");

        static void Main(string[] args)
        {
            Thread.Sleep(2000);

            Send(new Move(new Square(ScanCodeShort.KEY_D, ScanCodeShort.KEY_4)));

            Send(new Move(new Knight(), new Square(ScanCodeShort.KEY_D, ScanCodeShort.KEY_3)));

            Send(new Move(new Knight(ScanCodeShort.KEY_B), new Square(ScanCodeShort.KEY_F, ScanCodeShort.KEY_5)));

            Send(new TakeMove(new Knight(ScanCodeShort.KEY_B), new Square(ScanCodeShort.KEY_D, ScanCodeShort.KEY_3)));

            Send(new TakeMove(new Knight(), new Square(ScanCodeShort.KEY_C, ScanCodeShort.KEY_3)));
        }

        private static void Send(Move move)
        {
            _external.SendMove(move);

            _applicationProcess.ConfirmMove();
        }
    }
}
