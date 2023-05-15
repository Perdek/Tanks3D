using UnityEngine;
using UnityEditor;

namespace Editor.MapGeneratorModule
{
    [CustomEditor(typeof(MapGenerator))]
    public class MapGeneratorEditor : UnityEditor.Editor
    {
        private const int LabelWidth = 50;
        private const int FieldWidth = 30;

        public override void OnInspectorGUI()
        {
            // Reference to the target script
            MapGenerator mapGenerator = (MapGenerator)target;

            // Display the default inspector fields
            DrawDefaultInspector();

            // Begin a grouped box with a rounded border
            EditorGUILayout.BeginVertical(GUI.skin.box);
            EditorGUILayout.LabelField("Map Size", EditorStyles.boldLabel);

            // Begin a horizontal layout for one row
            EditorGUILayout.BeginHorizontal();

            // Create custom GUI field for width with flexible space and limited width
            EditorGUILayout.LabelField("Width", GUILayout.Width(LabelWidth));
            mapGenerator.MapSizeWidth = Mathf.Clamp(EditorGUILayout.IntField(mapGenerator.MapSizeWidth, GUILayout.Width(FieldWidth)), 0, 50);

            // Create custom GUI field for height with limited width
            EditorGUILayout.LabelField("Height", GUILayout.Width(LabelWidth));
            mapGenerator.MapSizeHeight = Mathf.Clamp(EditorGUILayout.IntField(mapGenerator.MapSizeHeight, GUILayout.Width(FieldWidth)), 0, 50);

            // End the horizontal layout
            EditorGUILayout.EndHorizontal();

            // End the grouped box
            EditorGUILayout.EndVertical();
        }
    }
}