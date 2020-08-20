using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    private Camera _cam;
    private Transform _objMoving;
    private Vector3 _oldPosObj, _startPosMouse;

    private bool _isCastDrag, _isCastTwist;
    private float _rotationY;

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
            if (Physics.Raycast(ray, out hit))
            {
                if ((hit.collider.tag == "Beam"))
                {
                    _isCastDrag = true;
                    _objMoving = hit.collider.transform.parent;
                    _oldPosObj = _objMoving.position;
                    _startPosMouse = (_cam.transform.position - ((ray.direction) *
                        (((22.21f) - 0.05f) / ray.direction.y)));
                }
                else if (hit.collider.tag == "Piston")
                {
                    _isCastTwist = true;

                    _objMoving = hit.collider.transform.parent;
                    _startPosMouse = (_cam.transform.position - ((ray.direction) *
                        (((22.21f) - 0.05f) / ray.direction.y)));
                    _rotationY = Quaternion.LookRotation(_startPosMouse - _objMoving.position).eulerAngles.y;
                }
            }
        }
        else if (Input.GetMouseButton(0))
        {
            if (_isCastDrag)
            {
                Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

                _objMoving.position = _oldPosObj + ((_cam.transform.position - ((ray.direction) *
                    (((22.21f) - 0.05f) / ray.direction.y))) - _startPosMouse);

            }
            if (_isCastTwist)
            {
                Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

                _startPosMouse = (_cam.transform.position - ((ray.direction) *
                    (((22.21f) - 0.05f) / ray.direction.y)));

                _objMoving.rotation = Quaternion.LookRotation(_startPosMouse - _objMoving.position);
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (_isCastDrag)
            {
                _isCastDrag = false;
                _objMoving = null;
            }
            if (_isCastTwist)
            {
                _isCastTwist = false;
                _objMoving = null;

            }
        }
    }

}
