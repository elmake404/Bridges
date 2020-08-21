using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region Static variables
    public static bool IsStartGame;
    public static float Height,HeightUi;
    public static List<BeamControl> BeamControls;
    #endregion
    [SerializeField]
    private Transform _plane;

    void Awake()
    {
        BeamControls = new List<BeamControl>();
        Height = Camera.main.transform.position.y - _plane.position.y;
        IsStartGame = false;
    }

    void Update()
    {
        
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
}
