using System;

namespace StackExchange.Redis.SentinelTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting Redis Sentinels Tests[StackExchange.Redis] (Gradient ECM (c) 2015)");
            Console.WriteLine("Press Enter to start...");
            Console.ReadLine();
            string fileName = "log.txt";
            using (var tests = new SentinelTests(fileName))
            {
                tests.Run();
            }
            Console.ReadLine();
        }
    }
}
