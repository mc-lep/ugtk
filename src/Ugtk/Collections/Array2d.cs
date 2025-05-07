using System;
using System.Collections;
using System.Collections.Generic;

namespace Ugtk.Collections
{
    public sealed class Array2d<T> : IEnumerable<T>
    {
        private readonly T[] _items;
        private readonly int _columnsCount;
        private readonly int _rowsCount;

        public T this[int col, int row] { get => _items[col + row * _columnsCount]; set => _items[col + row * _columnsCount] = value; }
        public int ColumnsCount => _columnsCount;
        public int RowsCount => _rowsCount;

        public Array2d(int columnsCount, int rowsCount)
        {
            if (columnsCount < 0) throw new ArgumentException("The number of columns must be greater than zero", nameof(columnsCount));
            if (rowsCount < 0) throw new ArgumentException("The number of rows must be greater than zero", nameof(rowsCount));

            _items = new T[columnsCount * rowsCount];
            _columnsCount = columnsCount;
            _rowsCount = rowsCount;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return (IEnumerator<T>)_items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _items.GetEnumerator();
        }
    }
}
