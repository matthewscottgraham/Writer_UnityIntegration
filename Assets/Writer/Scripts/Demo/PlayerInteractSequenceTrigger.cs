using UnityEngine;

namespace Writer.Scripts.Demo
{
    public class PlayerInteractSequenceTrigger : MonoBehaviour, ISequenceTrigger
    {
        public string SequenceID { get; set; }
        public bool IsSingleUse { get; set; }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            ISequenceTrigger.OnTrigger?.Invoke(SequenceID);
        }

        
    }
}