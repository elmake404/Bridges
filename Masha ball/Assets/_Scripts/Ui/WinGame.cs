using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinGame : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayerPrefs.SetInt("Level", PlayerPrefs.GetInt("Level") + 1);

            if (PlayerPrefs.GetInt("Level")>=SceneManager.sceneCountInBuildSettings)
            {
                PlayerPrefs.SetInt("Level", 1);
            }

            SceneManager.LoadScene(PlayerPrefs.GetInt("Level"));
        }
    }
}
