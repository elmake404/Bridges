using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class LevelManager : MonoBehaviour
{
    #region Static variables
    public static bool IsStartGame;
    public static float Height/*,HeightUi*/;
    public static List<BeamControl> BeamControls;
    public static NavMeshSurface Surface;
    #endregion
    [SerializeField]
    private Transform _plane;
    [SerializeField]
    private NavMeshSurface _surface;


    void Awake()
    {
        Surface = _surface;
        BeamControls = new List<BeamControl>();
        Height = Camera.main.transform.position.y - _plane.position.y;
        IsStartGame = false;
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
}
