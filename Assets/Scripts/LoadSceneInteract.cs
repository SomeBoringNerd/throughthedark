using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Fragsurf.Movement;
public class LoadSceneInteract : MonoBehaviour
{
    public Text interactText;
    public bool enter;

    public string sceneToLoad, flag;

    public InteractableScript interactable;

    public RawImage image;

    void Start()
    {
        
    }

    void Update()
    {
        if(interactText == null)
        {
            interactText = FindObjectOfType<PlayerScript>().InteractText;

            interactText.text = "";
        }

        if(image == null){
            image = FindObjectOfType<PlayerScript>().transitionScreen;
            image.gameObject.SetActive(false);
        }


        if(interactable.isUsable){
            interactText.text = "Press E to " + (enter ? "enter" : "exit");

            PlayerPrefs.SetString("flag", "UseAlternativeSpawnPoint");

            if(Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(Teleport());
            }
        }else{
            interactText.text = "";
        }
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
        GameGlobal.scenetoload = sceneToLoad;
        SceneManager.LoadScene("LoadingScene");
        yield return null;
    }
}
