using UnityEditor;
using UnityEngine;

namespace Writer.Scripts.Editor
{
    [CustomEditor(typeof(Demo.PlayerInteractSequenceTrigger))]
    public class PlayerInteractSequenceTriggerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            var trigger = (Demo.PlayerInteractSequenceTrigger)target;
            GUILayout.Label($"SequenceID: {trigger.SequenceID}");
            GUILayout.Label($"Is Single Use: {trigger.IsSingleUse}");
        }
    }
}
