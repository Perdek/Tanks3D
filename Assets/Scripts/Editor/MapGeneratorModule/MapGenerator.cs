using System.Collections.Generic;
using UnityEngine;

namespace Editor.MapGeneratorModule
{
    public class MapGenerator : MonoBehaviour
    {
        #region MEMBERS

        [SerializeField] private List<MapTile> _mapTiles;

        #endregion

        #region PROPERTIES

        public int MapSizeWidth { get; set; } = 17;

        public int MapSizeHeight { get; set; } = 17;

        #endregion
    }
}