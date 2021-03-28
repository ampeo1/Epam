using BookClass;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BinarySearchTree.Tests
{
    [TestFixture(new[] { "12", "Zero", "Test", "Hello" }, "Hello, world!", 4, new[] { "12", "Zero", "Test", "Hello" }, 
        new[] { "12", "Hello", "Hello, world!", "Test", "Zero" }, new[] { "Hello, world!", "Hello", "Test", "Zero", "12" }, 
        null, TypeArgs = new Type[] { typeof(string) })]
    [TestFixture(new[] { 8, 3, 1, 6, 4, 7, 10, 14 }, 13, 8, new[] { 8, 3, 1, 6, 4, 7, 10, 14 }, new[] { 1, 3, 4, 6, 7, 8, 10, 13, 14 }, 
        new[] { 1, 4, 7, 6, 3, 13, 14, 10, 8 }, null, TypeArgs = new Type[] {typeof(int)})]
    public class TreeTests<T>
    {
        private readonly TreeCollection<T> _tree;
        private readonly T[] NLR;
        private readonly T[] LNR;
        private readonly T[] LRN;
        private readonly T[] _array;
        private readonly T _value;
        private readonly int _initCount;

        public TreeTests(T[] source, T value, int count, T[] NLR, T[] LNR, T[] LRN, Comparer<T> comparer)
        {
            _tree = new TreeCollection<T>(source, comparer);
            _array = source;
            _value = value;
            _initCount = count;
            this.NLR = NLR;
            this.LNR = LNR;
            this.LRN = LRN;
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
            int i = 0;
            foreach (var item in _tree)
            {
                Assert.AreEqual(item, _array[i++]);
            }

            Assert.IsTrue(i == _initCount);
        }

        [Test]
        [Order(2)]
        public void ToCopy_Test()
        {
            T[] copy = new T[_tree.Count];
            _tree.CopyTo(copy, 0);
            Assert.Multiple((() =>
            {
                CollectionAssert.AreEqual(_array, copy);
                Assert.AreNotSame(_array, copy);
            }));
        }

        [Test]
        [Order(3)]
        public void Add_OneElement()
        {
            int count = _tree.Count;
            _tree.Add(_value);
            Assert.Multiple(() =>
            {
                CollectionAssert.Contains(_tree, _value);
                Assert.That(_tree.Count == count + 1);
            });
        }

        [Test]
        [Order(4)]
        public void Contains_Test()
        {
            Assert.IsTrue(_tree.Contains(_value));
        }

        [Test]
        [Order(5)]
        public void LNR_Test()
        {
            IEnumerable<T> result = _tree.LNR();
            Assert.AreEqual(LNR, _tree.LNR());
        }

        [Test]
        [Order(6)]
        public void LRN_Test()
        {
            IEnumerable<T> result = _tree.LRN();
            Assert.AreEqual(LRN, _tree.LRN());
        }

        [Test]
        [Order(7)]
        public void Remove_Test()
        {
            int count = _tree.Count;
            _tree.Remove(_value);
            Assert.Multiple(() =>
            {
                Assert.That(_tree.Count == count - 1);
            });
        }

        [Test]
        [Order(8)]
        public void NLR_Test()
        {
            IEnumerable<T> result = _tree.NLR();
            Assert.AreEqual(NLR, _tree.NLR());
        }
    }
}