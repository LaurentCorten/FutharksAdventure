
using System;

namespace FutharksAdventure.Core
{
    public readonly struct GridPosition : IEquatable<GridPosition>
    {
        public int X { get; }

        public int Y { get; }

        public GridPosition(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static GridPosition operator + (GridPosition pos1, GridPosition pos2)
        {
            return new GridPosition(pos1.X + pos2.X, pos1.Y + pos2.Y);
        }

        public bool Equals(GridPosition otherGridPos)
        {
            return X == otherGridPos.X && Y == otherGridPos.Y;
        }

        public override bool Equals(object obj)
        {
            return obj is GridPosition otherGridPos && Equals(otherGridPos);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(X, Y);
        }
        public static bool operator == (GridPosition pos1, GridPosition pos2)
        {
            return pos1.Equals(pos2);
        }

        public static bool operator != (GridPosition pos1, GridPosition pos2)
        {
            return !pos1.Equals(pos2);
        }
    }
}
