namespace PieceMover
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;
    using System.Threading.Tasks;

    class Program
    {
        private static readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("http://192.168.50.40:5000/"),
            DefaultRequestHeaders =
            {
                Accept = { new MediaTypeWithQualityHeaderValue("text/html") },
                Authorization = new AuthenticationHeaderValue("Basic",
                    "c3VwZXJzZWNyZXR1c2VyOmpjd2h5ZG93ZWFsd2F5c25lZWRzb21lc3R1cGlkYXV0aA==")
            }
        };

        private static readonly External _external = new External();

        static async Task Main(string[] args)
        {
            while (true)
            {
                var input = await ReadMove();
                if (input != "")
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
                }

                Thread.Sleep(2000);
            }
        }

        private static void Send(Input move) => _external.SendMove(move);

        private static void SendEnter() => _external.SendEnter();

        private static async Task<string> ReadMove()
        {
            var result2 = await _client.PostAsync("read", new FormUrlEncodedContent(new List<KeyValuePair<string, string>> { }));

            var move = await result2.Content.ReadAsStringAsync();

            return move == "cleared" ? "" : move;
        }

        private static async Task<string> SetMove(string move)
        {
            var values = new KeyValuePair<string, string>("move", move);

            var result = await _client.PostAsync("set", new FormUrlEncodedContent(new List<KeyValuePair<string, string>> { values }));

            var moveResult = await result.Content.ReadAsStringAsync();

            return moveResult;
        }
    }
}
