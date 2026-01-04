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
        
        private Dictionary<string, ISequenceTrigger> _existingSequenceTriggers = new();
        
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

        private void FindExistingTriggers<T>() where T : Component, ISequenceTrigger
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
            foreach (var sequence in sceneInfo.Sequences)
            {
                switch (sequence.invokeOn)
                {
                    case InvokeType.sceneStart:
                        SetupSceneStartSequence(sequence);
                        break;
                    case InvokeType.interaction:
                        SetupInteractionSequence(sequence);
                        break;
                    case InvokeType.scripted:
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
            if (_existingSequenceTriggers.ContainsKey(sequence.Id))
            {
                SetTriggerValues(_existingSequenceTriggers[sequence.Id], sequence);
                return;
            }
            
            var sequenceObject = new GameObject(sequence.Name);
            sequenceObject.transform.SetParent(SequenceParent, false);
            
            SetTriggerValues(
                sequenceObject.AddComponent<SceneStartSequenceTrigger>(), 
                sequence);
        }

        private void SetupInteractionSequence(Sequence sequence)
        {
            if (_existingSequenceTriggers.ContainsKey(sequence.Id))
            {
                SetTriggerValues(_existingSequenceTriggers[sequence.Id], sequence);
                return;
            }
            
            var sequenceObject = Instantiate(interactablePrefab, sequenceObjectParent);
            sequenceObject.name = sequence.Name;
            sequenceObject.transform.SetParent(SequenceParent, false);
            
            SetTriggerValues(sequenceObject, sequence);
        }

        private static void SetTriggerValues(ISequenceTrigger trigger, Sequence sequence)
        {
            trigger.SequenceID = sequence.Id;
            trigger.IsSingleUse = sequence.isSingleUse;
        }
    }
}