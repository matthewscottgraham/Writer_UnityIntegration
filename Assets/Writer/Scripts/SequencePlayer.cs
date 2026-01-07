using UnityEngine;
using Writer.Scripts.Data;
using Writer.Scripts.Demo;
using Writer.Scripts.ScriptableObjects;

namespace Writer.Scripts
{
    public class SequencePlayer : MonoBehaviour
    {
        [SerializeField] private SequenceView view;
        private Sequence? _activeSequence;
        private int _activePassageIndex;

        private void OnEnable()
        {
            SequenceTrigger.OnTrigger += HandleTriggerSequence;
            view.OnContinue += NextPassage;
        }

        private void OnDisable()
        {
            SequenceTrigger.OnTrigger -= HandleTriggerSequence;
            view.OnContinue -= NextPassage;
        }

        private void HandleTriggerSequence(string sequenceID)
        {
            PlaySequence(LoadSequence(sequenceID));
        }

        private static Sequence? LoadSequence(string sequenceID)
        {
            var sequenceInfo = Resources.Load<SequenceInfo>($"Sequences/{sequenceID}");
            if (sequenceInfo == null) Debug.LogError($"Sequence \"{sequenceID}\" could not be loaded.");
            return sequenceInfo ? sequenceInfo.Sequence : null;
        }

        private void PlaySequence(Sequence? sequence)
        {
            _activeSequence = sequence;
            _activePassageIndex = 0;

            if (_activeSequence == null) return;

            view.DisplayPassage(_activeSequence.Value.passages[_activePassageIndex]);
        }

        private void NextPassage()
        {
            view.Close();
            if (_activeSequence == null) return;
            
            _activePassageIndex++;
            if (_activePassageIndex >= _activeSequence.Value.passages.Length)
            {
                return;
            }
            
            view.DisplayPassage(_activeSequence.Value.passages[_activePassageIndex]);
        }
    }
}