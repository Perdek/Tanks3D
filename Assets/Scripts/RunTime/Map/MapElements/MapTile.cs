using UnityEngine;

public class MapTile : MonoBehaviour
{
    #region MEMBERS

    [SerializeField] private MapTileEnum _mapTileType;
    [SerializeField] private bool _destructible;
    [SerializeField] private bool _land;

    #endregion

    #region ENUMS

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
