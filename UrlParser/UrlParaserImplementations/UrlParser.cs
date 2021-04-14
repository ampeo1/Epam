using ParsingInterfaces;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace UrlParaserImplementations
{
    public class UrlParser : IUrlParser
    {
        private readonly ILogger logger;
        /*public UrlParser()
        {
            this.logger = LogManager.GetCurrentClassLogger();
        }*/

        public UrlParser(ILogger logger)
        {
            this.logger = logger;
        }

        public Url Parse(string str)
        {
            if (!str.StartsWith("https://"))
            {
                ArgumentException exception = new ArgumentException($"{nameof(str)} should start with https://", $"{nameof(str)}");
                logger.LogError(exception, exception.Message);
                throw exception;
            }

            string[] splitUrl = str[8..].Split('/');
            Url url = new Url();
            try
            {
                url.HostName = splitUrl[0];
            }
            catch(ArgumentException ex)
            {
                logger.LogError(ex, ex.Message);
                throw new ArgumentException(ex.Message, ex);
            }

            List<string> uri = new List<string>();
            for(int i = 1; i < splitUrl.Length - 1; i++)
            {
                uri.Add(splitUrl[i]);
            }

            string[] arguments = null;
            if (splitUrl[splitUrl.Length - 1].Contains('?'))
            {
                string[] pageValues = splitUrl[splitUrl.Length - 1].Split('?');
                arguments = pageValues[1].Split('=');
                uri.Add(pageValues[0]);
            }
            else if (!string.IsNullOrEmpty(splitUrl[splitUrl.Length - 1]))
            {
                uri.Add(splitUrl[splitUrl.Length - 1]);
            }

            url.Uri = uri.ToArray();
            if (arguments is null || arguments.Length == 0)
            {
                return url;
            }

            if (arguments.Length % 2 != 0)
            {
                ArgumentException exception = new ArgumentException("The number of keys is not equal to the number of values.");
                logger.LogError(exception, exception.Message);
                throw exception;
            }

            List<Tuple<string, string>> parameters = new List<Tuple<string, string>>();
            for(int i = 0; i < arguments.Length; i += 2)
            {
                parameters.Add(Tuple.Create(arguments[i], arguments[i + 1]));
            }

            url.Parameters = parameters.ToArray();
            return url;
        }
    }
}
