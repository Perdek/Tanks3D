using System;
using RunTime.UI.MVC;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace RunTime.UI.MainMenu
{
    [Serializable]
    public class MainMenuView : View
    {
        #region MEMBERS

        [SerializeField] private Button _playGameButton;

        #endregion

        #region PROPERTIES

        #endregion

        #region METHODS

        public void AddListenerToPlayGameButton(UnityAction onClick)
        {
            _playGameButton.onClick.AddListener(onClick);
        }

        #endregion
    }

}