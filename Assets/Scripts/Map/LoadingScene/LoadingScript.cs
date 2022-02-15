using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{

    public Text loadingText;

    // Start is called before the first frame update
    void Start()
    {
        loadingText.text = "Attempting to load " + GameGlobal.scenetoload + ". If it don't work after a while, please create an issue on https://github.com/SomeBoringNerd/throughthedark with as much info as possible.";

        SceneManager.LoadSceneAsync(GameGlobal.scenetoload);
    }
}

