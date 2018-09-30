using System;

namespace PieceMover
{
    using System.Threading;

    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var chrome = new Chrome();
            Thread.Sleep(3000);

            new External().SendInputWithAPI();

            chrome.SendKey(Keys.Enter);
        }
    }
}
