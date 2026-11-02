using System;


namespace FutharksAdventure.Core
{
    /// <summary>
    /// Carves rectangular rooms into a <see cref="FloorGrid"/>:
    /// a floor interior surrounded by a one-tile wall ring, with optional doors.
    /// </summary>
    public static class RoomCarver
    {
        /// <summary>
        /// Carves a room centred on <paramref name="roomCentre"/>.
        /// Interior tiles become <see cref="TileType.Floor"/>, the surrounding ring becomes
        /// <see cref="TileType.Wall"/>, and each requested side gets a door (a Floor tile)
        /// in the middle of its wall.
        /// </summary>
        /// <param name="grid">Grid to carve into.</param>
        /// <param name="roomCentre">Centre tile of the room interior.</param>
        /// <param name="roomWidth">Interior width in tiles, walls excluded. Must be odd and positive.</param>
        /// <param name="roomHeight">Interior height in tiles, walls excluded. Must be odd and positive.</param>
        /// <param name="doorWalls">Sides that get a door. Combine flags with |, e.g. Sides.North | Sides.West.</param>
        /// <exception cref="ArgumentNullException"><paramref name="grid"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// A size is even or not positive, or the room and its walls do not fit inside the grid.
        /// The grid is left unchanged in that case.
        /// </exception>
        /// <remarks>
        /// Odd sizes guarantee a single middle tile on each side, where doors are placed.
        /// The allowed size range (e.g. 3 to 7) is the floor generator's rule, not checked here.
        /// </remarks>
        public static void CarveRoom(FloorGrid grid, GridPosition roomCentre, int roomWidth, int roomHeight, Sides doorWalls)
        {
            // Wall ring bounds: half the interior on each side of the centre, plus one tile of wall
            int minX = roomCentre.X - roomWidth/2 - 1;
            int minY = roomCentre.Y - roomHeight/2 - 1;
            int maxX = roomCentre.X + roomWidth/2 + 1;
            int maxY = roomCentre.Y + roomHeight/2 + 1;

            // Guards: all checks happen before any write, so a failure never leaves a half-carved room
            if (grid is null)
                throw new ArgumentNullException(nameof(grid));
            if (roomWidth <= 0 || roomWidth % 2 == 0)
                throw new ArgumentOutOfRangeException(nameof(roomWidth), "roomWidth must be > 0 and odd");
            if (roomHeight <= 0 || roomHeight % 2 == 0)
                throw new ArgumentOutOfRangeException(nameof(roomHeight), "roomHeight must be > 0 and odd");
            if (!grid.IsInGrid(new GridPosition(minX, minY)) || !grid.IsInGrid(new GridPosition(maxX, maxY)))
                throw new ArgumentOutOfRangeException(nameof(roomCentre), "The room and its walls must fit inside the grid");

            // Carve: perimeter tiles become walls, everything inside becomes floor
            for (int x = minX; x <= maxX; x++)
                for (int y = minY; y <= maxY; y++)
                {
                    if (x == minX || x == maxX || y == minY || y == maxY)
                        grid.SetTileType(new GridPosition(x, y), TileType.Wall);
                    else
                        grid.SetTileType(new GridPosition(x, y), TileType.Floor);
                }

            // Doors: middle tile of each requested wall, aligned with the centre,
            // so neighbouring rooms sharing a row or column get aligned doors (straight corridors)
            if ((doorWalls & Sides.North) != 0)
                grid.SetTileType(new GridPosition(roomCentre.X, maxY), TileType.Floor);
            if ((doorWalls & Sides.East) != 0)
                grid.SetTileType(new GridPosition(maxX,roomCentre.Y), TileType.Floor);
            if ((doorWalls & Sides.South) != 0)
                grid.SetTileType(new GridPosition(roomCentre.X, minY), TileType.Floor);
            if ((doorWalls & Sides.West) != 0)
                grid.SetTileType(new GridPosition(minX, roomCentre.Y), TileType.Floor);

        }
    }
}
