using System;
using NUnit.Framework;
using FutharksAdventure.Core;

namespace FutharksAdventure.Tests
{
    public class RoomCarverTests
    {
        // Grille 9x9 vide. Piece 3x3 dont l'interieur commence en (2,2) :
        // interieur de (2,2) a (4,4), murs de (1,1) a (5,5),
        // milieux des cotes : North (3,5), South (3,1), East (5,3), West (1,3).
        private FloorGrid _grid;

        [SetUp]
        public void SetUp()
        {
            _grid = new FloorGrid(9, 9);
        }

        private TileType TileAt(int x, int y) => _grid.GetTileType(new GridPosition(x, y));

        private static bool IsOnPerimeter(int x, int y, int minX, int minY, int maxX, int maxY)
            => x == minX || x == maxX || y == minY || y == maxY;

        [Test]
        public void CarveRoom_FillsInteriorWithFloor()
        {
            RoomCarver.CarveRoom(_grid, new GridPosition(2, 2), 3, 3, Sides.None);

            for (int x = 2; x <= 4; x++)
                for (int y = 2; y <= 4; y++)
                    Assert.AreEqual(TileType.Floor, TileAt(x, y), $"Case ({x},{y})");
        }

        [Test]
        public void CarveRoom_WithoutDoors_SurroundsInteriorWithWalls()
        {
            RoomCarver.CarveRoom(_grid, new GridPosition(2, 2), 3, 3, Sides.None);

            for (int x = 1; x <= 5; x++)
                for (int y = 1; y <= 5; y++)
                    if (IsOnPerimeter(x, y, 1, 1, 5, 5))
                        Assert.AreEqual(TileType.Wall, TileAt(x, y), $"Case ({x},{y})");
        }

        [Test]
        public void CarveRoom_DoesNotTouchTilesOutsideTheWalls()
        {
            RoomCarver.CarveRoom(_grid, new GridPosition(2, 2), 3, 3, Sides.None);

            Assert.AreEqual(TileType.Empty, TileAt(0, 0));
            Assert.AreEqual(TileType.Empty, TileAt(6, 6));
            Assert.AreEqual(TileType.Empty, TileAt(3, 0));
            Assert.AreEqual(TileType.Empty, TileAt(3, 6));
            Assert.AreEqual(TileType.Empty, TileAt(0, 3));
            Assert.AreEqual(TileType.Empty, TileAt(6, 3));
        }

        [TestCase(Sides.North, 3, 5)]
        [TestCase(Sides.South, 3, 1)]
        [TestCase(Sides.East, 5, 3)]
        [TestCase(Sides.West, 1, 3)]
        public void CarveRoom_WithOneDoor_OpensOnlyTheMiddleOfThatSide(Sides door, int doorX, int doorY)
        {
            RoomCarver.CarveRoom(_grid, new GridPosition(2, 2), 3, 3, door);

            Assert.AreEqual(TileType.Floor, TileAt(doorX, doorY), "La porte doit etre du sol");

            int openings = 0;
            for (int x = 1; x <= 5; x++)
                for (int y = 1; y <= 5; y++)
                    if (IsOnPerimeter(x, y, 1, 1, 5, 5) && TileAt(x, y) == TileType.Floor)
                        openings++;

            Assert.AreEqual(1, openings, "Une seule ouverture attendue dans le mur");
        }

        [Test]
        public void CarveRoom_WithSeveralDoors_OpensEachRequestedSideOnly()
        {
            RoomCarver.CarveRoom(_grid, new GridPosition(2, 2), 3, 3, Sides.North | Sides.West);

            Assert.AreEqual(TileType.Floor, TileAt(3, 5), "North");
            Assert.AreEqual(TileType.Floor, TileAt(1, 3), "West");
            Assert.AreEqual(TileType.Wall, TileAt(3, 1), "South doit rester un mur");
            Assert.AreEqual(TileType.Wall, TileAt(5, 3), "East doit rester un mur");
        }

        [Test]
        public void CarveRoom_WithAllDoors_KeepsCornersAsWalls()
        {
            Sides all = Sides.North | Sides.East | Sides.South | Sides.West;
            RoomCarver.CarveRoom(_grid, new GridPosition(2, 2), 3, 3, all);

            Assert.AreEqual(TileType.Wall, TileAt(1, 1));
            Assert.AreEqual(TileType.Wall, TileAt(1, 5));
            Assert.AreEqual(TileType.Wall, TileAt(5, 1));
            Assert.AreEqual(TileType.Wall, TileAt(5, 5));
        }

        [Test]
        public void CarveRoom_RectangularRoom_UsesWidthAndHeightSeparately()
        {
            // Interieur 7x3 en (2,2) : x de 2 a 8, y de 2 a 4 ; murs x de 1 a 9, y de 1 a 5
            var grid = new FloorGrid(11, 7);

            RoomCarver.CarveRoom(grid, new GridPosition(2, 2), 7, 3, Sides.North | Sides.East);

            Assert.AreEqual(TileType.Floor, grid.GetTileType(new GridPosition(8, 4)), "Coin haut-droit de l'interieur");
            Assert.AreEqual(TileType.Wall, grid.GetTileType(new GridPosition(9, 2)), "Mur East");
            Assert.AreEqual(TileType.Wall, grid.GetTileType(new GridPosition(4, 5)), "Mur North hors porte");
            Assert.AreEqual(TileType.Floor, grid.GetTileType(new GridPosition(5, 5)), "Porte North au milieu");
            Assert.AreEqual(TileType.Floor, grid.GetTileType(new GridPosition(9, 3)), "Porte East au milieu");
        }

        [TestCase(2, 3)]
        [TestCase(3, 4)]
        [TestCase(0, 3)]
        [TestCase(3, -1)]
        public void CarveRoom_WithEvenOrNonPositiveSize_Throws(int width, int height)
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => RoomCarver.CarveRoom(_grid, new GridPosition(2, 2), width, height, Sides.None));
        }

        [TestCase(0, 2)] // mur West en x = -1
        [TestCase(2, 0)] // mur South en y = -1
        [TestCase(6, 2)] // mur East en x = 9
        [TestCase(2, 6)] // mur North en y = 9
        public void CarveRoom_WhenWallsWouldLeaveTheGrid_ThrowsAndChangesNothing(int originX, int originY)
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => RoomCarver.CarveRoom(_grid, new GridPosition(originX, originY), 3, 3, Sides.None));

            for (int x = 0; x < 9; x++)
                for (int y = 0; y < 9; y++)
                    Assert.AreEqual(TileType.Empty, TileAt(x, y), $"La grille a ete modifiee en ({x},{y})");
        }
    }
}