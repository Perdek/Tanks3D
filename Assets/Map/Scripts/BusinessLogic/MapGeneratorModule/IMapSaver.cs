using Map.Scripts.BusinessLogic.Domain.MapElements;

namespace Map.Scripts.BusinessLogic.MapGeneratorModule
{
    public interface IMapSaver
    {
        public void SaveMapToJson(string folderPath, string fileName, MapTile.MapTileEnum[,] mapArray);
    }
}