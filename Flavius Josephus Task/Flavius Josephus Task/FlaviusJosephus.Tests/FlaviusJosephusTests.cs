using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Flavius_Josephus_Task;
using System;

namespace FlaviusJosephus.Tests
{
    public class FlaviusJosephusTests
    {
        [TestCase(16, 2, ExpectedResult = new[] { 2, 4, 6, 8, 10, 12, 14, 16, 3, 7, 11, 15, 5, 13, 9 })]
        [TestCase(14, 5, ExpectedResult = new[] { 5, 10, 1, 7, 13, 6, 14, 9, 4, 3, 8, 12, 2 })]
        [TestCase(16, 1, ExpectedResult = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 })]
        public IEnumerable<int> JosephusTests(int n, int k)
        {
            return Flavius.Josephus(n, k);
        }

        [Test]
        public void Josephus_ArgumentException_N()
        {
            Assert.Throws<ArgumentException>(() => Flavius.Josephus(-1, 25));
        }

        [Test]
        public void Josephus_ArgumentException_K()
        {
            Assert.Throws<ArgumentException>(() => Flavius.Josephus(22, -25));
        }
    }
}
