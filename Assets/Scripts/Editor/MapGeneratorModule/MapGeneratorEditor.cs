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
            
            MapGenerator mapGenerator = (MapGenerator)target;

            DrawDefaultInspector();
    
            EditorGUILayout.BeginVertical(GUI.skin.box);
            EditorGUILayout.LabelField("Map Size", EditorStyles.boldLabel);

            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("Width", GUILayout.Width(LabelWidth));
            mapGenerator.MapSizeWidth = Mathf.Clamp(EditorGUILayout.IntField(mapGenerator.MapSizeWidth, GUILayout.Width(FieldWidth)), 0, 50);

            GUILayout.FlexibleSpace();

            EditorGUILayout.LabelField("Height", GUILayout.Width(LabelWidth));
            mapGenerator.MapSizeHeight = Mathf.Clamp(EditorGUILayout.IntField(mapGenerator.MapSizeHeight, GUILayout.Width(FieldWidth)), 0, 50);

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.EndVertical();

            EditorGUILayout.Space();

            /*EditorGUILayout.LabelField("Map Tile Setups", EditorStyles.boldLabel);
            EditorGUI.indentLevel++;

            EditorGUILayout.PropertyField(_mapTileSetupsProperty, new GUIContent("Size"));

            /*if (_mapTileSetupsProperty.isExpanded)
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
            }#1#

            EditorGUI.indentLevel--;*/
            
            EditorGUILayout.Space();
            
            if (GUILayout.Button("Generate Map"))
            {
                mapGenerator.Generate();
            }
            
            EditorGUILayout.Space();
            
            if (GUILayout.Button("Clear Map"))
            {
                mapGenerator.ClearMap();
            }
            
            EditorGUILayout.Space();
            
            if (GUILayout.Button("Save Map"))
            {
                mapGenerator.SaveMapToJson("D:");
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
