using System;
using RunTime.Communicators.LoadingSceneCommunicator;
using RunTime.UI.MVC;
using Zenject;

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

        [Inject]
        private void InjectDependencies(ILoadingSceneCommunicator loadingSceneCommunicator)
        {
            ModelModule.InjectDependencies(loadingSceneCommunicator);
        }

        protected override void Init()
        {
            base.Init();
            ViewModule.AddListenerToPlayGameButton(ModelModule.LoadGameplayScene);
        }

        #endregion
    }
}
