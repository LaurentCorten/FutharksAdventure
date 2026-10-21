using FutharksAdventure.Core;
using NUnit.Framework;
using System;

namespace FutharksAdventure.Tests
{
    public class FloorGridTests
    {
        private const int Width = 6;
        private const int Height = 4;

        private static FloorGrid CreateGrid()
        {
            return new FloorGrid(Width, Height);
        }

        [Test]
        public void Constructor_StoresSize()
        {
            var grid = CreateGrid();

            Assert.AreEqual(Width, grid.Width);
            Assert.AreEqual(Height, grid.Height);
        }

        [TestCase(0, 0, true)]
        [TestCase(5, 3, true)]
        [TestCase(2, 1, true)]
        [TestCase(-1, 0, false)]
        [TestCase(0, -1, false)]
        [TestCase(6, 0, false)]
        [TestCase(0, 4, false)]
        public void IsInGrid_Position_ReturnsExpected(int x, int y, bool expected)
        {
            var grid = CreateGrid();

            bool result = grid.IsInGrid(new GridPosition(x, y));

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void NewGrid_AllTilesAreEmpty()
        {
            var grid = CreateGrid();

            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    Assert.AreEqual(TileType.Empty, grid.GetTileType(new GridPosition(x, y)));
                }
            }
        }

        [Test]
        public void SetTileType_ThenGetTileType_ReturnsWrittenValue()
        {
            var grid = CreateGrid();
            var position = new GridPosition(5, 3);

            grid.SetTileType(position, TileType.Wall);

            Assert.AreEqual(TileType.Wall, grid.GetTileType(position));
        }

        [Test]
        public void SetTileType_DoesNotChangeOtherTiles()
        {
            var grid = CreateGrid();

            grid.SetTileType(new GridPosition(2, 1), TileType.Floor);

            Assert.AreEqual(TileType.Empty, grid.GetTileType(new GridPosition(1, 2)));
            Assert.AreEqual(TileType.Empty, grid.GetTileType(new GridPosition(3, 1)));
            Assert.AreEqual(TileType.Empty, grid.GetTileType(new GridPosition(2, 2)));
        }

        [TestCase(-1, 0)]
        [TestCase(6, 0)]
        [TestCase(0, 4)]
        public void GetTileType_OutsideGrid_ReturnsEmpty(int x, int y)
        {
            var grid = CreateGrid();

            Assert.AreEqual(TileType.Empty, grid.GetTileType(new GridPosition(x, y)));
        }

        [TestCase(-1, 0)]
        [TestCase(6, 0)]
        [TestCase(0, 4)]
        public void SetTileType_OutsideGrid_Throws(int x, int y)
        {
            var grid = CreateGrid();

            Assert.Throws<ArgumentOutOfRangeException>(
                () => grid.SetTileType(new GridPosition(x, y), TileType.Floor));
        }

        [TestCase(TileType.Empty, false)]
        [TestCase(TileType.Floor, true)]
        [TestCase(TileType.Wall, false)]
        [TestCase(TileType.Exit, true)]
        [TestCase(TileType.Entry, true)]
        public void IsWalkable_ByTileType_ReturnsExpected(TileType type, bool expected)
        {
            var grid = CreateGrid();
            var position = new GridPosition(2, 1);
            grid.SetTileType(position, type);

            Assert.AreEqual(expected, grid.IsWalkable(position));
        }

        [TestCase(-1, 0)]
        [TestCase(6, 0)]
        [TestCase(0, 4)]
        public void IsWalkable_OutsideGrid_ReturnsFalse(int x, int y)
        {
            var grid = CreateGrid();

            Assert.IsFalse(grid.IsWalkable(new GridPosition(x, y)));
        }
    }
}