using System;
using System.Collections.Generic;

namespace Ugtk.Collections;


/// <summary>
/// Represents a collection of named items that supports fast retrieval by name.
/// </summary>
/// <typeparam name="TItem">The type of items stored in the collection.</typeparam>
public sealed class NamedBag<TItem>
{
    /// <summary>
    /// Represents an item with a name and a value.
    /// </summary>
    private readonly struct NamedItem<T>(string name, T? item) : IComparable<NamedItem<T>>
    {
        public readonly string Name = name;
        public readonly T Item = item!;

        /// <summary>
        /// Initializes a new instance of the <see cref="NamedItem{T}"/> struct with a name.
        /// </summary>
        /// <param name="name">The name of the item.</param>
        public NamedItem(string name) : this(name, default) { }

        /// <summary>
        /// Compares the current instance with another <see cref="NamedItem{T}"/> based on the name.
        /// </summary>
        /// <param name="other">The other named item to compare.</param>
        /// <returns>An integer indicating the relative order of the items.</returns>
        public int CompareTo(NamedItem<T> other)
        {
            return Name.CompareTo(other.Name);
        }
    }

    private readonly List<NamedItem<TItem>> _items = [];
    private readonly List<string> _namesToBeAdded= [];
    private readonly List<TItem> _itemsToBeAdded = [];

    /// <summary>
    /// Adds a new item to the collection.
    /// </summary>
    /// <param name="name">The name of the item.</param>
    /// <param name="item">The item to add.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="name"/> or <paramref name="item"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown if <paramref name="name"/> is empty or whitespace.</exception>
    public void Add(string name, TItem item)
    {
        Add(name, item, true);
    }

    /// <summary>
    /// Adds a new item to the collection.
    /// </summary>
    /// <param name="name">The name of the item.</param>
    /// <param name="item">The item to add.</param>
    /// <param name="mustSort">Indicates whether the collection should be sorted after adding the item.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="name"/> or <paramref name="item"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown if <paramref name="name"/> is empty or whitespace.</exception>
    private void Add(string name, TItem item, bool mustSort)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot be empty or whitespace.", nameof(name));
        }

        ArgumentNullException.ThrowIfNull(item);

        _items.Add(new NamedItem<TItem>(name, item));

        if (mustSort)
        {
            _items.Sort();
        }
    }

    /// <summary>
    /// Begins a batch operation for adding items to the collection.
    /// </summary>
    public NamedBag<TItem> BatchBeginAdd()
    {
        _namesToBeAdded.Clear();
        _itemsToBeAdded.Clear();

        return this;
    }

    /// <summary>
    /// Adds a new item to the batch.
    /// </summary>
    /// <param name="name">The name of the item.</param>
    /// <param name="item">The item to add.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="name"/> or <paramref name="item"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown if <paramref name="name"/> is empty or whitespace.</exception>
    public NamedBag<TItem> BatchAdd(string name, TItem item)
    {
        _namesToBeAdded.Add(name);
        _itemsToBeAdded.Add(item);

        return this;
    }

    /// <summary>
    /// Ends the batch operation and adds all items to the collection.
    /// </summary>
    public void BatchEndAdd()
    {
        for(int i = 0; i < _namesToBeAdded.Count; i++)
        {
            Add(_namesToBeAdded[i], _itemsToBeAdded[i], false);
        }

        _items.Sort();
    }

    /// <summary>
    /// Removes all items from the collection.
    /// </summary>
    public void Clear()
    {
        _items.Clear();
    }

    /// <summary>
    /// Retrieves an item by its name.
    /// </summary>
    /// <param name="name">The name of the item to retrieve.</param>
    /// <returns>The item associated with the specified name.</returns>
    /// <exception cref="KeyNotFoundException">Thrown if no item with the specified name exists.</exception>
    public TItem GetValue(string name)
    {
        var index = _items.BinarySearch(new NamedItem<TItem>(name));
        if (index < 0)
        {
            throw new KeyNotFoundException($"The named item `{name}` cannot be found.");
        }

        return _items[index].Item;
    }
}
