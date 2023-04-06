using UnityEngine;

namespace RunTime.Managers
{
    public class LevelBuilder
    {
        #region MEMBERS

        private Transform _parentToSpawnLevel;

        #endregion

        #region METHODS

        public LevelBuilder(Transform parentToSpawnLevel)
        {
            _parentToSpawnLevel = parentToSpawnLevel;
        }
        
        public void CreateLevel()
        {
            
        }

        #endregion
    }
}