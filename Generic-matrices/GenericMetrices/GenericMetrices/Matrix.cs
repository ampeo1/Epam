using System;

namespace GenericMetrices
{
    abstract public class Matrix<T>
    {
        protected int size;

        public Matrix(int size)
        {
            this.size = size;
        }

        public int GetSize
        {
            get
            {
                return this.size;
            }
        }

        abstract public T this[int i, int j] { get; set; }

        public event EventHandler<DataEventArgs<T>> Changed;

        protected void onEventChanged(T newValue)
        {
            this.Changed?.Invoke(this, new DataEventArgs<T>(newValue));
        }
    }
}
