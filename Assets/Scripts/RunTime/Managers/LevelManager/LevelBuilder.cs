using System.Collections.Generic;
using UnityEngine;

namespace RunTime.Managers
{
    public class LevelBuilder
    {
        #region MEMBERS

        private Transform _parentToSpawnLevel;
        private List<TextAsset> _levelsMapFiles;

        #endregion

        #region METHODS

        public LevelBuilder(Transform parentToSpawnLevel, List<TextAsset> levelsMapFiles)
        {
            _parentToSpawnLevel = parentToSpawnLevel;
            _levelsMapFiles = levelsMapFiles;
        }

        public void CreateLevel(LevelEnum levelEnum)
        {
            //string levelJson =
        }

        #endregion
    }
}
