using UnityEngine;
using Writer.Scripts.Data;

namespace Writer.Scripts.ScriptableObjects
{
    public class SequenceInfo : ScriptableObject
    {
        [SerializeField] private Sequence sequence;
        public Sequence Sequence => sequence;

        public void Initialize(Sequence seq)
        {
            this.sequence = seq;
        }
    }
}