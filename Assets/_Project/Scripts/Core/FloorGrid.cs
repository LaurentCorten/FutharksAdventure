using System;



namespace FutharksAdventure.Core
{
    public class FloorGrid
    {

        private readonly TileType[,] _tiles;

        public int Width { get; }
        public int Height { get; }

        public FloorGrid (int width, int height)
        {
            Width = width;
            Height = height;

            _tiles = new TileType[Width, Height];
        }

        public bool IsInGrid(GridPosition pos)
        {
            return pos.X >= 0 && pos.X < Width && pos.Y >= 0 && pos.Y < Height; 
        }

        public TileType GetTileType(GridPosition pos)
        {
            if (!IsInGrid(pos))
                return TileType.Empty;

            return _tiles[pos.X, pos.Y];
        }

        public void SetTileType(GridPosition pos, TileType type)
        {
            if (!IsInGrid(pos))
                throw new ArgumentOutOfRangeException(nameof(pos));

            _tiles[pos.X, pos.Y] = type;
        }

        public bool IsWalkable(GridPosition pos)
        {
            return GetTileType(pos) switch
            {
                TileType.Floor => true,
                TileType.Exit => true,
                TileType.Entry => true,
                _ => false
            };
        }
    }
}
