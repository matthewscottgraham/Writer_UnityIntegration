using UnityEngine;

namespace Writer.Scripts.Demo
{
    public class PlayerInteractSequenceTrigger : SequenceTrigger
    {
        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Player")) return;
            TriggerSequence();
        }

        
    }
}