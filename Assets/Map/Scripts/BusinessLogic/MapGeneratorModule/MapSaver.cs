using System;
using System.Collections.Generic;
using System.IO;
using Map.Scripts.BusinessLogic.Domain.MapElements;
using UnityEngine;

namespace Map.Scripts.BusinessLogic.MapGeneratorModule
{
    public class MapSaver : IMapSaver
    {
        #region METHODS

        public void SaveMapToJson(string folderPath, string fileName, MapTile.MapTileEnum[,] mapArray)
        {
            string json = SerializeMapToJson(mapArray);

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

        private string SerializeMapToJson(MapTile.MapTileEnum[,] mapArray)
        {
            int width = mapArray?.GetLength(0) ?? 0;
            int height = mapArray?.GetLength(1) ?? 0;

            List<string> rows = new List<string>();

            for (int x = 0; x < width; x++)
            {
                List<MapTile.MapTileEnum> row = new List<MapTile.MapTileEnum>();

                for (int y = 0; y < height; y++)
                {
                    row.Add(mapArray[x, y]);
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