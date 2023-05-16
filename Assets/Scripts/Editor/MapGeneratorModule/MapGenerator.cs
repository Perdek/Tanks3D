using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Editor.MapGeneratorModule
{
    [Serializable]
    public class MapTileSetup
    {
        public MapTile.MapTileEnum MapTileType { get; set; }
        public char Symbol { get; set; }
        public float Percent { get; set; }
    }

    public class MapGenerator : MonoBehaviour
    {
        #region MEMBERS

        [SerializeField] private List<MapTileSetup> _mapTileSetups = new List<MapTileSetup>();
        [SerializeField] private List<MapTile> _mapTiles;

        private int _mapSizeWidth = 17;
        private int _mapSizeHeight = 17;
        private MapTile.MapTileEnum[,] _mapArray;

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

        public List<MapTileSetup> MapTileSetups => _mapTileSetups;

        #endregion

        #region METHODS

        public void Generate()
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
            }

            _mapArray = CreateMapTemplate(_mapSizeWidth, _mapSizeHeight);

            for (int x = 0; x < MapSizeWidth; x++)
            {
                for (int y = 0; y < MapSizeHeight; y++)
                {
                    MapTile.MapTileEnum tileType = _mapArray[x, y];
                    Vector3 position = new Vector3(x, 0, y);

                    GameObject tile = GameObject.Instantiate(_mapTiles.Find(mapTile => mapTile.MapTileType == tileType).gameObject);
                    tile.transform.SetParent(transform);
                    tile.transform.position = position;
                }
            }

            Debug.Log("Map generated!");
        }

        public void ClearMap()
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
            }
        }
        
        private MapTile.MapTileEnum[,] CreateMapTemplate(int width, int height)
        {
            MapTile.MapTileEnum[,] mapArray = new MapTile.MapTileEnum[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    mapArray[x, y] = GetRandomTileType();
                }
            }

            return mapArray;
        }

        private MapTile.MapTileEnum GetRandomTileType()
        {
            Array tileTypes = Enum.GetValues(typeof(MapTile.MapTileEnum));
            return (MapTile.MapTileEnum)tileTypes.GetValue(Random.Range(0, tileTypes.Length));
        }

        #endregion
    }
}