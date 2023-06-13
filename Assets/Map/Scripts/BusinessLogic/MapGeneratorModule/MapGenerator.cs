using System;
using System.Collections.Generic;
using System.IO;
using Map.Scripts.Domain.MapElements;
using UnityEngine;

namespace Map.Scripts.MapGeneratorModule.Editor
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
        [SerializeField] private List<MapTileSetupComponent> _mapTiles = new List<MapTileSetupComponent>();

        private int _mapSizeWidth = 17;
        private int _mapSizeHeight = 17;
        private MapTile.MapTileEnum[,] _mapArray;
        private Domain.MapElements.Map _map;

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
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
            }

            _mapArray = _map.GenerateMap(_mapSizeWidth, _mapSizeHeight);

            for (int x = 0; x < _mapSizeWidth; x++)
            {
                for (int y = 0; y < _mapSizeHeight; y++)
                {
                    MapTile.MapTileEnum tileType = _mapArray[x, y];
                    Vector3 position = new Vector3(x, 0, y);

                    MapTileSetupComponent mapTileToSpawn = _mapTiles.Find(mapTile => mapTile.MapTileType == tileType);

                    GameObject tile = mapTileToSpawn != null ? GameObject.Instantiate(mapTileToSpawn.gameObject) : GameObject.CreatePrimitive(PrimitiveType.Cube);
                    
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

        public void SaveMapToJson(string folderPath, string fileName)
        {
            string json = SerializeMapToJson();

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            try
            {
                string filePath = Path.Combine(folderPath, fileName);
                File.WriteAllText(filePath, json);

                Debug.Log("Map saved to JSON: " + filePath);
            }
            catch (UnauthorizedAccessException exception)
            {
                Debug.LogError(exception);
            }
        }

        public void LoadMapFromJson(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                List<List<MapTile.MapTileEnum>> mapList = JsonUtility.FromJson<List<List<MapTile.MapTileEnum>>>(json);

                if (mapList != null && mapList.Count > 0)
                {
                    int width = mapList.Count;
                    int height = mapList[0].Count;

                    _mapArray = new MapTile.MapTileEnum[width, height];

                    for (int x = 0; x < width; x++)
                    {
                        List<MapTile.MapTileEnum> row = mapList[x];

                        if (row.Count != height)
                        {
                            Debug.LogError("Invalid map data: Map dimensions do not match.");
                            return;
                        }

                        for (int y = 0; y < height; y++)
                        {
                            _mapArray[x, y] = row[y];
                        }
                    }

                    Debug.Log("Map loaded from JSON: " + filePath);
                }
                else
                {
                    Debug.LogError("Invalid map data: Unable to deserialize JSON.");
                }
            }
            else
            {
                Debug.LogError("File not found: " + filePath);
            }
        }

        
        private string SerializeMapToJson()
        {
            int width = _mapArray?.GetLength(0) ?? 0;
            int height = _mapArray?.GetLength(1) ?? 0;

            List<string> rows = new List<string>();

            for (int x = 0; x < width; x++)
            {
                List<MapTile.MapTileEnum> row = new List<MapTile.MapTileEnum>();

                for (int y = 0; y < height; y++)
                {
                    row.Add(_mapArray[x, y]);
                }

                string rowJson = JsonUtility.ToJson(row);
                rows.Add(rowJson);
            }

            string json = "[" + string.Join(",", rows) + "]";
            return json;
        }

        #endregion
    }
}
