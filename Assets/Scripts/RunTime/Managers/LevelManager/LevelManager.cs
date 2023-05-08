using System.Collections.Generic;
using UnityEngine;

namespace RunTime.Managers
{
    public class LevelManager : MonoBehaviour
    {
        #region MEMBERS

        [SerializeField] private Transform _parentToSpawnLevel;
        [SerializeField] private LevelEnum _levelEnum;
        [SerializeField] private List<TextAsset> _levelsMapFiles;
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
            _levelBuilder = new LevelBuilder(_parentToSpawnLevel, _levelsMapFiles);
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
