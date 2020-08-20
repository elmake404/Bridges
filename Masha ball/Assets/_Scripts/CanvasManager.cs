using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    private Camera _cam;
    private Transform _objMoving;
    private Vector3 _oldPosObj,_startPosMouse;

    private bool _isCast;

    void Start()
    {
        _cam = Camera.main;

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit)&&(hit.collider.tag=="Beam"))
            {
                _isCast = true;
                _objMoving = hit.collider.transform.parent;
                _oldPosObj = _objMoving.position;
                _startPosMouse = (_cam.transform.position - ((ray.direction) *
                    (((22.21f) - 0.05f) / ray.direction.y)));
            }
        }
        else if (Input.GetMouseButton(0))
        {
            if (_isCast)
            {
                Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

                _objMoving.position = _oldPosObj + ((_cam.transform.position - ((ray.direction) *
                    (((22.21f) - 0.05f) / ray.direction.y)))- _startPosMouse);

            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (_isCast)
            {
                _isCast = false;
                _objMoving = null;
            }
        }
    }

}
