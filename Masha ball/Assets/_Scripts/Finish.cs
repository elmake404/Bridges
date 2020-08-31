using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField]
    private GameObject _finishComponent;
    [SerializeField]
    private Collider _bungCollider;
    [SerializeField]
    private MeshRenderer _bungMesh;
    public void Activation()
    {
        _bungCollider.isTrigger=true;
        _bungMesh.enabled = false;
        _finishComponent.SetActive(true);
    }
}
