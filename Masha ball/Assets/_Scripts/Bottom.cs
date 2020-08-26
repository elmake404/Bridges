using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bottom : MonoBehaviour
{
    [SerializeField]
    private PlayerContorol _player;

    public void StartGame()
    {
        if (LevelManager.CheckBeam())
        {
            LevelManager.BeamOffFaces();
            LevelManager.Surface.BuildNavMesh();
            _player.SetDestination();
            LevelManager.IsStartGame = true;
        }
        else
        {
            Debug.Log("Not all beams are standing");
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
