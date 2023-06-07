using UnityEngine;

namespace Map.Scripts.MapElements
{
    public class MapTileSetupComponent : MonoBehaviour
    {
        #region MEMBERS

        [SerializeField] MapTile.MapTileEnum _mapTileType;
        [SerializeField] private bool _destructible;
        [SerializeField] private bool _land;

        #endregion

        #region PROPERTIES
        
        public MapTile.MapTileEnum MapTileType => _mapTileType;
        public bool Destructible => _destructible;
        public bool Land => _land;

        #endregion
    }
}