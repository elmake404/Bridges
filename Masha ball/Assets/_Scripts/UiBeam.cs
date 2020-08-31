using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiBeam : MonoBehaviour
{
    [SerializeField]
    private CanvasManager _canvasManager;
    [SerializeField]
    private Text _textNamberBeam;
    [SerializeField]
    private GameObject _beam;
    private BeamControl _beamControl;
    private Camera _cam;

    [SerializeField]
    private float _climb;
    [SerializeField]
    private int _namberBeam;
    private float _width, _height;
    private bool _isCast;
    void Start()
    {
        _textNamberBeam.text = _namberBeam.ToString();
        _cam = Camera.main;
        RectTransform rectTransform = GetComponent<RectTransform>();
        _width = rectTransform.rect.width / 2;
        _height = rectTransform.rect.height / 2;
        //if (LevelManager.HeightUi < rectTransform.rect.height)
        //{
        //    LevelManager.HeightUi = rectTransform.rect.height;
        //}
    }

    void Update()
    {
        _textNamberBeam.text = _namberBeam.ToString();
        if (!LevelManager.IsStartGame)
        {
            if (Input.GetMouseButtonDown(0) && (_namberBeam > 0))
            {
                if (Mathf.Abs((transform.position.x + _width) - Input.mousePosition.x) <= _width
                    && Mathf.Abs((transform.position.y - _height) - Input.mousePosition.y) <= _height)
                {
                    _namberBeam--;
                    _isCast = true;
                    Ray ray = _cam.ScreenPointToRay(Input.mousePosition);

                    Vector3 posWorold = _cam.transform.position - ((ray.direction) *
                        ((LevelManager.Height - _climb) / ray.direction.y));
                    _beamControl = Instantiate(_beam, posWorold, _beam.transform.rotation).GetComponent<BeamControl>();
                    _beamControl.UiBeamMain = this;
                    LevelManager.BeamControls.Add(_beamControl);
                    _beamControl.OnFaces();
                    _canvasManager.NewObjMov(_beamControl.transform);

                }
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (_isCast)
                {
                    _isCast = false;
                    _beamControl = null;
                }
            }
        }
    }
    public void ReturnBeam()
    {
        _namberBeam++;
    }
}
