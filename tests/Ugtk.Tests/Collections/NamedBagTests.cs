using System;
using System.Collections.Generic;
using Ugtk.Collections;
using NFluent;

namespace Ugtk.Tests.Collections;

public sealed class NamedBagTests
{
    [Fact]
    public void Add_ShouldAddItemToCollection()
    {
        // Arrange
        var bag = new NamedBag<string>();

        // Act
        bag.Add("Item1", "Value1");

        // Assert
        Check.That(bag.GetValue("Item1")).IsEqualTo("Value1");
    }

    [Fact]
    public void Add_ShouldThrowArgumentException_WhenNameIsEmpty()
    {
        // Arrange
        var bag = new NamedBag<string>();

        // Act & Assert
        Check.ThatCode(() => bag.Add("", "Value1"))
            .Throws<ArgumentException>()
            .WithMessage("Name cannot be empty or whitespace. (Parameter 'name')");
    }

    [Fact]
    public void Add_ShouldThrowArgumentNullException_WhenItemIsNull()
    {
        // Arrange
        var bag = new NamedBag<string>();

        // Act & Assert
        Check.ThatCode(() => bag.Add("Item1", null))
            .Throws<ArgumentNullException>();
    }

    [Fact]
    public void BatchBeginAdd_ShouldClearPendingItems()
    {
        // Arrange
        var bag = new NamedBag<string>();
        bag.BatchBeginAdd().BatchAdd("Item1", "Value1");

        // Act
        bag.BatchBeginAdd();

        // Assert
        Check.ThatCode(() => bag.GetValue("Item1"))
            .Throws<KeyNotFoundException>();
    }

    [Fact]
    public void BatchAdd_ShouldAddItemsToBatch()
    {
        // Arrange
        var bag = new NamedBag<string>();
        bag.BatchBeginAdd();

        // Act
        bag.BatchAdd("Item1", "Value1").BatchAdd("Item2", "Value2");
        bag.BatchEndAdd();

        // Assert
        Check.That(bag.GetValue("Item1")).IsEqualTo("Value1");
        Check.That(bag.GetValue("Item2")).IsEqualTo("Value2");
    }

    [Fact]
    public void BatchEndAdd_ShouldSortItemsAfterAdding()
    {
        // Arrange
        var bag = new NamedBag<string>();
        bag.BatchBeginAdd()
            .BatchAdd("B", "ValueB")
            .BatchAdd("A", "ValueA");

        // Act
        bag.BatchEndAdd();

        // Assert
        Check.That(bag.GetValue("A")).IsEqualTo("ValueA");
        Check.That(bag.GetValue("B")).IsEqualTo("ValueB");
    }

    [Fact]
    public void Clear_ShouldRemoveAllItems()
    {
        // Arrange
        var bag = new NamedBag<string>();
        bag.Add("Item1", "Value1");

        // Act
        bag.Clear();

        // Assert
        Check.ThatCode(() => bag.GetValue("Item1"))
            .Throws<KeyNotFoundException>();
    }

    [Fact]
    public void GetValue_ShouldReturnItem_WhenNameExists()
    {
        // Arrange
        var bag = new NamedBag<string>();
        bag.Add("Item1", "Value1");

        // Act
        var value = bag.GetValue("Item1");

        // Assert
        Check.That(value).IsEqualTo("Value1");
    }

    [Fact]
    public void GetValue_ShouldThrowKeyNotFoundException_WhenNameDoesNotExist()
    {
        // Arrange
        var bag = new NamedBag<string>();

        // Act & Assert
        Check.ThatCode(() => bag.GetValue("NonExistent"))
            .Throws<KeyNotFoundException>()
            .WithMessage("The named item `NonExistent` cannot be found.");
    }
}
