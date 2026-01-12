using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Writer.Scripts.Data;
using Writer.Scripts.Demo;
using Writer.Scripts.ScriptableObjects;

namespace Writer.Scripts
{
    public class SceneSetup : MonoBehaviour
    {
        [FormerlySerializedAs("sequenceInfo")] [SerializeField] private SceneInfo sceneInfo;
        [SerializeField] private PlayerInteractSequenceTrigger interactablePrefab;
        [SerializeField] private Transform sequenceObjectParent;
        
        private Dictionary<string, SequenceTrigger> _existingSequenceTriggers = new();
        
        public bool IsReady => sceneInfo != null;
        private Transform SequenceParent => sequenceObjectParent != null ? sequenceObjectParent : CreateSequenceParent();
        
        public void Execute()
        {
            if (sceneInfo == null)
            {
                Debug.LogError("SceneInfo is not assigned.");
                return;
            }
            
            _existingSequenceTriggers.Clear();
            FindExistingTriggers<SceneStartSequenceTrigger>();
            FindExistingTriggers<PlayerInteractSequenceTrigger>();
            
            SetupSequences();
        }

        private void FindExistingTriggers<T>() where T : SequenceTrigger
        {
            var triggers = FindObjectsByType<T>(FindObjectsInactive.Include, FindObjectsSortMode.None);
            foreach (var trigger in triggers)
            {
                if (!_existingSequenceTriggers.TryAdd(trigger.SequenceID, trigger))
                {
                    Debug.LogError($"Trigger '{trigger.SequenceID}' is already registered.");
                }
            }
        }

        private void SetupSequences()
        {
            foreach (var sequenceID in sceneInfo.SequenceIDs)
            {
                var sequenceInfo = Resources.Load<SequenceInfo>("Sequences/" + sequenceID);
                if (!sequenceInfo) continue;
                var sequence = sequenceInfo.Sequence;
                switch (sequence.invokeType)
                {
                    case InvokeType.SceneStart:
                        SetupSceneStartSequence(sequence);
                        break;
                    case InvokeType.Interaction:
                        SetupInteractionSequence(sequence);
                        break;
                    case InvokeType.Scripted:
                        break;
                    default:
                        Debug.LogWarning("Unknown sequence type.");
                        break;
                }
            }
        }
        
        private Transform CreateSequenceParent()
        {
            var parentObject = new GameObject("Sequences");
            sequenceObjectParent = parentObject.transform;
            return parentObject.transform;
        }

        private void SetupSceneStartSequence(Sequence sequence)
        {
            if (_existingSequenceTriggers.ContainsKey(sequence.id))
            {
                SetTriggerValues(_existingSequenceTriggers[sequence.id], sequence);
                return;
            }
            
            var sequenceObject = new GameObject(sequence.name);
            sequenceObject.transform.SetParent(SequenceParent, false);
            
            SetTriggerValues(
                sequenceObject.AddComponent<SceneStartSequenceTrigger>(), 
                sequence);
        }

        private void SetupInteractionSequence(Sequence sequence)
        {
            if (_existingSequenceTriggers.ContainsKey(sequence.id))
            {
                SetTriggerValues(_existingSequenceTriggers[sequence.id], sequence);
                return;
            }
            
            var sequenceObject = Instantiate(interactablePrefab, sequenceObjectParent);
            sequenceObject.name = sequence.name;
            sequenceObject.transform.SetParent(SequenceParent, false);
            
            SetTriggerValues(sequenceObject, sequence);
        }

        private static void SetTriggerValues(SequenceTrigger trigger, Sequence sequence)
        {
            trigger.SequenceID = sequence.id;
            trigger.IsSingleUse = sequence.isSingleUse;
        }
    }
}