using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsOfTheBeam : MonoBehaviour
{
    [SerializeField]
    private BeamControl _beamMain;
    [SerializeField]
    private List<BeamControl> _beamsConnections;
    private List<BeamControl> _beams = new List<BeamControl>();

    public bool IsStand, IsTightly;
    private int _connectionsEarth;
    private void FixedUpdate()
    {
        if (CountingConnections() > 0)
        {
            IsStand = true;
        }
        else
        {
            IsStand = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Earth")
        {
            _connectionsEarth++;
            IsTightly = true;
        }

        if (other.tag == "Beam" && other.gameObject.layer == 9)
        {
            BeamControl beam = other.transform.parent.GetComponent<BeamControl>();

            _beams.Add(beam);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Earth")
        {
            _connectionsEarth--;

            IsTightly = false;

        }
        if (other.tag == "Beam" && other.gameObject.layer == 9)
        {
            BeamControl beam = other.transform.parent.GetComponent<BeamControl>();
            if (_beams.Contains(beam))
            {
                _beams.Remove(beam);
            }
            if (_beamsConnections.Contains(beam))
            {
                _beamsConnections.Remove(beam);

            }
        }
    }
    private int CountingConnections()
    {
        int countConnections = _connectionsEarth;

        for (int i = 0; i < _beams.Count; i++)
        {
            if (_beams[i].Tightly())
            {
                if (!_beamsConnections.Contains(_beams[i]))
                {
                    _beamsConnections.Add(_beams[i]);
                }
            }
            if (_beams[i].IsQuiescently && !_beams[i].Tightly()
                && !_beamsConnections.Contains(_beams[i]) && _beams[i].ContainsBeam(_beamMain))
            {
                _beamsConnections.Add(_beams[i]);
            }

            if (!_beams[i].IsQuiescently && _beamsConnections.Contains(_beams[i]))
            {
                _beamsConnections.Remove(_beams[i]);
            }
            for (int j = 0; j < _beamsConnections.Count; j++)
            {
                countConnections++;
            }

        }

        return countConnections;
    }
    public bool ContainsMe(BeamControl beam)
    {
        return _beamsConnections.Contains(beam);
    }
}
