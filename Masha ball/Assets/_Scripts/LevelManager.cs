using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class LevelManager : MonoBehaviour
{
    #region Static variables
    public static bool IsStartGame,IsStartFlowe,IsGameWin,IsGameLose;
    public static float Height/*,HeightUi*/;
    public static List<BeamControl> BeamControls;
    public static NavMeshSurface Surface;
    public static PlayerContorol Player;
    #endregion

    [SerializeField]
    private PlayerContorol _player;
    [SerializeField]
    private Transform _plane;
    [SerializeField]
    private NavMeshSurface _surface;


    void Awake()
    {
        //if (PlayerPrefs.GetInt("Level")<1)
        //{
        //PlayerPrefs.SetInt("Level",0 );
        //}

        IsGameLose = false;
        IsGameWin = false;
        IsStartGame = false;

        Player = _player;
        Surface = _surface;
        BeamControls = new List<BeamControl>();
        Height = Camera.main.transform.position.y - _plane.position.y;
    }

    public static bool CheckBeam()
    {
        for (int i = 0; i < BeamControls.Count; i++)
        {
            if (!BeamControls[i].IsQuiescently)
            {
                return false;
            }
        }
        return true;
    }
    public static void BeamOffFaces()
    {
        for (int i = 0; i < BeamControls.Count; i++)
        {
            BeamControls[i].OffFaces();
        }
    }
    public static bool EndOfTheGame()
    {
        if (IsGameWin||IsGameLose)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
