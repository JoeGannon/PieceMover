namespace PieceMover
{
    using System;

    class Program
    {
        private static readonly External _external = new External();

        //might be able to bypass this completely
        //private static readonly ApplicationProcess _applicationProcess = new ApplicationProcess("sublime_text");

        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            while (!string.IsNullOrWhiteSpace(input))
            {
                var move = MoveReader.ReadMove(input);

                Send(move);
                SendEnter();

                Console.ReadLine();

                input = Console.ReadLine();
            }


            Console.ReadLine();
        }

        private static void Send(Input move) => _external.SendMove(move);

        private static void SendEnter() => _external.SendEnter();
    }
}
