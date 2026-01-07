using UnityEditor;
using UnityEngine;

namespace Writer.Scripts.Editor
{
    [CustomEditor(typeof(Demo.SequenceTrigger), true)]
    public class SequenceTriggerEditor : UnityEditor.Editor
    {
        private SerializedProperty _sequenceID;
        private SerializedProperty _isSingleUse;

        private void OnEnable()
        {
            _sequenceID = serializedObject.FindProperty("sequenceID");
            _isSingleUse = serializedObject.FindProperty("isSingleUse");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            EditorGUI.BeginDisabledGroup(true);
            
            EditorGUILayout.PropertyField(_sequenceID);
            EditorGUILayout.PropertyField(_isSingleUse);
            
            EditorGUI.EndDisabledGroup();
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}
