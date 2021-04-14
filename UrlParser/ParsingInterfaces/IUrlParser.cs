using System;

namespace ParsingInterfaces
{
    public interface IUrlParser
    {
        public Url Parse(string url);
    }
}
