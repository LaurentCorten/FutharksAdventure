using FutharksAdventure.Core;
using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace FutharksAdventure.Game
{
    public class GridView : MonoBehaviour
    {
        [SerializeField] private Tilemap _tilemap;
        [SerializeField] private TileSetConfig _tileSet;

        public void Render(FloorGrid grid)
        {
            if (grid is null)
                throw new ArgumentNullException(nameof(grid));

            // Clear the tilemap
            _tilemap.ClearAllTiles();

            // fill the tilemap where not empty 
            for (int x = 0; x < grid.Width; x++)
                for (int y =0; y < grid.Height; y++)
                {
                    TileType tileType = grid.GetTileType(new GridPosition(x, y));
                    TileBase tileBase = _tileSet.GetTile(tileType);
                    if (tileBase != null)
                        _tilemap.SetTile(new Vector3Int(x, y, 0), tileBase);
                }
        }
    }
}