using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/*
        >tried to make a loading screen with %age

        >locked the game in a while(true)

        >feelbad.png
*/
public class LoadingScript : MonoBehaviour
{

    public Text loadingText;

    // Start is called before the first frame update
    void Start()
    {
        loadingText.text = "Attempting to load " + GameGlobal.scenetoload + ". If it don't work after a while, please create an issue on https://discord.gg/gtfJY7uKCN with as much info as possible.";

        SceneManager.LoadSceneAsync(GameGlobal.scenetoload);
    }
}

