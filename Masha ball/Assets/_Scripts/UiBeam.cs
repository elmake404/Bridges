using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiBeam : MonoBehaviour
{
    [SerializeField]
    private Transform _plane;
    [SerializeField]
    private GameObject _beam;
    private BeamControl _beamControl;
    private Camera _cam;

    private float _width, _height;
    private bool _isCast;
    void Start()
    {
        _cam = Camera.main;
        //_isCast = true;
        RectTransform rectTransform = GetComponent<RectTransform>();
        //Debug.Log(rectTransform.rect.height / 2);
        _width = rectTransform.rect.width / 2;
        _height = rectTransform.rect.height / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            if (Mathf.Abs((transform.position.x + _width) - Input.mousePosition.x) <= _width
                && Mathf.Abs((transform.position.y - _height) - Input.mousePosition.y) <= _height)
            {
                _isCast = true;
                Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _cam.transform.position.y - _plane.position.y);
                Vector3 posWorold = _cam.ScreenToWorldPoint(pos);
                posWorold.y = _plane.position.y;
                _beamControl = Instantiate(_beam, posWorold, _beam.transform.rotation).GetComponent<BeamControl>();
            }
        }
        else if (Input.GetMouseButton(0))
        {
            if (_isCast)
            {
                Vector3 pos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, _cam.transform.position.y - _plane.position.y);
                Vector3 posWorold = _cam.ScreenToWorldPoint(pos);
                posWorold.y = _plane.position.y+0.05f;

                _beamControl.transform.position = posWorold;
            }
        }
    }

}
