using System.Collections.Generic;
using Map.Scripts.BusinessLogic.Domain.MapElements;
using Map.Scripts.Domain.MapElements;
using UnityEngine;

namespace Map.Scripts.BusinessLogic.MapGeneratorModule
{
    public class MapGenerator
    {
        #region MEMBERS
        
        [SerializeField] private List<MapTileSetupComponent> _mapTiles = new List<MapTileSetupComponent>();

        private int _mapSizeWidth = 17;
        private int _mapSizeHeight = 17;
        private MapTile.MapTileEnum[,] _mapArray;
        private Domain.MapElements.Map _map;

        private readonly IMapLoader _mapLoader;
        private readonly IMapSaver _mapSaver;

        #endregion

        #region PROPERTIES

        public int MapSizeWidth
        {
            get => _mapSizeWidth;
            set => _mapSizeWidth = Mathf.Max(0, value);
        }

        public int MapSizeHeight
        {
            get => _mapSizeHeight;
            set => _mapSizeHeight = Mathf.Max(0, value);
        }
        public string SavePath { get; set; }

        public string LoadPath { get; set; }

        #endregion

        #region UNITY_METHODS

        private void OnValidate()
        {
            _map = new Domain.MapElements.Map(_mapTiles);
        }

        #endregion

        #region METHODS

        public void Generate()
        {
            _mapArray = _map.GenerateMap(_mapSizeWidth, _mapSizeHeight);

            for (int x = 0; x < _mapSizeWidth; x++)
            {
                for (int y = 0; y < _mapSizeHeight; y++)
                {
                    MapTile.MapTileEnum tileType = _mapArray[x, y];
                    Vector3 position = new Vector3(x, 0, y);

                    MapTileSetupComponent mapTileToSpawn = _mapTiles.Find(mapTile => mapTile.MapTileType == tileType);

                    GameObject tile = mapTileToSpawn != null ? Instantiate(mapTileToSpawn.gameObject) : GameObject.CreatePrimitive(PrimitiveType.Cube);
                    
                    tile.transform.SetParent(transform);
                    tile.transform.position = position;
                }
            }

            Debug.Log("Map generated!");
        }

        #endregion
    }
}
