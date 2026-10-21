using System;



namespace FutharksAdventure.Core
{
    public class FloorGrid
    {

        private TileType[,] _tiles;
        private int _width;
        private int _height;

        public int Width
        { 
            get
            {
                return _width;
            }
            private set
            {
                _width = value;
            }
        }

        public int Height
        { 
            get
            {
                return _height;
            }
            private set
            {
                _height = value;
            }
        }

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

        public TileType SetTileType(GridPosition pos, TileType type)
        {
            if (!IsInGrid(pos))
                throw new ArgumentOutOfRangeException();

            _tiles[pos.X, pos.Y] = type;
            return GetTileType(pos);
        }

        public bool IsWalkable(GridPosition pos)
        {

            if (!IsInGrid(pos))
                return false;
            
            bool isWalkable = false;
            switch (GetTileType(pos))
            {
                case TileType.Floor:
                case TileType.Exit:
                case TileType.Entry:
                    isWalkable = true;
                    break;

                //default:
                //    isWalkable = false;
            }

            return isWalkable;
        }
    }
}
