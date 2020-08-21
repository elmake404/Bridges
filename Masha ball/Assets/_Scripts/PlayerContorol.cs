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
    private Vector3 _nextTarget;

    private float _timeCheckDestination;
    void Start()
    {
        _timeCheckDestination = 0.5f;
        _nextTarget = transform.position;
    }

    void FixedUpdate()
    {
        if (LevelManager.IsStartGame)
        {
            Vector3 Pos = new Vector3(_agent.steeringTarget.x, 0.5f, _agent.steeringTarget.z);
            transform.position = Vector3.MoveTowards(transform.position, Pos, 0.1f);
            _agent.nextPosition = transform.position;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Stars")
        {
            Destroy(other.gameObject);
            _agent.SetDestination(_nextTarget);
        }
    }

    public void SetDestination()
    {
        _agent.updatePosition = false;
        _agent.SetDestination(_target.position);
    }

}
