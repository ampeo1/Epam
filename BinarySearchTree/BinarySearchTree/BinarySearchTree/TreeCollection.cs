using System;
using System.Collections;
using System.Collections.Generic;

namespace BinarySearchTree
{
    /// <summary>
    /// Binary search tree.
    /// </summary>
    /// <typeparam name="T">The type tree.</typeparam>
    public sealed class TreeCollection<T> : ICollection<T>
    {
        private readonly Comparer<T> comparer;
        private Node<T> root;
        private int count;

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeCollection{T}"/> class.
        /// </summary>
        /// <param name="comparer">Comparator.</param>
        public TreeCollection(Comparer<T> comparer = null)
        {
            if (comparer is null)
            {
                if (Comparer<T>.Default is null)
                {
                    throw new ArgumentException($"Comparer is undefined", $"{nameof(comparer)}");
                }
                else
                {
                    comparer = Comparer<T>.Default;
                }
            }

            this.comparer = comparer;
            this.count = 0;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TreeCollection{T}"/> class.
        /// </summary>
        /// <param name="source">Source array.</param>
        /// <param name="comparer">Comparator.</param>
        public TreeCollection(T[] source, Comparer<T> comparer = null)
        {
            if (source is null)
            {
                throw new ArgumentNullException($"{nameof(source)}");
            }

            if (comparer is null)
            {
                if (Comparer<T>.Default is null)
                {
                    throw new ArgumentException($"Comparer is undefined", $"{nameof(comparer)}");
                }
                else
                {
                    comparer = Comparer<T>.Default;
                }
            }

            this.comparer = comparer;
            this.count = 0;
            foreach (var item in source)
            {
                this.Add(item);
            }
        }

        /// <summary>
        /// Gets count of elements.
        /// </summary>
        public int Count
        {
            get => this.count;
        }

        /// <summary>
        /// Gets a value indicating whether the collection is readonly.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Adds item in tree.
        /// </summary>
        /// <param name="data">item which need add.</param>
        /// <exception cref="ArgumentNullException">Throws when <see cref="data"/> is null.</exception>
        public void Add(T data)
        {
            if (data is null)
            {
                throw new ArgumentNullException($"{data}");
            }

            if (this.root is null)
            {
                this.root = new Node<T>(data);
            }
            else
            {
                this.Add(data, this.root);
            }

            this.count++;
        }

        /// <summary>
        /// Preorder tree traversal.
        /// </summary>
        /// <returns>Tree elements.</returns>
        public IEnumerable<T> NLR()
        {
            return this.NLR(this.root);
        }

        /// <summary>
        /// Inorder tree traversal.
        /// </summary>
        /// <returns>Tree elements.</returns>
        public IEnumerable<T> LNR()
        {
            return this.LNR(this.root);
        }

        /// <summary>
        /// Postorder tree traversal.
        /// </summary>
        /// <returns>Tree elements.</returns>
        public IEnumerable<T> LRN()
        {
            return this.LRN(this.root);
        }

        /// <summary>
        /// Removes all elements.
        /// </summary>
        public void Clear()
        {
            this.count = 0;
            this.root = null;
        }

        /// <summary>
        /// Checks if an element contains.
        /// </summary>
        /// <param name="item">Element which need to find.</param>
        /// <returns>True if contains; otherwise false.</returns>
        public bool Contains(T item)
        {
            if (item is null)
            {
                throw new ArgumentNullException($"{nameof(item)}");
            }

            return this.Contains(this.root, item) != null;
        }

        /// <summary>
        /// Copies elements to an array.
        /// </summary>
        /// <param name="array">To which you want to copy.</param>
        /// <param name="arrayIndex">Starting from the index.</param>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0)
            {
                throw new ArgumentException($"{nameof(arrayIndex)} is less than 0", $"{nameof(arrayIndex)}");
            }

            if (array is null)
            {
                throw new ArgumentNullException($"{nameof(array)}");
            }

            int index = 0;
            foreach (T item in this.NLR())
            {
                if (arrayIndex == 0 && index != array.Length)
                {
                    array[index] = item;
                    index++;
                }
                else
                {
                    arrayIndex--;
                }
            }
        }

