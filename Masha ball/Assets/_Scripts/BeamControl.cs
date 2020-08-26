using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamControl : MonoBehaviour
{
    public bool IsQuiescently;

    [SerializeField]
    private GameObject _faces;
    [SerializeField]
    private List<PartsOfTheBeam> _partsOfTheBeams;
    [SerializeField]
    private int _percentQuiescently;
    [SerializeField]
    private MeshRenderer _mesh;
    [SerializeField]
    private Material _materialNew, _materialOld;

    [SerializeField]
    private float _timeToStand;
    private float _timeToStandConst;

    void Start()
    {
        _timeToStandConst = _timeToStand;

        _materialOld = _mesh.material;
    }
    void FixedUpdate()
    {
        if (LevelManager.IsStartGame)
        {
            if (!Quiescently())
            
                Destroy(gameObject);
        }

        if (Quiescently()&& _timeToStand<=0)
        {
            _mesh.material = _materialOld;
            IsQuiescently = true;
        }
        else
        {
            if(!Quiescently())
            _timeToStand = _timeToStandConst;

            _mesh.material = _materialNew;

            IsQuiescently = false;
        }
        if (_timeToStand>0)
        {
            _timeToStand -= Time.fixedDeltaTime;
        }
    }
    private bool Quiescently()
    {
        for (int i = 0; i < _partsOfTheBeams.Count; i++)
        {
            if (!_partsOfTheBeams[i].IsStand)
            {
                return false;
            }
        }
        return true;
    }
    public bool Tightly()
    {
        for (int i = 0; i < _partsOfTheBeams.Count; i++)
        {
            if (!_partsOfTheBeams[i].IsTightly)
            {
                return false;
            }
        }
        return true;
    }
    public bool ContainsBeam(BeamControl beam)
    {
        for (int i = 0; i < _partsOfTheBeams.Count; i++)
        {
            if (_partsOfTheBeams[i].ContainsMe(beam))
            {
                return false;
            }
        }
        return true;
    }
    public void OnFaces()
    {
        _faces.SetActive(true);
    }
    public void OffFaces()
    {
        _faces.SetActive(false);
    }
}
