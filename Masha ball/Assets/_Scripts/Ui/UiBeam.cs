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
    [SerializeField]
    private Transform _anchor;
    private BeamControl _beamControl;
    private Camera _cam;
    

    [SerializeField]
    private float _climb;
    [SerializeField]
    private int _namberBeam;
    private float _width, _height;
    private bool _isCast;
    private void Awake()
    {
        if (_namberBeam <= 0)
        {
            gameObject.SetActive(false);
        }
    }
    void Start()
    {
        _textNamberBeam.text = _namberBeam.ToString();
        _cam = Camera.main;
        RectTransform rectTransform = GetComponent<RectTransform>();
        _width = _anchor.position.x - transform.position.x;

        _height = _anchor.position.x - transform.position.x;
    }

    void Update()
    {
        _textNamberBeam.text = _namberBeam.ToString();

        if (!LevelManager.IsStartGame && LevelManager.IsStartFlowe)
        {
            if (Input.GetMouseButtonDown(0) && (_namberBeam > 0))
            {
                if (Mathf.Abs(transform.position.x - Input.mousePosition.x) <= _width
                    && Mathf.Abs(transform.position.y -Input.mousePosition.y) <= _height)
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
                    _canvasManager.NewObjMov(_beamControl.transform, ray);


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
