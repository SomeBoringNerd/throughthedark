using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Disclaimer : MonoBehaviour
{

    private bool Debug = false;

    int[] screenX = new int[]{
        1366,
        1366,
        1280,
        1920,
        1920
    };

    int[] screenY = new int[]{
        768,
        766,
        720,
        1080,
        1440
    };

    // used to launch the modhook functionality
    private void Start()
    {
        Screen.SetResolution(screenX[PlayerPrefs.GetInt("resolution", 2)], screenY[PlayerPrefs.GetInt("resolution", 2)], GameGlobal.fullscreen);
        Loader.Loader.Hook();
        
    }

    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.E)) return;

        //GameGlobal.scenetoload = Debug ? "SchoolScene" : "MainMenu";
        SceneManager.LoadScene("MainMenu");
        
    }
}
