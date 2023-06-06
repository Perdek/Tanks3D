using System.IO;
using NUnit.Framework;
using UnityEngine;

namespace Editor.MapGeneratorModule.Tests
{
    public class MapGeneratorTests
    {
        private MapGenerator _mapGenerator;

        [SetUp]
        public void SetUp()
        {
            GameObject gameObject = new GameObject();
            _mapGenerator = gameObject.AddComponent<MapGenerator>();
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(_mapGenerator.gameObject);
        }

        [Test]
        public void Generate_MapGenerated()
        {
            int expectedChildCount = _mapGenerator.MapSizeWidth * _mapGenerator.MapSizeHeight;

            _mapGenerator.Generate();

            Assert.AreEqual(expectedChildCount, _mapGenerator.transform.childCount);
        }

        [Test]
        public void ClearMap_MapCleared()
        {
            _mapGenerator.Generate();
            int expectedChildCount = 0;

            _mapGenerator.ClearMap();

            Assert.AreEqual(expectedChildCount, _mapGenerator.transform.childCount);
        }

        [Test]
        public void SaveMapToJson_FileSaved()
        {
            string folderPath = "D:/Maps/";
            string fileName = "Map_01";

            _mapGenerator.SaveMapToJson(folderPath, fileName);
            string fullPath = Path.Combine(folderPath, fileName);

            Assert.IsTrue(File.Exists(fullPath));

            File.Delete(fullPath);
        }

        [Test]
        public void LoadMapFromJson_MapLoaded()
        {
            string folderPath = "D:/Maps/";
            string fileName = "Map_01";
            string fullPath = Path.Combine(folderPath, fileName);
            
            _mapGenerator.SaveMapToJson(folderPath, fileName);  //it shouldn't be here
            _mapGenerator.LoadMapFromJson(fullPath);

            // Assert
            // TO DO

            File.Delete(fullPath);
        }
    }
}
