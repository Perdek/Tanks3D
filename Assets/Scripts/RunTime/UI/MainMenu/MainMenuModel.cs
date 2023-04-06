using RunTime.Communicators.LoadingSceneCommunicator;
using RunTime.UI.MVC;

namespace RunTime.UI.MainMenu
{
    [System.Serializable]
    public class MainMenuModel : Model
    {
        #region MEMBERS
        
        private ILoadingSceneCommunicator _loadingSceneCommunicator;

        #endregion

        #region PROPERTIES

        #endregion

        #region METHODS

        public void LoadGameplayScene()
        {
            _loadingSceneCommunicator.NotifyOnLoadGameplayScene();
        }
        
        public void InjectDependencies(ILoadingSceneCommunicator loadingSceneCommunicator)
        {
            _loadingSceneCommunicator = loadingSceneCommunicator;
        }

        #endregion
    }

}