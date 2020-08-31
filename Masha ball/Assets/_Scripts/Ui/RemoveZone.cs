using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveZone : MonoBehaviour
{
    [SerializeField]
    private CanvasManager _canvasManager;
    private float _width, _height;

    void Start()
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        _width = rectTransform.rect.width / 2;
        _height = rectTransform.rect.height / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (!LevelManager.IsStartGame && LevelManager.IsStartFlowe)
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (Mathf.Abs((transform.position.x + _width) - Input.mousePosition.x) <= _width
                    && Mathf.Abs((transform.position.y - _height) - Input.mousePosition.y) <= _height)
                {
                    _canvasManager.RemoveObjMove();
                }
            }
        }
    }
}
