using UnityEngine;
using UnityEditor;

namespace Editor.MapGeneratorModule
{
    [CustomEditor(typeof(MapGenerator))]
    public class MapGeneratorEditor : UnityEditor.Editor
    {
        private const int LabelWidth = 50;
        private const int FieldWidth = 30;

        private SerializedProperty _mapTileSetupsProperty;

        private void OnEnable()
        {
            _mapTileSetupsProperty = serializedObject.FindProperty("_mapTileSetups");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

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

            // Add flexible space to dynamically adjust the spacing
            GUILayout.FlexibleSpace();

            // Create custom GUI field for height with limited width
            EditorGUILayout.LabelField("Height", GUILayout.Width(LabelWidth));
            mapGenerator.MapSizeHeight = Mathf.Clamp(EditorGUILayout.IntField(mapGenerator.MapSizeHeight, GUILayout.Width(FieldWidth)), 0, 50);

            // End the horizontal layout
            EditorGUILayout.EndHorizontal();

            // End the grouped box
            EditorGUILayout.EndVertical();

            EditorGUILayout.Space();

            // Display the map tile setups list
            EditorGUILayout.LabelField("Map Tile Setups", EditorStyles.boldLabel);
            EditorGUI.indentLevel++;

            // Display the array size field
            EditorGUILayout.PropertyField(_mapTileSetupsProperty, new GUIContent("Size"));

            if (_mapTileSetupsProperty.isExpanded)
            {
                // Display the individual map tile setups fields
                for (int i = 0; i < _mapTileSetupsProperty.arraySize; i++)
                {
                    SerializedProperty mapTileSetupProperty = _mapTileSetupsProperty.GetArrayElementAtIndex(i);

                    EditorGUILayout.BeginHorizontal();

                    // MapTileType field
                    SerializedProperty mapTileTypeProperty = mapTileSetupProperty.FindPropertyRelative("MapTileType");
                    EditorGUILayout.PropertyField(mapTileTypeProperty, GUIContent.none, GUILayout.Width(120));

                    // Character field
                    SerializedProperty characterProperty = mapTileSetupProperty.FindPropertyRelative("Character");
                    EditorGUILayout.PropertyField(characterProperty, GUIContent.none, GUILayout.Width(30));

                    // Percentage field
                    SerializedProperty percentProperty = mapTileSetupProperty.FindPropertyRelative("Percent");
                    EditorGUILayout.PropertyField(percentProperty, GUIContent.none, GUILayout.Width(50));

                    EditorGUILayout.EndHorizontal();
                }
            }

            EditorGUI.indentLevel--;

            serializedObject.ApplyModifiedProperties();
        }
    }
}
