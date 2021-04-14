using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ParsingInterfaces;
using System;
using System.Collections.Generic;
using UrlParaserImplementations;
using Writers;

namespace UrlParserApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using IHost host = createHostBuilder(args).Build();
            UrlParser parser = host.Services.GetRequiredService<UrlParser>();
            List<Url> urls = new List<Url>();
            urls.Add(parser.Parse("https://github.com/AnzhelikaKravchuk?tab=repositories"));
            urls.Add(parser.Parse("https://github.com/AnzhelikaKravchuk/2017-2018.MMF.BSU"));
            urls.Add(parser.Parse("https://habrahabr.ru/company/it-grad/blog/341486/"));
            SaveXml saveXml = new SaveXml();
            saveXml.Save(urls.ToArray(), "d:\\EPAM\\test.xml");
        }

        static IHostBuilder createHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureServices((_, services) => 
            services.AddSingleton<ILoggerFactory, LoggerFactory>()
                    .AddSingleton<ILogger, Logger<UrlParser>>()
                    .AddTransient<UrlParser>());
        }
    }
}
