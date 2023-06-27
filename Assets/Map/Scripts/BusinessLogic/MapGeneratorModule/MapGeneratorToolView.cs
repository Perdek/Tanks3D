using UnityEngine;

namespace Map.Scripts.BusinessLogic.MapGeneratorModule
{
    public class MapGeneratorToolView : MonoBehaviour
    {
        #region MEMBERS

        private MapGenerator _mapGenerator;

        #endregion

        #region UNITY_METHODS

        private void OnValidate()
        {
            _mapGenerator ??= new MapGenerator();
        }

        #endregion

        public void LoadOption()
        {
            
        }

        public void SaveOption()
        {
            
        }

        public void GenerateOption()
        {
            DestroyGeneratedTiles();
            
            _mapGenerator.Generate();
        }

        public void ClearMapOption()
        {
            DestroyGeneratedTiles();
        }

        private void DestroyGeneratedTiles()
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
                DestroyImmediate(transform.GetChild(i).gameObject);
            }
        }
    }
}