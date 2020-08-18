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
    private Vector3 _agentTarget;
    [SerializeField]
    List<Vector3> _way = new List<Vector3>(); 

    void Start()
    {
        _agent.updatePosition = false;
        _agent.SetDestination(_target.position);
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RecordsWay();
        }
        //transform.position = Vector3.MoveTowards(transform.position, _agent.steeringTarget, 0.1f);
    }

    private void RecordsWay()
    {
        while (_way.Count<12)
        {
            _agent.nextPosition = _agent.steeringTarget;
            if (_agent.steeringTarget != _agentTarget)
            {
                _agentTarget = _agent.steeringTarget;
                _way.Add(_agentTarget);
            }

        }
    }
}
