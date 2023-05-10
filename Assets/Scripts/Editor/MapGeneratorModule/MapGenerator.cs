using System.Collections.Generic;
using UnityEngine;

namespace Editor.MapGeneratorModule
{
    public class MapGenerator
    {
        #region MEMBERS

        private int _mapSizeWidth = 17;
        private int _mapSizeHeight = 17;

        [SerializeField] private List<MapTile> _mapTiles;

        #endregion

        #region METHODS

        public void SetMapSizeWidth(int newMapSizeWidth)
        {
            _mapSizeWidth = newMapSizeWidth;
        }
        
        public void SetMapSizeHeight(int newMapSizeHeight)
        {
            _mapSizeHeight = newMapSizeHeight;
        }

        #endregion
    }
}