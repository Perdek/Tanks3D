using System;

namespace RunTime.Communicators.LoadingSceneCommunicator
{
    public class LoadingSceneCommunicator : ILoadingSceneCommunicator
    {
        #region MEMBERS

        public event Action OnLoadGameplayScene = delegate {  };

        #endregion
        
        #region METHODS

        public void NotifyOnLoadGameplayScene()
        {
            OnLoadGameplayScene();
        }

        #endregion
    }
}