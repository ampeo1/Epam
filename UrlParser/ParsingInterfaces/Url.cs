using System;
using System.Collections.Generic;
using System.Text;

namespace ParsingInterfaces
{
    public class Url
    {
        private string hostName;
        public string HostName 
        {
            get
            {
                return hostName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException($"{nameof(value)} is null or empty", $"{nameof(value)}");
                }

                if (!value.Contains('.'))
                {
                    throw new ArgumentException($"{nameof(value)} doesn't contains domain", $"{nameof(value)}");
                }

                this.hostName = value;
            }
        }
        public string[] Uri { get; set; }
        public Tuple<string, string>[] Parameters { get; set; }
    }
}
