namespace Map.Scripts.UseCases
{
    public class MapGenerationUseCase
    {
        #region METHODS

        public void GenerateMap(int width, int height, Domain.MapElements.Map map)
        {
            map.GenerateMap(width, height);
        }

        #endregion
    }
}