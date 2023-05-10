using UnityEngine;
using UnityEditor;

namespace Editor.MapGeneratorModule
{
    [CustomEditor(typeof(MapGenerator))]
    public class MapGeneratorEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            //MapGenerator mapGenerator = (MapGenerator)target;

            // Add custom GUI elements here
            //EditorGUILayout.LabelField("My Custom Inspector");
            //myScript.myVariable = EditorGUILayout.FloatField("My Variable", myScript.myVariable);

            // Call the default inspector
            DrawDefaultInspector();
        }
    }
}