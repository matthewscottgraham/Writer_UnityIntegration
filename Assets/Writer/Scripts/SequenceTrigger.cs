using System;
using UnityEngine;

namespace Writer.Scripts.Demo
{
    public class SequenceTrigger : MonoBehaviour
    {
        public static Action<string> OnTrigger;
        
        [SerializeField] private string sequenceID;
        [SerializeField] private bool isSingleUse;
        private bool _wasTriggered = false;
        
        public string SequenceID
        {
            get => sequenceID;
            set => sequenceID = value;
        }
        public bool IsSingleUse
        {
            get => isSingleUse;
            set => isSingleUse = value;
        }

        protected void TriggerSequence()
        {
            if (IsSingleUse && _wasTriggered) return;
            OnTrigger?.Invoke(SequenceID);
            _wasTriggered = true;
        }
    }
}