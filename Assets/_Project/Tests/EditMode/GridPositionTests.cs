using NUnit.Framework;
using FutharksAdventure.Core;
using System.Collections.Generic;


namespace FutharksAdventure.Tests
{
    public class GridPositionTests
    {
        [Test]
        public void Add_TwoPositions_AddsCoordinates()
        {
            // Arrange
            GridPosition pos1 = new GridPosition(1, 2);
            GridPosition pos2 = new GridPosition(1, 0);

            // Act
            GridPosition sumPos = pos1 + pos2;

            // Assert
            Assert.AreEqual(new GridPosition(2, 2), sumPos);
        }
    

        [TestCase(1,2,1,2,true)]
        [TestCase(1,2,1,3,false)]
        public void Compare_TwoEqualPosition_ReturnsEqualsTrue(int x1, int y1, int x2, int y2, bool expected)
        {
            // Arrange
            GridPosition pos1 = new GridPosition(x1, y1);
            GridPosition pos2 = new GridPosition(x2, y2);

            // Act
            bool areSamePosition = pos1 == pos2;

            // Assert
            Assert.AreEqual(expected, areSamePosition);
        }


        [TestCase(1, 2, 1, 2, false)]
        [TestCase(1, 2, 1, 3, true)]
        public void Compare_TwoDifferentPosition_ReturnsNotEqualsTrue(int x1, int y1, int x2, int y2, bool expected)
        {
            // Arrange
            GridPosition pos1 = new GridPosition(x1, y1);
            GridPosition pos2 = new GridPosition(x2, y2);

            // Act
            bool areDifferentPositions = pos1 != pos2;

            // Assert
            Assert.AreEqual(expected, areDifferentPositions);
        }

        [Test]
        public void HashSet_TwoEqualPositions_ContainsOnlyOne()
        {
            // Arrange
            HashSet<GridPosition> set = new System.Collections.Generic.HashSet<GridPosition>();

            // Act
            set.Add(new GridPosition(3, 5));
            set.Add(new GridPosition(3, 5));

            // Assert
            Assert.AreEqual(1, set.Count);
        }
    }

}
