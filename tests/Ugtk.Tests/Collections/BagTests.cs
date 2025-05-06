using NFluent;
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

            void action() => sut.RemoveAt(index);

            // Assert

            Check.ThatCode(action).Throws<IndexOutOfRangeException>();
        }

        [Fact]
        public void RemoveAt_WithValidIndex_ShouldRemoveAnItem()
        {
            Bag<int> sut = BuildBag();

            // Act

            sut.RemoveAt(5);

            // Assert

            Check.That(sut).ContainsExactly(0, 1, 2, 3, 4, 9, 6, 7, 8);
        }

        [Fact]
        public void RemoveAt_WithValidIndex_ShouldReplaceItemWithTheLastOne()
        {
            Bag<int> sut = BuildBag();

            // Act

            sut.RemoveAt(5);

            // Assert

            Check.That(sut).ContainsExactly(0, 1, 2, 3, 4, 9, 6, 7, 8);
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
