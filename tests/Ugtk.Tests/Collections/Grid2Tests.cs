using System;
using System.Linq;
using Ugtk.Collections;
using Xunit;
using NFluent;

namespace Ugtk.Tests.Collections
{
    public sealed class Grid2Tests
    {
        [Theory]
        [InlineData(3, 2)]
        [InlineData(5, 5)]
        [InlineData(1, 10)]
        public void Constructor_ShouldInitializeArray_WithCorrectDimensions(int columns, int rows)
        {
            // Act
            var array2d = new Grid2<int>(columns, rows);

            // Assert
            Check.That(array2d.ColumnsCount).IsEqualTo(columns);
            Check.That(array2d.RowsCount).IsEqualTo(rows);
        }

        [Theory]
        [InlineData(-1, 2)]
        [InlineData(3, -1)]
        [InlineData(0, 0)]
        public void Constructor_ShouldThrowArgumentException_WhenDimensionsAreInvalid(int columns, int rows)
        {
            // Act & Assert
            Check.ThatCode(() => new Grid2<int>(columns, rows))
                .Throws<ArgumentException>();
        }

        [Fact]
        public void Indexer_ShouldSetAndGetValuesCorrectly()
        {
            // Arrange
            var array2d = new Grid2<string>(2, 2);
            var value = "TestValue";

            // Act
            array2d[1, 1] = value;

            // Assert
            Check.That(array2d[1, 1]).IsEqualTo(value);
        }

        [Fact]
        public void Indexer_ShouldThrowIndexOutOfRangeException_WhenAccessingInvalidIndex()
        {
            // Arrange
            var array2d = new Grid2<int>(2, 2);

            // Act & Assert
            Check.ThatCode(() => array2d[2, 2] = 42)
                .Throws<IndexOutOfRangeException>();
        }

        [Fact]
        public void GetEnumerator_ShouldEnumerateAllItems()
        {
            // Arrange

            var array2d = new Grid2<int>(2, 2);
            array2d[0, 0] = 1;
            array2d[1, 0] = 2;
            array2d[0, 1] = 3;
            array2d[1, 1] = 4;

            // Act

            var items = array2d.ToList();

            // Assert

            Check.That(items).ContainsExactly(1, 2, 3, 4);
        }
    }
}
