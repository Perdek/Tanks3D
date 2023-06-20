namespace Map.Scripts.BusinessLogic.Domain.MapElements
{
    public class MapTile
    {
        #region MEMBERS

        private readonly MapTileEnum _mapTileType;
        private readonly bool _destructible;
        private readonly bool _land;

        #endregion

        #region PROPERTIES

        public MapTileEnum MapTileType => _mapTileType;

        #endregion

        #region METHODS

        public MapTile(MapTileEnum mapTileType, bool destructible, bool land)
        {
            _mapTileType = mapTileType;
            _destructible = destructible;
            _land = land;
        }

        #endregion

        #region ENUMS

        [System.Serializable]
        public enum MapTileEnum
        {
            EMPTY_SPACE,
            BRICK,
            NON_DESTRUCTIVE_BRICK,
            GRASS,
            EAGLE,
            WATER
        }

        #endregion
    }
}
