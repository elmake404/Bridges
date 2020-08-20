using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Bottom : MonoBehaviour
{
    [SerializeField]
    private NavMeshSurface surface;
    [SerializeField]
    private PlayerContorol _player;

    public void StartGame()
    {
        surface.BuildNavMesh();
        _player.SetDestination();
        LevelManager.IsStartGame = true;
    }
}
