using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GenericMetrices
{
    public static class MatrixExtension
    {
        public static Matrix<T> Add<T>(this Matrix<T> first, Matrix<T> second){
            if (first is null || second is null)
            {
                throw new ArgumentNullException("argument is null", $"{nameof(first)}, {nameof(second)}");
            }

            if (first.GetSize != second.GetSize)
            {
                throw new ArgumentException("Matrix size is different", $"{nameof(first)}, {nameof(second)}");
            }

            Matrix<T> result = SetType(first, second);

            for (int i = 0; i < first.GetSize; i++)
            {
                for (int j = 0; j < first.GetSize; j++)
                {
                    try
                    {
                        result[i, j] = Add<T>()(first[i, j], second[i, j]);
                    }
                    catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException ex)
                    {
                        throw new NotSupportedException(nameof(T), ex);
                    }
                }
            }

            return result;
        }

        private static Matrix<T> SetType<T>(Matrix<T> first, Matrix<T> second)
        {
            Type typeMatrix;
            int size = first.GetSize;
            if (first.GetType() == typeof(DiagonalMatrix<T>))
            {
                typeMatrix = second.GetType();
            }
            else if (second.GetType() == typeof(DiagonalMatrix<T>))
            {
                typeMatrix = first.GetType();
            }
            else if (first.GetType() == typeof(SymmetricMatrix<T>) && second.GetType() == typeof(SymmetricMatrix<T>))
            {
                typeMatrix = typeof(SymmetricMatrix<T>);
            }
            else
            {
                typeMatrix = typeof(SquareMatrix<T>);
            }

            if (typeMatrix == typeof(DiagonalMatrix<T>))
            {
                return new DiagonalMatrix<T>(size);
            }
            else if (typeMatrix == typeof(SymmetricMatrix<T>))
            {
                return new SymmetricMatrix<T>(size);
            }
            else
            {
                return new SquareMatrix<T>(size);
            }
        }

        private static Func<T, T, T> Add<T>()
        {
            ParameterExpression paramL = Expression.Parameter(typeof(T), "lhs"),
                                paramR = Expression.Parameter(typeof(T), "rhs");
            BinaryExpression body = Expression.Add(paramL, paramR);
            Func<T, T, T> add = Expression.Lambda<Func<T, T, T>>(body, paramL, paramR).Compile();
            return add;

        }
    }
}
