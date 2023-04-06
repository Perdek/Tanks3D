using System;

namespace RunTime.Communicators.LoadingSceneCommunicator
{
    public interface ILoadingSceneCommunicator
    {
        public event Action OnLoadGameplayScene;

        void NotifyOnLoadGameplayScene();
    }
}