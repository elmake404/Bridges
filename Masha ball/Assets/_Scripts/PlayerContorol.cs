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
    void Start()
    {
        _agent.SetDestination(_target.position);
    }

    void Update()
    {
        
    }
}
