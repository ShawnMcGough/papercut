using System;
using System.Threading.Tasks;

namespace papercut
{
    class Program
    {
        static void Main(string[] args)
        {
            const string url = "http://localhost:17054";
            const int numOfRequests = 500;


            Console.WriteLine("Press Enter to start...");
            Console.ReadLine();

            Task.WaitAll(new Papercut().Start(url, numOfRequests));

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();

        }
    }
}
