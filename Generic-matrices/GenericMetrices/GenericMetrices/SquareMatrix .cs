using System;
using System.Collections.Generic;
using System.Text;

namespace GenericMetrices
{
    public class SquareMatrix<T> : Matrix<T>
    {
        private T[,] matrix;
        public SquareMatrix(int size) : base(size)
        {
            matrix = new T[size, size];
        }

        public SquareMatrix(T[,] matrix): base(matrix.GetUpperBound(0) + 1)
        {
            this.matrix = matrix;
        }

        public override T this[int i, int j]
        {
            get
            {
                if (i < base.size && j < base.size)
                {
                    return matrix[i, j];
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Index is not a valid.", $"{nameof(i)}, {nameof(j)}");
                }
            }
            set
            {
                if (i < base.size && j < base.size)
                {
                    matrix[i, j] = value;
                    base.onEventChanged(value);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Index is not a valid.", $"{nameof(i)}, {nameof(j)}");
                }
            }
        }
    }
}
