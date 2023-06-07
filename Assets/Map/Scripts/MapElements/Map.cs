using System;
using System.Collections.Generic;

namespace Map.Scripts.MapElements
{
    public class Map
    {
        #region MEMBERS

        private readonly List<MapTile> _mapTiles;

        #endregion

        #region METHODS

        public Map(List<MapTileSetupComponent> mapTilesSetupComponents)
        {
            _mapTiles = new List<MapTile>();

            foreach (MapTileSetupComponent mapTileSetup in mapTilesSetupComponents)
            {
                MapTile newMapTile = new MapTile(mapTileSetup.MapTileType, mapTileSetup.Destructible, mapTileSetup.Land);
                _mapTiles.Add(newMapTile);
            }
        }

        public MapTile.MapTileEnum[,] GenerateMap(int width, int height)
        {
            MapTile.MapTileEnum[,] generatedMap = new MapTile.MapTileEnum[width,height];
            
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    generatedMap[x, y] = GetRandomTileType();
                }
            }

            return generatedMap;
        }
        
        private MapTile.MapTileEnum GetRandomTileType()
        {
            Array tileTypes = Enum.GetValues(typeof(MapTile.MapTileEnum));
            return (MapTile.MapTileEnum)tileTypes.GetValue(UnityEngine.Random.Range(0, tileTypes.Length));
        }
        
        #endregion
    }
}