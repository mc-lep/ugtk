using System;
using System.Collections;
using System.Collections.Generic;

namespace Ugtk.Collections;

/// <summary>
/// Store objects in a 2 dimensional array
/// </summary>
/// <typeparam name="T">The type of object to store in the array</typeparam>
public sealed class Array2d<T> : IEnumerable<T>
{
    private readonly T[] _items;

    /// <summary>
    /// Get or the objects at a given position
    /// </summary>
    /// <param name="col">The index of the columns</param>
    /// <param name="row">The index of the row</param>
    /// <returns>The object stored at the requested position</returns>
    public T this[int col, int row]
    {
        get => _items[col + (row * ColumnsCount)];
        set => _items[col + (row * ColumnsCount)] = value;
    }

    /// <summary>
    /// The numbers of columns of the array
    /// </summary>
    public int ColumnsCount { get; }

    /// <summary>
    /// The numbers of rows of the array
    /// </summary>
    public int RowsCount { get; }

    /// <summary>
    /// Contruct a new 2d array
    /// </summary>
    /// <param name="columnsCount">The number of columns</param>
    /// <param name="rowsCount">The number of rows</param>
    /// <exception cref="ArgumentException"></exception>
    public Array2d(int columnsCount, int rowsCount)
    {
        if (columnsCount <= 0) throw new ArgumentException("The number of columns must be greater than zero", nameof(columnsCount));
        if (rowsCount <= 0) throw new ArgumentException("The number of rows must be greater than zero", nameof(rowsCount));

        _items = new T[columnsCount * rowsCount];
        ColumnsCount = columnsCount;
        RowsCount = rowsCount;
    }

    /// <summary>
    /// Get the array enumerator
    /// </summary>
    /// <returns>An enumerator</returns>
    public IEnumerator<T> GetEnumerator()
    {
        return ((IEnumerable<T>)_items).GetEnumerator();
    }

    /// <summary>
    /// Get the array enumerator
    /// </summary>
    /// <returns>An enumerator</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return _items.GetEnumerator();
    }
}
