using System;

namespace PieceMover
{
    using System.Threading;
    using ExternalInput;

    class Program
    {
        private static readonly External _external = new External();

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var app = new ApplicationProcess("sublime_text");

            Thread.Sleep(2000);

            _external.SendMove(new Move(new Square(ScanCodeShort.KEY_D, ScanCodeShort.KEY_4)));

            app.ConfirmMove();

            _external.SendMove(new Move(new Bishop(), new Square(ScanCodeShort.KEY_D, ScanCodeShort.KEY_3)));

            app.ConfirmMove();


        }
    }
}
