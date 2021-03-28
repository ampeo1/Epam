using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTree
{
    /// <summary>
    /// Thos class links elements.
    /// </summary>
    /// <typeparam name="T">Type of node.</typeparam>
    internal class Node<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Node{T}"/> class.
        /// </summary>
        /// <param name="data">The data that the node stores.</param>
        public Node(T data)
        {
            this.Data = data;
        }

        /// <summary>
        /// Gets or sets the data that the node stores.
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Gets or sets left node.
        /// </summary>
        public Node<T> Left { get; set; } 

        /// <summary>
        /// Gets or sets right node.
        /// </summary>
        public Node<T> Right { get; set; }

        /// <summary>
        /// Gets or sets parent node.
        /// </summary>
        public Node<T> Parent { get; set; }
    }
}
