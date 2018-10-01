namespace PieceMover
{
    using System;

    class Program
    {
        private static readonly External _external = new External();

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
        }

        private static void Send(Input move) => _external.SendMove(move);

        private static void SendEnter() => _external.SendEnter();
    }
}
