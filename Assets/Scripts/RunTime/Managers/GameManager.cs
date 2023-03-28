using RunTime.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace RunTime.Managers
{
    public class GameManager : MonoBehaviour
    {
        #region MEMBERS
    
        #endregion
    
        #region PROPERTIES
    
        #endregion
    
        #region UNITY_METHODS

        private void Awake()
        {
            LoadScene();
        }

        #endregion

        #region METHODS

        private void LoadScene()
        {
            SceneManager.LoadScene(GameConstants.SceneNames.MainMenuScene, LoadSceneMode.Additive);
        }

        #endregion
    }

}