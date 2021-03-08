using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;
using Microsoft.Extensions.Logging.Debug;
using Microsoft.Extensions.Options;
using System;

namespace Logging
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ILoggerProvider provider = GetLoggerProvider();
                IAlgorithm algorithm = GetAlgorithm();
                int first = 0, second = 0;
                GetArguments(out first, out second);
                TypeTime typeTime = GetTypeTime();
                Console.WriteLine(algorithm.GetLeadTime(first, second, typeTime));
                algorithm.Logging(first, second, provider);
            }
        }

        static ILoggerProvider GetLoggerProvider()
        {
            Console.WriteLine("Choose logger provider");
            Console.WriteLine("1. Event logger provider");
            Console.WriteLine("2. Debug logger provider");
            int key = int.Parse(Console.ReadLine());
            Console.Clear();
            ILoggerProvider provider;
            switch (key)
            {
                case 1:
                    provider = new EventLogLoggerProvider();
                    break;
                case 2:
                    provider = new DebugLoggerProvider();
                    break;
                default:
                    provider = new DebugLoggerProvider();
                    break;
            }

            return provider;
        }

        static IAlgorithm GetAlgorithm()
        {
            Console.WriteLine("Choose operation");
            Console.WriteLine("1. Sum");
            Console.WriteLine("2. Multiply");
            int key = int.Parse(Console.ReadLine());
            Console.Clear();
            IAlgorithm algorithm;
            switch (key)
            {
                case 1:
                    algorithm = new Sum();
                    break;
                case 2:
                    algorithm = new Multiply();
                    break;
                default:
                    algorithm = new Sum();
                    break;
            }

            return algorithm;
        }

        static void GetArguments(out int first, out int second)
        {
            Console.WriteLine("First argument = ");
            first = int.Parse(Console.ReadLine());
            Console.WriteLine("Second argument = ");
            second = int.Parse(Console.ReadLine());
            Console.Clear();
        }

        static TypeTime GetTypeTime()
        {
            Console.WriteLine("1.Milliseconds");
            Console.WriteLine("2.Seconds");
            Console.WriteLine("3.Ticks");
            int key = int.Parse(Console.ReadLine());
            Console.Clear();
            TypeTime typeTime;
            switch (key)
            {
                case 1:
                    typeTime = TypeTime.Milliseconds;
                    break;
                case 2:
                    typeTime = TypeTime.Seconds;
                    break;
                case 3:
                    typeTime = TypeTime.Ticks;
                    break;
                default:
                    typeTime = TypeTime.Ticks;
                    break;
            }

            return typeTime;
        }
    }
}
