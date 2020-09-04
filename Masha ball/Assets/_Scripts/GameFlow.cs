using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameFlow : MonoBehaviour
{
    private void Awake()
    {
        if ((PlayerPrefs.GetInt("Level") <= 0) || PlayerPrefs.GetInt("Level") >= SceneManager.sceneCountInBuildSettings)
        {
            PlayerPrefs.SetInt("Level", 1);
        }

        SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));

    }
}
