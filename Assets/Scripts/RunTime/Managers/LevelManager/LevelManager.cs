using UnityEngine;

namespace RunTime.Managers
{
    public class LevelManager : MonoBehaviour
    {
        #region MEMBERS

        [SerializeField] private Transform _parentToSpawnLevel;
        [SerializeField] private LevelEnum _levelEnum;
        private LevelBuilder _levelBuilder;

        #endregion

        #region UNITY_METHODS

        private void Awake()
        {
            Init();
            SpawnMap();
        }

        #endregion

        #region METHODS
        
        private void Init()
        {
            _levelBuilder = new LevelBuilder(_parentToSpawnLevel);
        }

        private void SpawnMap()
        {
            _levelBuilder.CreateLevel(_levelEnum);
        }

        #endregion
    }

    public enum LevelEnum
    {
        FIRST
    }
}