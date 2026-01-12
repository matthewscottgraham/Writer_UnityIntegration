using System;
using UnityEngine;

namespace Writer.Scripts.Demo
{
    public class SceneStartSequenceTrigger : SequenceTrigger
    {
        private void Start()
        {
            TriggerSequence();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position + Vector3.up, 1f);
        }
    }
}