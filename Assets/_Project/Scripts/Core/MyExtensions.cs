using System;


namespace FutharksAdventure.Core
{
    public static class MyExtensions
    {
        public static GridPosition ToGridOffset(this Direction direction)
        {
            return direction switch
            {
                Direction.North => new GridPosition(0, 1),
                Direction.East => new GridPosition(1, 0),
                Direction.South => new GridPosition(0, -1),
                Direction.West => new GridPosition(-1, 0),
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, null)
            };
        }
    }
}
