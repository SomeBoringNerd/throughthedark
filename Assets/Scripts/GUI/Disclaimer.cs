using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Disclaimer : MonoBehaviour
{

    private bool Debug = false;

    // used to launch the modhook functionality
    private void Start()
    {
        Loader.Loader.Hook();
    }

    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.E)) return;

        GameGlobal.scenetoload = Debug ? "SchoolScene" : "MainMenu";
        SceneManager.LoadScene("LoadingScene");
    }
}
