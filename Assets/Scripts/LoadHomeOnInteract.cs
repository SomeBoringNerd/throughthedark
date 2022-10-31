using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fragsurf.Movement;
/*
        quite explcit
*/
public class LoadHomeOnInteract : MonoBehaviour
{
    
    public InteractableScript interaction;
    public string SceneToLoad;

    public RawImage image;
    
    void Update()
    {
        if(image == null){
            image = FindObjectOfType<PlayerScript>().transitionScreen;
            image.gameObject.SetActive(false);
        }

        if(!(interaction.isUsable && Input.GetKeyDown(KeyCode.E))) return;
        PlayerPrefs.SetString("flag", "UseAlternativeSpawnPoint");

        StartCoroutine(Teleport());
    }

    IEnumerator Teleport()
    {
        FindObjectOfType<SurfCharacter>().canMove = false;
        image.gameObject.SetActive(true);
        for(float i = 0; i < 255; i += 4)
        {
            image.color = new Color(0, 0, 0, i / 255);
            yield return new WaitForSeconds(0.0003921569f / 2);
        }
        image.color = new Color(0, 0, 0, 255);
        GameGlobal.scenetoload = SceneToLoad;
        SceneManager.LoadScene("LoadingScene");
        yield return null;
    }
}
