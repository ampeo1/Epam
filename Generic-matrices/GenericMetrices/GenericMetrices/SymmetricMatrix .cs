using System;
using System.Collections.Generic;
using System.Text;

namespace GenericMetrices
{
    public class SymmetricMatrix<T> : Matrix<T>
    {
        private T[][] matrix;
        public SymmetricMatrix(int size) : base(size){
            matrix = new T[size][];

            for (int i = 0; i < size; i++)
            {
                matrix[i] = new T[i + 1];
            }
        }

        public SymmetricMatrix(T[][] matrix) : base(matrix.Length)
        {
            this.matrix = matrix;
        }

        public override T this[int i, int j] 
        {
            get 
            { 
                if (i < base.size && j < base.size)
                {
                    if (j > i)
                    {
                        (j, i) = (i, j);
                    }

                    return matrix[i][j];
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
                    if (j > i)
                    {
                        (j, i) = (i, j);
                    }

                    matrix[i][j] = value;
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
