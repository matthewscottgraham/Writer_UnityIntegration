using UnityEditor;
using Writer.Scripts.ScriptableObjects;

namespace Writer.Scripts.Editor
{
    [CustomEditor(typeof(EntityInfo), true)]
    public class EntityInfoEditor : UnityEditor.Editor
    {
        private SerializedProperty _entityId;
        private SerializedProperty _entityName;
        private SerializedProperty _entityDescription;

        private void OnEnable()
        {
            _entityId = serializedObject.FindProperty("id");
            _entityName = serializedObject.FindProperty("niceName");
            _entityDescription = serializedObject.FindProperty("description");
        }
        
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            
            EditorGUI.BeginDisabledGroup(true);
            
            EditorGUILayout.PropertyField(_entityId);
            EditorGUILayout.PropertyField(_entityName);
            EditorGUILayout.PropertyField(_entityDescription);
            
            EditorGUI.EndDisabledGroup();
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}