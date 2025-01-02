using System;
using System.Collections;
using System.Collections.Generic;

namespace Ugtk.Collections
{
    /// <summary>
    /// A collection of objects that can be accessed by index with fast removing of objects, but the order of added objects is not respected
    /// </summary>
    /// <typeparam name="T">The type of objects to be stored in the collection</typeparam>
    public sealed class Bag<T> : IList<T>
    {
        private readonly List<T> _items = [];

        /// <summary>
        /// Get or set an object at the given index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The object stored at the index</returns>
        public T this[int index] { get => _items[index]; set => _items[index] = value; }

        /// <summary>
        /// The number of object stored in the collection
        /// </summary>
        public int Count => _items.Count;

        /// <summary>
        /// Is the collection is readonly (false)
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Add a new item in the collection
        /// </summary>
        /// <param name="item">The item to add</param>
        public void Add(T item) => _items.Add(item);
        
        /// <summary>
        /// Clear the collection
        /// </summary>
        public void Clear() => _items.Clear();
       
        /// <summary>
        /// Is the colelction contains the item ?
        /// </summary>
        /// <param name="item">The item to search</param>
        /// <returns>True if the item is found, otherwise false</returns>
        public bool Contains(T item) => _items.Contains(item);
        
        /// <summary>
        /// Copy the collection to an array
        /// </summary>
        /// <param name="array">The destination array></param>
        /// <param name="arrayIndex">The starting index in the destination array</param>
        public void CopyTo(T[] array, int arrayIndex) => _items.CopyTo(array, arrayIndex);
       
        /// <summary>
        /// Get the enumerator of the collection
        /// </summary>
        /// <returns>An enumerator</returns>
        public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();
       
        /// <summary>
        /// Return the index of the item
        /// </summary>
        /// <param name="item">The item to be searched</param>
        /// <returns>The index</returns>
        public int IndexOf(T item) => _items.IndexOf(item);
        
        /// <summary>
        /// Insert an item at a given index
        /// </summary>
        /// <param name="index">The index where the item must be inserted</param>
        /// <param name="item">The item to be inserted</param>
        public void Insert(int index, T item) => _items.Insert(index, item);
       
        /// <summary>
        /// Remove the item from the collection
        /// </summary>
        /// <param name="item">The item to remove</param>
        /// <returns>True if the item is removed otherwies false</returns>
        public bool Remove(T item)
        {
            var index = IndexOf(item);

            if (index < 0)
            {
                return false;
            }

            RemoveAt(index);
            return true;
        }

        /// <summary>
        /// Remove an item at the given position
        /// </summary>
        /// <param name="index">The index of the item to remove</param>
        /// <exception cref="IndexOutOfRangeException">When index is out of range</exception>
        public void RemoveAt(int index)
        {
            var lastIndex = _items.Count - 1;

            if (index < 0 || index > lastIndex)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            _items[index] = _items[lastIndex];
            _items.RemoveAt(lastIndex);
        }
        
        /// <summary>
        /// Get the enumerator of the collection
        /// </summary>
        /// <returns>An enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();
    }
}
