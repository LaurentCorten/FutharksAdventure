using UnityEngine;
using FutharksAdventure.Core;

namespace FutharksAdventure.Game
{
    /// <summary>
    /// Single entry point of the game (Composition Root):
    /// the only place that creates objects and wires them together.
    /// </summary>
    public class Bootstrap : MonoBehaviour
    {
        [SerializeField] private GridView _gridView;

        private void Start()
        {
            FloorGrid testFloor = BuildTestFloor();
            _gridView.Render(testFloor);
        }

        // TEMPORARY: hard-coded test floor, replaced by the procedural generator in Phase 5
        private static FloorGrid BuildTestFloor()
        {
            // Instanciate the a grid big enough
            var floor = new FloorGrid(21, 11);

            // Carve the 2 rooms in it
            RoomCarver.CarveRoom(floor, new GridPosition(4, 5), 5, 5, Sides.East);
            RoomCarver.CarveRoom(floor, new GridPosition(16, 5), 7, 3, Sides.West);

            // Carve the link between them
            for (int x = 8; x < 12; x++)
            { 
                floor.SetTileType(new GridPosition(x, 4), TileType.Wall);
                floor.SetTileType(new GridPosition(x, 5), TileType.Floor);
                floor.SetTileType(new GridPosition(x, 6), TileType.Wall);
            }

            // Carve Entry and Exit
            floor.SetTileType(new GridPosition(3, 5), TileType.Entry);
            floor.SetTileType(new GridPosition(18, 5), TileType.Exit);

            return floor;
        }
    }
}