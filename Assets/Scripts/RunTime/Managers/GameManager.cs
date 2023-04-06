using RunTime.Communicators.LoadingSceneCommunicator;
using RunTime.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace RunTime.Managers
{
    public class GameManager : MonoBehaviour
    {
        #region MEMBERS

        private ILoadingSceneCommunicator _loadingSceneCommunicator;
    
        #endregion
    
        #region PROPERTIES
    
        #endregion
    
        #region UNITY_METHODS

        private void Awake()
        {
            LoadMainMenuScene();
            AttachEvents();
        }

        #endregion

        #region METHODS

        [Inject]
        private void InjectDependencies(ILoadingSceneCommunicator loadingSceneCommunicator)
        {
            _loadingSceneCommunicator = loadingSceneCommunicator;
        }
        
        private void AttachEvents()
        {
            _loadingSceneCommunicator.OnLoadGameplayScene += LoadGameplay;
        }

        private void LoadMainMenuScene()
        {
            SceneManager.LoadScene(GameConstants.SceneNames.MainMenuScene, LoadSceneMode.Additive);
        }

        private void LoadGameplay()
        {
            SceneManager.UnloadSceneAsync(GameConstants.SceneNames.MainMenuScene);
            SceneManager.LoadScene(GameConstants.SceneNames.GameplayScene, LoadSceneMode.Additive);
        }

        #endregion
    }

}