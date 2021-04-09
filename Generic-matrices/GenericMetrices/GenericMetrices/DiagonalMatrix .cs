using System;
using System.Collections.Generic;
using System.Text;

namespace GenericMetrices
{
    public class DiagonalMatrix<T> : Matrix<T>
    {
        private T[] diagonal;
        public DiagonalMatrix(int size) : base(size)
        {
            this.diagonal = new T[size];
        }

        public DiagonalMatrix(T[] diagonal) : base(diagonal.Length)
        {
            this.diagonal = diagonal;
        }

        public override T this[int i, int j]
        {
            get
            {
                if (i < base.size && j < base.size)
                {
                    return i == j ? this.diagonal[i]: default(T);
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Index is not a valid.", $"{nameof(i)}, {nameof(j)}");
                }
            }
            set
            {
                if (i < base.size)
                {
                    if (i == j)
                    {
                        this.diagonal[i] = value;
                        base.onEventChanged(value);
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Index is not a valid.", $"{nameof(i)}, {nameof(j)}");
                }
            }
        }
    }
}
