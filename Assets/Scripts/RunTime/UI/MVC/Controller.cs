using UnityEngine;

namespace RunTime.UI.MVC
{
    public class Controller : MonoBehaviour
    {
        #region MEMBERS

        [SerializeField] private View _view;
        [SerializeField] private Model _model;

        #endregion

        #region PROPERTIES
        
        protected View View => _view;
        protected Model Model => _model;

        #endregion
        
        #region UNITY_METHODS

        private void Awake()
        {
            Init();
        }

        #endregion

        #region METHODS

        protected virtual void Init()
        {
            _model.Init();
            _view.Init();
        }

        #endregion
    }
}