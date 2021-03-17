using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Algorithms.Tests
{
    public sealed class TestCaseSource
    {
        public static IEnumerable<TestCaseData> TestCaseForBinarySearchInt
        {
            get
            {
                yield return new TestCaseData(new int[] { 1, 2, 3, 4, 5, 6 }, 4, (int?)3);
                yield return new TestCaseData(new int[] { 1, 3, 4, 6, 8, 9, 11 }, 0, null);
                yield return new TestCaseData(Array.Empty<int>(), 0, null);
            }
        }

        public static IEnumerable<TestCaseData> TestCaseForBinarySearchString
        {
            get
            {
                yield return new TestCaseData(new string[] { "adsgxzc", "asfgsd", "hfsd", "hshads", "sarwey", "zzz" }, "adsgxzc", (int?)0);
                yield return new TestCaseData(new string[] { "asf", "fasfasf", "fsdag", "gagsdh", "saf", "safas", "sdagdsa" }, "saf", 4);
            }
        }

        public static IEnumerable<TestCaseData> TestCaseForBinarySearchFloat
        {
            get
            {
                yield return new TestCaseData(new float[] { 12.543f, 25.124f, 124.4125f, 225.214f }, 124.4125f, (int?)2);
                yield return new TestCaseData(new float[] { 12.543f, 25.124f, 124.4125f, 225.214f }, 0, null);
            }
        }
    }
}
