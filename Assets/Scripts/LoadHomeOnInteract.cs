using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
        quite explcit
*/
public class LoadHomeOnInteract : MonoBehaviour
{
    
    public InteractableScript interaction;
    public string SceneToLoad;

    void Update()
    {
        if(!(interaction.isUsable && Input.GetKeyDown(KeyCode.E)))

        GameGlobal.scenetoload = SceneToLoad;
        SceneManager.LoadScene("LoadingScene");
    }
}
