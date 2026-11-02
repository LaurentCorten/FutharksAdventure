using System;
using UnityEngine;
using UnityEngine.Tilemaps;
using FutharksAdventure.Core;

namespace FutharksAdventure.Game
{
    /// <summary>
    /// Maps each <see cref="TileType"/> to the tile drawn for it in a Tilemap.
    /// Swapping this asset changes the look of the floor without touching any code.
    /// </summary>
    [CreateAssetMenu(fileName = "TileSetConfig", menuName = "FutharksAdventure/TileSetConfig")]
    public class TileSetConfig : ScriptableObject
    {
        [SerializeField] private TileBase _floorTile;
        [SerializeField] private TileBase _wallTile;
        [SerializeField] private TileBase _exitTile;
        [SerializeField] private TileBase _entryTile;

        /// <summary>
        /// Returns the tile to draw for the given type.
        /// </summary>
        /// <param name="type">Type of the tile to draw.</param>
        /// <returns>
        /// The mapped tile, or null for <see cref="TileType.Empty"/>:
        /// nothing is drawn and the camera background shows through.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="type"/> has no mapping.
        /// </exception>
        public TileBase GetTile(TileType type)
        {
            switch (type)
            {
                case TileType.Floor:
                    return _floorTile;
                case TileType.Wall:
                    return _wallTile;
                case TileType.Exit:
                    return _exitTile;
                case TileType.Entry:
                    return _entryTile;
                case TileType.Empty:
                    return null;

                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, "No tile mapped for this TileType.");
            }
        }
    }
}