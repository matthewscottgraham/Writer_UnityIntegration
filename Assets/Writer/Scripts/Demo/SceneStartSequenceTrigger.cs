using UnityEngine;

namespace Writer.Scripts.Demo
{
    public class SceneStartSequenceTrigger : MonoBehaviour, ISequenceTrigger
    {
        public string SequenceID { get; set; }
        public bool IsSingleUse { get; set; }

        private void Start()
        {
            ISequenceTrigger.OnTrigger?.Invoke(SequenceID);
        }
    }
}