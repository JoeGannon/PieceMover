namespace PieceMover
{
    using System;
    using System.Threading;
    using ExternalInput;
    using Moves;
    using Pieces;

    class Program
    {
        private static readonly External _external = new External();

        static void Main(string[] args)
        {
            //Test();
            //todo castle
            var input = Console.ReadLine();

            while (!string.IsNullOrWhiteSpace(input))
            {
                try
                {
                    var move = MoveReader.ReadMove(input);

                    Send(move);
                    SendEnter();
                }
                catch (Exception)
                {
                    //ignore junk
                }

                Console.ReadLine();

                input = Console.ReadLine();
            }
        }

        private static void Test()
        {
            Thread.Sleep(2000);
            Send(new Move(new Knight(), new Square(ScanCodeShort.KEY_C, ScanCodeShort.KEY_3)));
            SendEnter();
        }

        private static void Send(Input move) => _external.SendMove(move);

        private static void SendEnter() => _external.SendEnter();
    }
}
