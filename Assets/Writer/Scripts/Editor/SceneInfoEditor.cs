using UnityEditor;
using Writer.Scripts.ScriptableObjects;

namespace Writer.Scripts.Editor
{
    [CustomEditor(typeof(SceneInfo), true)]
    public class SceneInfoEditor : UnityEditor.Editor
    {
        private SerializedProperty _entityId;
        private SerializedProperty _entityName;
        private SerializedProperty _entityDescription;
        private SerializedProperty _sequences;

        private void OnEnable()
        {
            _entityId = serializedObject.FindProperty("id");
            _entityName = serializedObject.FindProperty("niceName");
            _entityDescription = serializedObject.FindProperty("description");
            _sequences = serializedObject.FindProperty("sequenceIDs");
        }
        
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            EditorGUI.BeginDisabledGroup(true);
            
            EditorGUILayout.PropertyField(_entityId);
            EditorGUILayout.PropertyField(_entityName);
            EditorGUILayout.PropertyField(_entityDescription);
            EditorGUILayout.PropertyField(_sequences, true);
            
            EditorGUI.EndDisabledGroup();
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}