using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveZone : MonoBehaviour
{
    [SerializeField]
    private CanvasManager _canvasManager;
    [SerializeField]
    private Transform _anchorX,_anchorY;

    private float _width, _height;

    private void Start()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        _width = _anchorX.position.x - transform.position.x;
        _height = Mathf.Abs(_anchorY.position.y - transform.position.y);
    }

    private void Update()
    {
        if (!LevelManager.IsStartGame && LevelManager.IsStartFlowe)
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (Mathf.Abs(transform.position.x - Input.mousePosition.x) <= _width
                    && Mathf.Abs(transform.position.y - Input.mousePosition.y) <= _height)
                {
                    _canvasManager.RemoveObjMove();
                }
            }
        }
    }
}
