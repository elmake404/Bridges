using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamControl : MonoBehaviour
{
    public bool IsQuiescently;

    private int _percentQuiescently;

    void Start()
    {

    }

    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Earth")
        {
            _percentQuiescently++;
        }
        if (other.tag == "Beam")
        {
            if (other.GetComponent<BeamControl>().IsQuiescently)
                _percentQuiescently++;
        }
        if (_percentQuiescently >= 2)
        {
            IsQuiescently = true;
        }
    }
}
