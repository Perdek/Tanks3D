using RunTime.UI.MVC;
using UnityEngine;

namespace RunTime.UI.MainMenu
{
    public class MainMenuController : Controller
    {
        #region MEMBERS

        #endregion

        #region PROPERTIES
        
        private MainMenuView ViewModule => View as MainMenuView;

        #endregion

        #region METHODS

        protected override void Init()
        {
            base.Init();
            View.AddListenerToPlayGameButton(Model.LoadGameplayScene);
        }

        #endregion
    }
}
