using BinarySearch;
using NUnit.Framework;
using System;

namespace Algorithms.Tests
{
    [TestFixture]
    public class AlgorithmsTests
    {
        [Test]
        [TestCaseSource(typeof(TestCaseSource), nameof(TestCaseSource.TestCaseForBinarySearchInt))]
        public void BinarySeachTests(int[] array, int item, int? result)
        {
            Algorithms<int> algorithms = new Algorithms<int>();
            int? actual = algorithms.BinarySearch(array, item);
            Assert.AreEqual(result, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestCaseSource), nameof(TestCaseSource.TestCaseForBinarySearchString))]
        public void BinarySeachTests(string[] array, string item, int? result)
        {
            Algorithms<string> algorithms = new Algorithms<string>();
            int? actual = algorithms.BinarySearch(array, item);
            Assert.AreEqual(result, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestCaseSource), nameof(TestCaseSource.TestCaseForBinarySearchFloat))]
        public void BinarySeachTests(float[] array, float item, int? result)
        {
            Algorithms<float> algorithms = new Algorithms<float>();
            int? actual = algorithms.BinarySearch(array, item);
            Assert.AreEqual(result, actual);
        }

        [Test]
        public void BinarySearchArgumentNullException()
        {
            Algorithms<string> algorithms = new Algorithms<string>();
            Assert.Throws<ArgumentNullException>(() => algorithms.BinarySearch(null, "s"));
            Assert.Throws<ArgumentNullException>(() => algorithms.BinarySearch(Array.Empty<string>(), null));
        }
    }
}
