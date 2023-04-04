using System;
using RunTime.UI.MVC;

namespace RunTime.UI.MainMenu
{
    [Serializable]
    public class MainMenuController : Controller<MainMenuView, MainMenuModel>
    {
        #region MEMBERS

        #endregion

        #region PROPERTIES

        private MainMenuView ViewModule => GetView<MainMenuView>();
        private MainMenuModel ModelModule => GetModel<MainMenuModel>();

        #endregion

        #region METHODS

        protected override void Init()
        {
            base.Init();
            ViewModule.AddListenerToPlayGameButton(ModelModule.LoadGameplayScene);
        }

        #endregion
    }
}
