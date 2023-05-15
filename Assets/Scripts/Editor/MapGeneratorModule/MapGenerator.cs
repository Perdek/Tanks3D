using System;
using System.Collections.Generic;
using UnityEngine;

namespace Editor.MapGeneratorModule
{
    [Serializable]
    public class MapTileSetup
    {
        public MapTile.MapTileEnum MapTileType { get; set; }
        public char Character { get; set; }
        public float Percent { get; set; }
    }

    public class MapGenerator : MonoBehaviour
    {
        #region MEMBERS

        [SerializeField] private List<MapTileSetup> _mapTileSetups = new List<MapTileSetup>();

        private int _mapSizeWidth = 17;
        private int _mapSizeHeight = 17;

        #endregion

        #region PROPERTIES

        public int MapSizeWidth
        {
            get { return _mapSizeWidth; }
            set { _mapSizeWidth = Mathf.Max(0, value); }
        }

        public int MapSizeHeight
        {
            get { return _mapSizeHeight; }
            set { _mapSizeHeight = Mathf.Max(0, value); }
        }

        public List<MapTileSetup> MapTileSetups
        {
            get { return _mapTileSetups; }
        }

        #endregion
    }
}