using GenericMetrices;
using NUnit.Framework;
using System;

namespace GenericMetricesTests
{
    public class TestMatrixExtension
    {
        [TestCaseSource(typeof(TestCaseSource), nameof(TestCaseSource.TestCaseForAddInt))]
        public void TestAddForInt(Matrix<int> first, Matrix<int> second, Matrix<int> result)
        {
            Matrix<int> actual = first.Add(second);
            Assert.AreEqual(result.GetType(), actual.GetType());
            for (int i = 0; i < actual.GetSize; i++)
            {
                for (int j = 0; j < actual.GetSize; j++)
                {
                    Assert.AreEqual(result[i, j], actual[i, j]);
                }
            }
        }

        [TestCaseSource(typeof(TestCaseSource), nameof(TestCaseSource.TestCaseForAddFloat))]
        public void TestAddForFloat(Matrix<float> first, Matrix<float> second, Matrix<float> result)
        {
            Matrix<float> actual = first.Add(second);
            Assert.AreEqual(result.GetType(), actual.GetType());
            for (int i = 0; i < actual.GetSize; i++)
            {
                for (int j = 0; j < actual.GetSize; j++)
                {
                    Assert.AreEqual(result[i, j], actual[i, j]);
                }
            }
        }

        [TestCaseSource(typeof(TestCaseSource), nameof(TestCaseSource.TestCaseForAddString))]
        public void TestAddForString(Matrix<string> first, Matrix<string> second) => Assert.Throws<InvalidOperationException>(() => first.Add(second));

        [TestCaseSource(typeof(TestCaseSource), nameof(TestCaseSource.TestCaseForAddBool))]
        public void TestAddForBool(Matrix<bool> first, Matrix<bool> second) => Assert.Throws<InvalidOperationException>(() => first.Add(second));
    }
}