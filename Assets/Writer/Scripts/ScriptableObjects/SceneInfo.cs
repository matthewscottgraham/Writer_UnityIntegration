using System.Linq;
using UnityEngine;

namespace Writer.Scripts.ScriptableObjects
{
    public class SceneInfo : EntityInfo
    {
        [SerializeField] private string[] sequenceIDs;

        public string[] SequenceIDs => sequenceIDs;

        public void Initialize(Scene scene)
        {
            id = scene.Id;
            niceName = scene.Name;
            description = scene.Description;
            sequenceIDs = scene.Sequences.Select(sequence => sequence.id).ToArray();
        }
    }
}
