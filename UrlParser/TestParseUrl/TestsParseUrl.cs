using NUnit.Framework;
using ParsingInterfaces;
using UrlParaserImplementations;
using Moq;
using Microsoft.Extensions.Logging;

namespace TestParseUrl
{
    public class TestsParseUrl
    {
        [TestCaseSource(typeof(DataCaseSources), nameof(DataCaseSources.TestCaseParse))]
        public void TestParseUrl(string url, Url expected)
        {
            Mock mock = new Mock<ILogger>();
            UrlParser parser = new UrlParser((ILogger)mock.Object);
            Url result = parser.Parse(url);
            Assert.AreEqual(expected.HostName, result.HostName);
            CollectionAssert.AreEqual(expected.Uri, result.Uri);
            CollectionAssert.AreEqual(expected.Parameters, result.Parameters);
        }
    }
}