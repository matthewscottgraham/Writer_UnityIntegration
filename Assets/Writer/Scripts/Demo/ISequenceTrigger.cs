using System;

namespace Writer.Scripts.Demo
{
    public interface ISequenceTrigger
    {
        public static Action<string> OnTrigger;
        public string SequenceID { get; set; }
        public bool IsSingleUse { get; set; }
    }
}