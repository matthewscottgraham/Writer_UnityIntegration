using UnityEditor;
using UnityEngine;

namespace Writer.Scripts.Editor
{
    [CustomEditor(typeof(Demo.SceneStartSequenceTrigger))]
    public class SceneStartSequenceTriggerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            var trigger = (Demo.SceneStartSequenceTrigger)target;
            GUILayout.Label($"SequenceID: {trigger.SequenceID}");
            GUILayout.Label($"Is Single Use: {trigger.IsSingleUse}");
        }
    }
}