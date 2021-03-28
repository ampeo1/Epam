using NUnit.Framework;
using System.Collections;

namespace BinarySearchTree.Tests
{
    [TestFixture(new[] { 8, 3, 1, 6, 4, 7, 10, 14 }, 13, 8, null, TypeArgs = new Type[] {typeof(int)})]
    public class TreeTests<T>
    {
        private readonly TreeCollection<T> _tree;
        private readonly T[] _array;
        private readonly T _value;
        private readonly int _initCount;

        public TreeTests(T[] source, T value, int count, Comparer<T> comparer)
        {
            _tree = new TreeCollection<T>(comparer);
            T[] array = source;
            _value = value;
            _initCount = count;
        }

        [Test]
        [Order(0)]
        public void Ctor_BasedOnEnumerableSource()
        {
            Assert.That(_tree.Count == _initCount);
        }

        [Test]
        [Order(1)]
        public void Iterator_Test()
        {
            int i = _initCount;
            foreach (var item in _tree)
            {
                Assert.AreEqual(item, _array[--i]);
            }
        }

        /*[TestCase(new[] { 8, 3, 1, 6, 4, 7, 10, 14, 13 })]
        public void RemoveTests(int[] items)
        {
            TreeCollection<int> tree = new TreeCollection<int>();
            foreach (int item in items)
            {
                tree.Add(item);
            }

            tree.Remove(3);
        }*/
    }
}