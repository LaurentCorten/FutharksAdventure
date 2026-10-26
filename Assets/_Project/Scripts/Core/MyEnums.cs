using System;



namespace FutharksAdventure.Core
{
    public enum TileType
    {
        Empty,
        Floor,
        Wall,
        Exit,
        Entry
    }

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
