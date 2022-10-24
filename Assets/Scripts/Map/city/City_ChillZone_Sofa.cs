using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// @TODO : make a special camera that follow the player cursor with delay, but allow for cursor to show up
// @TODO : Make so ordering stuff cost money to the player

public class City_ChillZone_Sofa : MonoBehaviour
{

    public InteractableScript interactable;

    public City_ChillZone_InteractPanel panel;

    public GameObject player, cam, interactPanel;

    // Start is called before the first frame update
    void Start()
    {
        if(interactable == null) {
            interactable = GetComponent<InteractableScript>();
        }


        if(interactable == null) {
            Debug.LogError("this game object " + name + " is supposed to use InteractableScript but none was found, please fix it ASAP");
        }

        if(cam == null) {
            Debug.LogError("this game object " + name + " require a camera to work but none was found, please fix ASAP");
        }else{
            cam.SetActive(false);
        }

        if(player == null) {
            Debug.LogError("this game object " + name + " need a reference to the player but none was found, please fix ASAP");
        }
        /*
        if(interactPanel == null) {
            Debug.LogError("this game object " + name + " require a reference to the List of stuff the player can buy but none was found, please fix ASAP");
        }

        if(panel == null) {
            Debug.LogError("this game object " + name + " require a reference to the panel class but none was found, please fix ASAP");
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if(!(interactable.isUsable && Input.GetKeyDown(KeyCode.E))) return;

        player.SetActive(false);
        cam.SetActive(true);
    }
}
