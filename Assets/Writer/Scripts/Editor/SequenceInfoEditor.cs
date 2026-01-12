using UnityEditor;
using Writer.Scripts.ScriptableObjects;

namespace Writer.Scripts.Editor
{
    [CustomEditor(typeof(SequenceInfo))]
    public class SequenceInfoEditor : UnityEditor.Editor
    {
        private SerializedProperty _sequenceId;
        private SerializedProperty _sequenceName;
        private SerializedProperty _invokeType;
        private SerializedProperty _isSingleUse;

        private void OnEnable()
        {
            _sequenceId = serializedObject.FindProperty("sequence.id");
            _sequenceName = serializedObject.FindProperty("sequence.name");
            _invokeType = serializedObject.FindProperty("sequence.invokeType");
            _isSingleUse = serializedObject.FindProperty("sequence.isSingleUse");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            EditorGUI.BeginDisabledGroup(true);
            
            EditorGUILayout.PropertyField(_sequenceId);
            EditorGUILayout.PropertyField(_sequenceName);
            EditorGUILayout.PropertyField(_invokeType);
            EditorGUILayout.PropertyField(_isSingleUse);
            
            EditorGUI.EndDisabledGroup();
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}