using Character.Component;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    //[CustomEditor(typeof(HealthComponent))]
    [CanEditMultipleObjects]
    public class LookAtPointEditor : UnityEditor.Editor
    {
        private SerializedProperty lookAtPoint;

        void OnEnable()
        {
            lookAtPoint = serializedObject.FindProperty("Target");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(lookAtPoint);
            serializedObject.ApplyModifiedProperties();
            EditorGUILayout.LabelField("(Текст)");
            EditorGUILayout.ColorField(Color.red);
        }
    }
}