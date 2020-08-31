using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour
{
    private Camera _cam;
    private Transform _objMoving;
    private Vector3 _oldPosObj, _startPosMouse;
    [SerializeField]
    private RectTransform _removalZone;

    private bool _isCastDrag, _isCastTwist;
    private float _rotationY, _height, _width;

    void Start()
    {
        RectTransform rect = GetComponent<RectTransform>();
        _height = rect.rect.height;
        _width = rect.rect.width;
        _cam = Camera.main;

    }

    void Update()
    {
        if (!LevelManager.IsStartGame)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                {
                    if ((hit.collider.tag == "Beam"))
                    {
                        if (_objMoving == null)
                        {
                            _objMoving = hit.collider.transform.parent;
                            _objMoving.GetComponent<BeamControl>().OnFaces();
                        }
                        else
                        {
                            if (_objMoving.gameObject != hit.collider.transform.parent.gameObject)
                            {
                                _objMoving.GetComponent<BeamControl>().OffFaces();
                                _objMoving = hit.collider.transform.parent;
                                _objMoving.GetComponent<BeamControl>().OnFaces();
                            }
                        }

                        _isCastDrag = true;
                        _oldPosObj = _objMoving.position;
                        _startPosMouse = (_cam.transform.position - ((ray.direction) *
                            ((LevelManager.Height - 0.04f) / ray.direction.y)));
                    }
                    else if (_objMoving != null)
                    {
                        _isCastTwist = true;

                        //_objMoving = hit.collider.transform.parent;
                        _startPosMouse = (_cam.transform.position - ((ray.direction) *
                            ((LevelManager.Height - 0.04f) / ray.direction.y)));
                        _rotationY = _objMoving.eulerAngles.y;
                    }
                }
            }
            else if (Input.GetMouseButton(0))
            {
                if (_isCastDrag)
                {
                    Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

                    _objMoving.position = _oldPosObj + ((_cam.transform.position - ((ray.direction) *
                        ((LevelManager.Height - 0.04f) / ray.direction.y))) - _startPosMouse);

                }

                if (_isCastTwist && !_isCastDrag)
                {
                    Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

                    Vector3 nextPos = (_cam.transform.position - ((ray.direction) *
                        ((LevelManager.Height - 0.04f) / ray.direction.y)));

                    float Y = _rotationY + (Quaternion.LookRotation(nextPos - _objMoving.position).eulerAngles.y)
                        - Quaternion.LookRotation(_startPosMouse - _objMoving.position).eulerAngles.y;
                    _objMoving.eulerAngles = new Vector3(_objMoving.eulerAngles.x, Y, _objMoving.eulerAngles.z);
                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (_isCastDrag && _objMoving != null
                    && Input.mousePosition.y > (_height - _removalZone.rect.height)
                    && Input.mousePosition.x < (_removalZone.rect.width))
                {
                    BeamControl beam = _objMoving.GetComponent<BeamControl>();
                    beam.UiBeamMain.ReturnBeam();
                    LevelManager.BeamControls.Remove(beam);
                    Destroy(_objMoving.gameObject);
                    _objMoving = null;
                }

                //Debug.Log(Input.mousePosition.x);
                //Debug.Log(_removalZone.rect.width );
                //Debug.Log("---------------------------------------------");
                //Debug.Log(Input.mousePosition.y);
                //Debug.Log(_height - _removalZone.rect.height);

                if (_isCastDrag)
                {
                    _isCastDrag = false;
                }
                if (_isCastTwist)
                {
                    _isCastTwist = false;
                }
            }

        }
    }

    public void NewObjMov(Transform transform)
    {
        if (_objMoving != null)
        {
            _objMoving.GetComponent<BeamControl>().OffFaces();
        }
        _objMoving = transform;
        _isCastDrag = true;
    }

}
