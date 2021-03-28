using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTree.Tests
{
    public sealed class DataSource
    {
        public static IEnumerable<TestCaseData> TestCases
        {
            get
            {
                yield return new TestCaseData(new string[] { "12", "Zero", "Test", "Hello" }, "Hello, world!", 4, new[] { "12", "Zero", "Test", "Hello" },
                    new[] { "12", "Hello", "Hello, world!", "Test", "Zero" }, new[] { "Hello, world!", "Hello", "Test", "Zero", "12" }, null);
                yield return new TestCaseData(new int[] { 8, 3, 1, 6, 4, 7, 10, 14 }, 13, 8, new[] { 8, 3, 1, 6, 4, 7, 10, 14 }, new[] { 1, 3, 4, 6, 7, 8, 10, 13, 14 },
                    new[] { 1, 4, 7, 6, 3, 13, 14, 10, 8 }, null);
            }
        }
    }
}
