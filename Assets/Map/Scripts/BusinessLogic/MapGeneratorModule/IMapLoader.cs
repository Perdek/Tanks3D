using Map.Scripts.BusinessLogic.Domain.MapElements;

namespace Map.Scripts.BusinessLogic.MapGeneratorModule
{
    public interface IMapLoader
    {
        public MapTile.MapTileEnum[,] LoadMapFromJson(string filePath);
    }
}