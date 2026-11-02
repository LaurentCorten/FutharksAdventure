using System;



namespace FutharksAdventure.Core
{
    /// <summary>
    /// Type of a single tile in a <see cref="FloorGrid"/>.
    /// </summary>
    public enum TileType
    {
        /// <summary>
        /// Nothing: outside the playable area. Default value of a new grid,
        /// also returned by <see cref="FloorGrid.GetTileType"/> for positions outside the grid.
        /// </summary>
        Empty,

        /// <summary>Walkable ground inside rooms and corridors. Doors are Floor tiles too.</summary>
        Floor,

        /// <summary>Blocks movement and ranged attacks, but not vision.</summary>
        Wall,

        /// <summary>Exit of the floor: stepping on it leads to the next floor.</summary>
        Exit,

        /// <summary>Tile where the player arrives on the floor.</summary>
        Entry
    }


    /// <summary>
    /// Sides of a room, combinable as flags (e.g. Sides.North | Sides.West).
    /// North is the max-Y side (up on screen).
    /// </summary>
    [Flags]
    public enum Sides
    {
        None =0,
        North = 1,
        East = 2,
        South =4,
        West =8
    }
}
