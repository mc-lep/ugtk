using FluentAssertions;
using System;
using Ugtk.Collections;

namespace Ugtk.Tests.Collections
{
    public sealed class BagTests
    {
        [Theory]
        [InlineData(-1)]
        [InlineData(10)]
        public void RemoveAt_WithInvalidIndex_ShouldThrowIndexOutOfRangeException(int index)
        {
            Bag<int> sut = BuildBag();

            // Act

            Action action = () => sut.RemoveAt(index);

            // Assert

            action.Should().Throw<IndexOutOfRangeException>();
        }

        [Fact]
        public void RemoveAt_WithValidIndex_ShouldRemoveAnItem()
        {
            Bag<int> sut = BuildBag();

            // Act

            sut.RemoveAt(5);

            // Assert

            sut.Should().HaveCount(9);
        }

        [Fact]
        public void RemoveAt_WithValidIndex_ShouldReplaceItemWithTheLastOne()
        {
            Bag<int> sut = BuildBag();

            // Act

            sut.RemoveAt(5);

            // Assert

            sut.Should().HaveElementAt(5, 9);
        }

        private static Bag<int> BuildBag()
        {
            // Arrange

            var bag = new Bag<int>();
            for (int i = 0; i < 10; i++)
            {
                bag.Add(i);
            }

            return bag;
        }
    }
}