        /// <summary>
        /// Remove element.
        /// </summary>
        /// <param name="item">Element which need remove.</param>
        /// <returns>True if remove; otherwise false.</returns>
        public bool Remove(T item)
        {
            if (item is null)
            {
                throw new ArgumentNullException($"{nameof(item)}");
            }

            Node<T> node = this.Contains(this.root, item);
            if (node is null)
            {
                return false;
            }

            this.count--;
            if (node.Left is null && node.Right is null)
            {
                this.DeleteNode(node, null);
                return true;
            }

            if (node.Left is null)
            {
                this.DeleteNode(node, node.Right);
                return true;
            }

            if (node.Right is null)
            {
                this.DeleteNode(node, node.Left);
                return true;
            }

            this.DeleteNode(node);

            return true;
        }

        /// <summary>
        ///  Returns an enumerator for the tree.
        /// </summary>
        /// <returns>Return Enumerator object for the tree.</returns>
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this.NLR().GetEnumerator();
        }

        /// <summary>
        ///  Returns an enumerator for the tree.
        /// </summary>
        /// <returns>Return Enumerator object for the tree.</returns>
        public IEnumerator GetEnumerator()
        {
            return this.NLR().GetEnumerator();
        }

        private void Add(T data, Node<T> node)
        {
            if (this.comparer.Compare(data, node.Data) == -1)
            {
                if (node.Left is null)
                {
                    node.Left = new Node<T>(data);
                    node.Left.Parent = node;
                }
                else
                {
                    this.Add(data, node.Left);
                }
            }
            else
            {
                if (node.Right is null)
                {
                    node.Right = new Node<T>(data);
                    node.Right.Parent = node;
                }
                else
                {
                    this.Add(data, node.Right);
                }
            }
        }

        private Node<T> Contains(Node<T> node, T data)
        {
            if (node is null)
            {
                return null;
            }

            int result = this.comparer.Compare(data, node.Data);
            if (result == 0)
            {
                return node;
            }

            if (result == 1)
            {
                return this.Contains(node.Right, data);
            }
            else
            {
                return this.Contains(node.Left, data);
            }
        }

        /*private void DeleteNode(Node<T> node)
        {
            Node<T> parent = node.Parent;
            if (!(parent.Left is null) && this.comparer.Compare(parent.Left.Data, node.Data) == 0)
            {
                parent.Left = null;
            }
            else if (!(parent.Right is null) && this.comparer.Compare(parent.Right.Data, node.Data) == 0)
            {
                parent.Right = null;
            }
        }*/

        private void DeleteNode(Node<T> node, Node<T> child)
        {
            Node<T> parent = node.Parent;
            if (!(parent.Left is null) && this.comparer.Compare(parent.Left.Data, node.Data) == 0)
            {
                parent.Left = child;
            }
            else if (!(parent.Right is null) && this.comparer.Compare(parent.Right.Data, node.Data) == 0)
            {
                parent.Right = child;
            }

            if (!(child is null))
            {
                child.Parent = parent;
            }

            node = null;
        }

        private void DeleteNode(Node<T> node)
        {
            Node<T> insertNode;
            Node<T> parent = node.Parent;
            if (node.Right.Left is null)
            {
                insertNode = node.Right;
                this.Remove(node.Right.Data);
            }
            else
            {
                insertNode = node.Right.Left;
                this.Remove(node.Right.Left.Data);
            }

            if (this.comparer.Compare(parent.Left.Data, node.Data) == 0)
            {
                parent.Left = insertNode;
            }
            else
            {
                parent.Right = insertNode;
            }

            insertNode.Parent = parent;
            insertNode.Left = node.Left;
            insertNode.Right = node.Right;
            node = null;
        }

        private IEnumerable<T> NLR(Node<T> node)
        {
            if (!(node is null))
            {
                yield return node.Data;
                foreach (var item in this.NLR(node.Left))
                {
                    yield return item;
                }

                foreach (var item in this.NLR(node.Right))
                {
                    yield return item;
                }
            }
        }

        private IEnumerable<T> LNR(Node<T> node)
        {
            if (!(node is null))
            {
                foreach (var item in this.LNR(node.Left))
                {
                    yield return item;
                }

                yield return node.Data;
                foreach (var item in this.LNR(node.Right))
                {
                    yield return item;
                }
            }
        }

        private IEnumerable<T> LRN(Node<T> node)
        {
            if (!(node is null))
            {
                foreach (var item in this.LRN(node.Left))
                {
                    yield return item;
                }

                foreach (var item in this.LRN(node.Right))
                {
                    yield return item;
                }

                yield return node.Data;
            }
        }
    }
}
