using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fragsurf.Movement;
using UnityEngine.SceneManagement;

public class GoToSchool : MonoBehaviour
{

    public Text text;

    public GameObject Door, Player;

    public GameObject GUI_GET_OUT;

    public SurfCharacter playerMovement;

    public InteractableScript interactable;

    public PlayerAiming playerCamera;

    void Start()
    {
        text.text = string.Empty;
        Application.targetFrameRate = 60;
        GUI_GET_OUT.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (GUI_GET_OUT.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("LoadingScene");
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                GUI_GET_OUT.SetActive(false);
                playerMovement.canMove = true;
                playerCamera.canCameraMove = true;
            }
        }

        if (interactable.isUsable)
        {
            interactable.InteractableText[0].text = "Press E to go out";
            if (Input.GetKeyDown(KeyCode.E)){
                GUI_GET_OUT.SetActive(true);
                playerMovement.canMove = false;
                playerCamera.canCameraMove = false;
            }
        }
        else
        {
            interactable.InteractableText[0].text = string.Empty;
        }
    }
}
