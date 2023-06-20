using UnityEditor;
using UnityEngine;

namespace Map.Scripts.BusinessLogic.MapGeneratorModule.Editor
{
    [CustomEditor(typeof(MapGenerator))]
    public class MapGeneratorToolEditor : UnityEditor.Editor
    {
        private const int LabelWidth = 50;
        private const int FieldWidth = 30;
        private const int BorderRadius = 5;

        private SerializedProperty _mapTileSetupsProperty;

        private GUIStyle _roundedBoxStyle;
        private GUIStyle _titleStyle;

        private void OnEnable()
        {
            _mapTileSetupsProperty = serializedObject.FindProperty("_mapTileSetups");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            MapGenerator mapGenerator = (MapGenerator)target;

            DrawDefaultInspector();

            _roundedBoxStyle = new GUIStyle(GUI.skin.box)
            {
                border = new RectOffset(BorderRadius, BorderRadius, BorderRadius, BorderRadius)
            };

            _titleStyle = new GUIStyle(EditorStyles.boldLabel)
            {
                alignment = TextAnchor.MiddleCenter
            };

            EditorGUILayout.BeginVertical(_roundedBoxStyle);
            EditorGUILayout.LabelField("Map Size", _titleStyle);

            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.LabelField("Width", GUILayout.Width(LabelWidth));
            mapGenerator.MapSizeWidth = Mathf.Clamp(EditorGUILayout.IntField(mapGenerator.MapSizeWidth, GUILayout.Width(FieldWidth)), 0, 50);

            GUILayout.FlexibleSpace();

            EditorGUILayout.LabelField("Height", GUILayout.Width(LabelWidth));
            mapGenerator.MapSizeHeight = Mathf.Clamp(EditorGUILayout.IntField(mapGenerator.MapSizeHeight, GUILayout.Width(FieldWidth)), 0, 50);


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

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.EndVertical();

            EditorGUILayout.Space();

            EditorGUILayout.BeginVertical(_roundedBoxStyle);
            EditorGUILayout.LabelField("Save & Load Settings", _titleStyle);

            EditorGUILayout.LabelField("Save Path");
            mapGenerator.SavePath = EditorGUILayout.TextField(mapGenerator.SavePath);

            EditorGUILayout.Space();

            if (GUILayout.Button("Save Map"))
            {
                mapGenerator.SaveMapToJson(mapGenerator.SavePath, "Map_01");
            }

            EditorGUILayout.Space();

            EditorGUILayout.LabelField("Load Path");
            mapGenerator.LoadPath = EditorGUILayout.TextField(mapGenerator.LoadPath);

            EditorGUILayout.Space();

            if (GUILayout.Button("Load Map"))
            {
                mapGenerator.LoadMapFromJson(mapGenerator.LoadPath);
            }

            EditorGUILayout.EndVertical();

            serializedObject.ApplyModifiedProperties();
        }
    }
}
