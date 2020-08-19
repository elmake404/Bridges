using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerContorol : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent _agent;
    [SerializeField]
    private Transform _target;
    [SerializeField]
    float f;
    void Start()
    {
        _agent.updatePosition = false;
        _agent.SetDestination(_target.position);
    }

    void FixedUpdate()
    {
        Vector3 Pos = new Vector3(_agent.steeringTarget.x, 0.5f, _agent.steeringTarget.z);
        f = (transform.position - Pos).magnitude;
        transform.position = Vector3.MoveTowards(transform.position, Pos, 0.1f);
        _agent.nextPosition = transform.position;

    }

}
