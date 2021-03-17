using System;
using NUnit.Framework;

namespace Algorithms.Tests
{
    [TestFixture]
    public class AlgorithmsTests
    {
        [Test]
        [TestCaseSource(typeof(TestCaseSource), nameof(TestCaseSource.TestCaseForBinarySearchInt))]
        public void BinarySeachTests(int[] array, int item, int? result)
        {
            int? actual = BinarySearch.Algorithms.BinarySearch(array, item);
            Assert.AreEqual(result, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestCaseSource), nameof(TestCaseSource.TestCaseForBinarySearchString))]
        public void BinarySeachTests(string[] array, string item, int? result)
        {
            int? actual = BinarySearch.Algorithms.BinarySearch(array, item);
            Assert.AreEqual(result, actual);
        }

        [Test]
        [TestCaseSource(typeof(TestCaseSource), nameof(TestCaseSource.TestCaseForBinarySearchFloat))]
        public void BinarySeachTests(float[] array, float item, int? result)
        {
            int? actual = BinarySearch.Algorithms.BinarySearch(array, item);
            Assert.AreEqual(result, actual);
        }

        [Test]
        public void BinarySearchArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => BinarySearch.Algorithms.BinarySearch(null, "s"));
            Assert.Throws<ArgumentNullException>(() => BinarySearch.Algorithms.BinarySearch(Array.Empty<string>(), null));
        }
    }
}
