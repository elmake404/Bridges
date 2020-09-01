using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class PlayerContorol : MonoBehaviour
{
    [SerializeField]
    private Finish _finish;
    [SerializeField]
    private NavMeshAgent _agent;
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private Rigidbody _rb;
    private Vector3 _nextTarget, _currentTarget;
    

    private float _timeCheckDestination;
    void Start()
    {
        _timeCheckDestination = 0.3f;
        _nextTarget = transform.position;
    }

    void FixedUpdate()
    {
        if (LevelManager.IsStartGame)
        {
            if (_timeCheckDestination <= 0)
            {
                if (_agent.hasPath)
                {
                    Vector3 Pos = new Vector3(_agent.steeringTarget.x, transform.position.y, _agent.steeringTarget.z);
                    transform.position = Vector3.MoveTowards(transform.position, Pos, 0.1f);
                    _agent.nextPosition = transform.position;
                }
                else
                {
                    _rb.isKinematic = false;
                    Vector3 Pos = new Vector3(_currentTarget.x, transform.position.y, _currentTarget.z);
                    transform.position = Vector3.MoveTowards(transform.position, Pos, 0.1f);
                }
            }
            if (_timeCheckDestination>0)
            {
                _timeCheckDestination -= Time.fixedDeltaTime;
            }
        }
        else
        {
            if (transform.position.y>0.5f)
            {
                Vector3 pos = transform.position;
                pos.y = 0.5f;
                transform.position = Vector3.MoveTowards(transform.position,pos,0.1f);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Stars")
        {
            _finish.Activation();
            StartCoroutine(GoBack());
            Destroy(other.gameObject);
        }
        if (other.tag == "Water")
        {
            LevelManager.IsStartGame = false;
            LevelManager.IsGameLose = true;
        }
        if (other.tag == "Finish")
        {
            LevelManager.IsGameWin = true;
            _rb.isKinematic = false;
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Beam" && other.gameObject.layer == 10)
        {
            Destroy(other.transform.parent.gameObject);
        }
    }
    private IEnumerator GoBack()
    {
        yield return new WaitForSeconds(0.3f);

        LevelManager.Surface.BuildNavMesh();
        _currentTarget = _nextTarget;

        //yield return new WaitForSeconds(0.6f);
        _agent.SetDestination(_nextTarget);
        _timeCheckDestination = 0.3f;

    }
    public void SetDestination()
    {       
        _currentTarget = _target.position;
        _agent.updatePosition = false;
        _agent.SetDestination(_target.position);
    }

}
