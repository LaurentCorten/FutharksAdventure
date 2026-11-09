using FutharksAdventure.Core;

namespace FutharksAdventure.Tests
{
    internal static class TestFloors
    {
        // Grille 5x5 : piece de sol 3x3 de (1,1) a (3,3), murs autour
        public static FloorGrid CreateRoom3x3()
        {
            var grid = new FloorGrid(5, 5);
            RoomCarver.CarveRoom(grid, new GridPosition(2, 2), 3, 3, Sides.None);
            return grid;
        }
    }
}