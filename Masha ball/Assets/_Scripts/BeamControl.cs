using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamControl : MonoBehaviour
{
    public bool IsQuiescently;

    [SerializeField]
    private List<PartsOfTheBeam> _partsOfTheBeams;
    [SerializeField]
    private int _percentQuiescently;
    [SerializeField]
    private MeshRenderer _mesh;
    [SerializeField]
    private Material _materialNew, _materialOld;

    void Start()
    {
        _materialOld = _mesh.material;
    }
    void FixedUpdate()
    {
        if (Quiescently())
        {
            _mesh.material = _materialOld;
            IsQuiescently = true;
        }
        else
        {
            _mesh.material = _materialNew;

            IsQuiescently = false;
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
}
