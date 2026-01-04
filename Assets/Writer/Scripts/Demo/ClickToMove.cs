using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

[RequireComponent(typeof(NavMeshAgent))]
public class ClickToMove : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    private NavMeshAgent _agent;
    private Camera _cam;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _cam = Camera.main;
    }

    private void Update()
    {
        if (Pointer.current == null || !Pointer.current.press.wasPressedThisFrame) return;
        SetDestination();
    }

    private void SetDestination()
    {
        var ray = _cam.ScreenPointToRay(Pointer.current.position.ReadValue());
        if (Physics.Raycast(ray, out RaycastHit hit, 100, layerMask))
        {
            _agent.destination = hit.point;
        }
    }
}
