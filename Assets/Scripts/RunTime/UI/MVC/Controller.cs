using UnityEngine;

namespace RunTime.UI.MVC
{
    [System.Serializable]
    public abstract class Controller<V, M> : MonoBehaviour where V : View where M : Model
    {
        #region MEMBERS

        [SerializeField] V _view;
        private M _model;

        #endregion

        #region PROPERTIES

        #endregion
        
        #region UNITY_METHODS

        private void Awake()
        {
            Init();
        }

        #endregion

        #region METHODS


        protected T GetModel<T>() where T : Model
        {
            return _model as T;
        }

        protected T GetView<T>() where T : View
        {
            return _view as T;
        }

        protected virtual void Init()
        {
            _model.Init();
            _view.Init();
        }

        #endregion
    }
}