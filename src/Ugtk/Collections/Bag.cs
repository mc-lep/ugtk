using System;
using System.Collections;
using System.Collections.Generic;

namespace Ugtk.Collections
{
    /// <summary>
    /// A collection of objects that can be accessed by index, but the order of added objects is not respected
    /// </summary>
    /// <typeparam name="T">The type of objects to be stored in the collection</typeparam>
    public sealed class Bag<T> : IList<T>
    {
        private readonly List<T> _items = [];

        public T this[int index] { get => _items[index]; set => _items[index] = value; }

        public int Count => _items.Count;

        public bool IsReadOnly => false;

        public void Add(T item) => _items.Add(item);
        
        public void Clear() => _items.Clear();
       
        public bool Contains(T item) => _items.Contains(item);
        
        public void CopyTo(T[] array, int arrayIndex) => _items.CopyTo(array, arrayIndex);
       
        public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();
       
        public int IndexOf(T item) => _items.IndexOf(item);
        
        public void Insert(int index, T item) => _items.Insert(index, item);
       
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

        IEnumerator IEnumerable.GetEnumerator() => _items.GetEnumerator();
    }
}
