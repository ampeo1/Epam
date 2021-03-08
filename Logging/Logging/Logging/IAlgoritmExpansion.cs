using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
//using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;

namespace Logging
{
    public static class IAlgoritmExpansion
    {
        public static long GetLeadTime(this IAlgorithm algorithm, int first, int second, TypeTime typeTime = TypeTime.Ticks)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            algorithm.Calculate(first, second);
            stopwatch.Stop();

            return typeTime switch
            {
                TypeTime.Milliseconds => stopwatch.ElapsedMilliseconds,
                TypeTime.Seconds => stopwatch.ElapsedMilliseconds * 1000,
                TypeTime.Ticks => stopwatch.ElapsedTicks,
                _ => stopwatch.ElapsedTicks
            };
        }

        public static void Logging(this IAlgorithm algorithm, int first, int second, ILoggerProvider provider)
        {
            ILoggerFactory loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(provider);
            ILogger logger = loggerFactory.CreateLogger<IAlgorithm>();
            logger.LogDebug($"first argument = {first} second argument = {second}");
            try
            {
                long ticks = algorithm.GetLeadTime(first, second);
                logger.LogInformation($"finished for {ticks} ticks");
            }
            catch(Exception ex)
            {
                logger.LogError("GetLeadTime method", ex.Message);
            }
        }
    }
}
