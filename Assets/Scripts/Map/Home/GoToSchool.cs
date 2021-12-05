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

    public PlayerAiming playerCamera;

    void Start()
    {
        text.text = string.Empty;
        GUI_GET_OUT.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(Door.transform.position, Player.transform.position) < 3.5)
        {
            text.text = GUI_GET_OUT.activeSelf ? "Press E to travel where you want (q to quit)" : "Press E to go out";
            if (Input.GetKeyDown(KeyCode.E)){
                GUI_GET_OUT.SetActive(true);
                playerMovement.canMove = false;
                playerCamera.canCameraMove = false;
            }
            if (Input.GetKeyDown(KeyCode.Q) && GUI_GET_OUT.activeSelf)
            {
                GUI_GET_OUT.SetActive(false);
                playerMovement.canMove = true;
                playerCamera.canCameraMove = true;
            }

        }
        else
        {
            text.text = string.Empty;
        }




        if (GUI_GET_OUT.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("LoadingScene");
            }
        }
    }
}
