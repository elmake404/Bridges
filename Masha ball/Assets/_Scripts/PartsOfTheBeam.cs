using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsOfTheBeam : MonoBehaviour
{
    public bool IsStand, IsTightly;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Earth")
        {
            IsStand = true;
        }

        if (other.tag == "Beam")
        {
            if (other.transform.parent.GetComponent<BeamControl>().IsQuiescently)
            {
                IsStand = true;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Earth")
        {
            IsStand = false;
        }
        if (other.tag == "Beam")
        {
            BeamControl beam = other.transform.parent.GetComponent<BeamControl>();

            if (beam.IsQuiescently)
                IsStand = false;
        }

    }


}
