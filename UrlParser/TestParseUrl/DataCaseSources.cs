using NUnit.Framework;
using ParsingInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestParseUrl
{
    class DataCaseSources
    {
        public static IEnumerable<TestCaseData> TestCaseParse
        {
            get
            {
                yield return new TestCaseData("https://github.com/AnzhelikaKravchuk?tab=repositories", new Url() { HostName = "github.com", Uri = new[] { "AnzhelikaKravchuk" }, Parameters = new Tuple<string, string>[] { Tuple.Create("tab", "repositories") } });
                yield return new TestCaseData("https://github.com/AnzhelikaKravchuk/2017-2018.MMF.BSU", new Url() { HostName = "github.com", Uri = new[] { "AnzhelikaKravchuk", "2017-2018.MMF.BSU" } });
                yield return new TestCaseData("https://habrahabr.ru/company/it-grad/blog/341486/", new Url() { HostName = "habrahabr.ru", Uri = new[] { "company", "it-grad", "blog", "341486" } });
            }
        }
    }
}
