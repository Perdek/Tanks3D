using System.Collections.Generic;
using System.IO;
using Map.Scripts.BusinessLogic.Domain.MapElements;
using UnityEngine;

namespace Map.Scripts.BusinessLogic.MapGeneratorModule
{
    public class MapLoader : IMapLoader
    {
        public MapTile.MapTileEnum[,] LoadMapFromJson(string filePath)
        {
            MapTile.MapTileEnum[,] mapArray = default;
            
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                List<List<MapTile.MapTileEnum>> mapList = JsonUtility.FromJson<List<List<MapTile.MapTileEnum>>>(json);

                if (mapList is { Count: > 0 })
                {
                    int width = mapList.Count;
                    int height = mapList[0].Count;

                    mapArray = new MapTile.MapTileEnum[width, height];

                    for (int x = 0; x < width; x++)
                    {
                        List<MapTile.MapTileEnum> row = mapList[x];

                        if (row.Count != height)
                        {
                            Debug.LogError("Invalid map data: Map dimensions do not match.");
                            return mapArray;
                        }

                        for (int y = 0; y < height; y++)
                        {
                            mapArray[x, y] = row[y];
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

            return mapArray;
        }
    }
}