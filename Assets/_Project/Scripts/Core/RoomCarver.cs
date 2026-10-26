using System;


namespace FutharksAdventure.Core
{
    public static class RoomCarver
    {

        public static void CarveRoom(FloorGrid grid, GridPosition interiorOrigin, int roomWidth, int roomHeight, Sides doorWalls)
        {
            int minX = interiorOrigin.X - 1;
            int minY = interiorOrigin.Y - 1;
            int maxX = interiorOrigin.X + roomWidth;
            int maxY = interiorOrigin.Y + roomHeight;

            // Guard Tests for Args
            if (grid is null)
                throw new ArgumentNullException(nameof(grid));
            if (roomWidth <= 0 || roomWidth % 2 == 0)
                throw new ArgumentOutOfRangeException(nameof(roomWidth));
            if (roomHeight <= 0 || roomHeight % 2 == 0)
                throw new ArgumentOutOfRangeException(nameof(roomHeight));
            if (!grid.IsInGrid(new GridPosition(minX, minY)))
                throw new ArgumentOutOfRangeException(nameof(interiorOrigin));
            if (!grid.IsInGrid(new GridPosition(maxX, maxY)))
                throw new ArgumentOutOfRangeException();

            // Fill interior with floor and surrounds with walls
            for (int x = minX; x <= maxX; x++)
                for (int y = minY; y <= maxY; y++)
                {
                    if (x == minX || x == maxX || y == minY || y == maxY)
                    {
                        grid.SetTileType(new GridPosition(x, y), TileType.Wall);
                    } else {
                        grid.SetTileType(new GridPosition(x, y), TileType.Floor);
                    }
                }

            // Opens doors in the middle of intended walls
            int middleX = roomWidth / 2;
            int middleY = roomHeight / 2;
            if ((doorWalls & Sides.North) != 0)
                grid.SetTileType(new GridPosition(middleX + interiorOrigin.X, maxY), TileType.Floor);
            if ((doorWalls & Sides.East) != 0)
                grid.SetTileType(new GridPosition(maxX, middleY + interiorOrigin.Y), TileType.Floor);
            if ((doorWalls & Sides.South) != 0)
                grid.SetTileType(new GridPosition(middleX + interiorOrigin.X, minY), TileType.Floor);
            if ((doorWalls & Sides.West) != 0)
                grid.SetTileType(new GridPosition(minX, middleY + interiorOrigin.Y), TileType.Floor);

        }
    }
}
