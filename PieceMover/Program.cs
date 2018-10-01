namespace PieceMover
{
    using System.Threading;
    using ExternalInput;
    using Moves;
    using Pieces;

    class Program
    {
        private static readonly External _external = new External();
        private static readonly ApplicationProcess _applicationProcess = new ApplicationProcess("sublime_text");

        static void Main(string[] args)
        {
            Thread.Sleep(2000);

            Send(new Move(new Square(ScanCodeShort.KEY_D, ScanCodeShort.KEY_4)));

            Send(new PawnTakesMove(ScanCodeShort.KEY_C, new Square(ScanCodeShort.KEY_D, ScanCodeShort.KEY_3)));

            Send(new Move(new Knight(), new Square(ScanCodeShort.KEY_D, ScanCodeShort.KEY_3)));

            Send(new TakeMove(new Knight(), new Square(ScanCodeShort.KEY_C, ScanCodeShort.KEY_3)));

            Send(new Move(new Knight(ScanCodeShort.KEY_B), new Square(ScanCodeShort.KEY_F, ScanCodeShort.KEY_5)));

            Send(new Move(new Rook(ScanCodeShort.KEY_1), new Square(ScanCodeShort.KEY_D, ScanCodeShort.KEY_8)));

            Send(new TakeMove(new Knight(ScanCodeShort.KEY_B), new Square(ScanCodeShort.KEY_D, ScanCodeShort.KEY_3)));

            Send(new Promotion(new Move(new Square(ScanCodeShort.KEY_D, ScanCodeShort.KEY_1)), new Rook()));

            Send(new Promotion(new PawnTakesMove(ScanCodeShort.KEY_C, new Square(ScanCodeShort.KEY_D, ScanCodeShort.KEY_8)), new Queen()));
        }

        private static void Send(Input move)
        {
            _external.SendMove(move);

            _applicationProcess.ConfirmMove();
        }
    }
}
