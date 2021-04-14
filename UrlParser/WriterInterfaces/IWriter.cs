using ParsingInterfaces;
using System;

namespace WriterInterfaces
{
    public interface IWriter
    {
        public void Save(Url[] url, string path);
    }
}
