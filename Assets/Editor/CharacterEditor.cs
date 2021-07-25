using UnityEditor;
using UnityEngine;

namespace Editor
{
    public class CharacterEditor : EditorWindow
    {
        private string myString;
        private bool groupEnabled;
        private bool myBool;
        private float myFloat;

        [MenuItem("Dismal Forest Tools/Character Editor")]
        private static void ShowWindow()
        {
            var window = GetWindow<CharacterEditor>();
            window.titleContent = new GUIContent("Character Editor");
            window.Show();
        }

        private void OnGUI()
        {
            GUILayout.Label("Редактор", EditorStyles.boldLabel);
            myString = EditorGUILayout.TextField("Text Field", myString);
            groupEnabled = EditorGUILayout.BeginToggleGroup("Optional Settings", groupEnabled);
            myBool = EditorGUILayout.Toggle("Toggle", myBool);
            myFloat = EditorGUILayout.Slider("Slider", myFloat, -3, 3);
            EditorGUILayout.EndToggleGroup();
            if (GUILayout.Button("Go"))
                Debug.Log($"myFloat={myFloat}, myString={myString}");
            Camera.main.transform.position = new Vector3(myFloat, 0, 0);
        }
    }
}