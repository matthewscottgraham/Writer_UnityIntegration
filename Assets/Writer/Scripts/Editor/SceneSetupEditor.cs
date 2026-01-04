using UnityEditor;
using UnityEngine;

namespace Writer.Scripts.Editor
{
    [CustomEditor(typeof(SceneSetup))]
    public class SceneSetupEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var setup = (SceneSetup)target;
            DrawDefaultInspector();
            
            GUILayout.Space(20);

            if (setup.IsReady)
            {
                if (GUILayout.Button("Setup", GUILayout.Height(30)))
                {
                    setup.Execute();
                }
            }
            else
            {
                GUILayout.Label("Add a scene info reference to enable Setup");
            }
        }
    }
}
