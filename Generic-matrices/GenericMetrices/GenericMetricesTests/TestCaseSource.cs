using GenericMetrices;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GenericMetricesTests
{
    public sealed class TestCaseSource
    {
        public static IEnumerable<TestCaseData> TestCaseForAddInt
        {
            get
            {
                yield return new TestCaseData(
                    new SquareMatrix<int>(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }),
                    new SquareMatrix<int>(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }),
                    new SquareMatrix<int>(new int[,] { { 2, 4, 6 }, { 8, 10, 12 }, { 14, 16, 18 } }));
                yield return new TestCaseData(
                    new SymmetricMatrix<int>(new int[][] { new[] { 1 }, new[] { 3, 2 }, new[] { 0, 6, 5 } }),
                    new DiagonalMatrix<int>(new int[] { 15, 25, 3 }),
                    new SymmetricMatrix<int>(new int[][] { new[] { 16 }, new[] { 3, 27 }, new[] { 0, 6, 8 } }));
                yield return new TestCaseData(
                    new SymmetricMatrix<int>(new int[][] { new[] { 1 }, new[] { 3, 2 }, new[] { 0, 6, 5 } }),
                    new SymmetricMatrix<int>(new int[][] { new[] { 7 }, new[] { 16, 22 }, new[] { 16, 8, 10 } }),
                    new SymmetricMatrix<int>(new int[][] { new[] { 8 }, new[] { 19, 24 }, new[] { 16, 14, 15 } }));
                yield return new TestCaseData(
                    new SquareMatrix<int>(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }),
                    new SymmetricMatrix<int>(new int[][] { new[] { 7 }, new[] { 16, 22 }, new[] { 16, 8, 10 } }),
                    new SquareMatrix<int>(new int[,] { { 8, 18, 19 }, { 20, 27, 14 }, { 23, 16, 19 } }));
            }
        }

        public static IEnumerable<TestCaseData> TestCaseForAddFloat
        {
            get
            {
                yield return new TestCaseData(
                    new SquareMatrix<float>(new float[,] { { 1.5f, 2.25f, 3.875f }, { 4.125f, 5.25f, 6.66f }, { 7.89f, 8.78f, 9 } }),
                    new DiagonalMatrix<float>(new float[] { 15.12f, 25.25f, 3.2f }),
                    new SquareMatrix<float>(new float[,] { { 16.6199989f, 2.25f, 3.875f }, { 4.125f, 30.5f, 6.66f }, { 7.89f, 8.78f, 12.2f } }));
            }
        }

        public static IEnumerable<TestCaseData> TestCaseForAddString
        {
            get
            {
                yield return new TestCaseData(
                    new SquareMatrix<string>(new string[,] { { "a", "b", "c" }, { "d", "e", "f" }, { "g", "h", "i" } }),
                    new DiagonalMatrix<string>(new string[] { "j", "k", "l" }));
            }
        }

        public static IEnumerable<TestCaseData> TestCaseForAddBool
        {
            get
            {
                yield return new TestCaseData(
                    new SquareMatrix<bool>(new bool[,] { { true, true, true }, { true, true, true }, { true, true, true } }),
                    new DiagonalMatrix<bool>(new bool[] { false, false, false }));
            }
        }
    }
}
