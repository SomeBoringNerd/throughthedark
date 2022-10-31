using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fragsurf.Movement;
using UnityEngine.SceneManagement;
/*
        that code give me nightmares
*/
public class GoToSchool : MonoBehaviour
{

    public Text text;

    public GameObject Door, Player;

    public GameObject GUI_GET_OUT;

    public SurfCharacter playerMovement;

    public InteractableScript interactable;

    public PlayerAiming playerCamera;

    public RawImage image;

    void Start()
    {
        //text.text = string.Empty;
        GUI_GET_OUT.SetActive(false);
        Close();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerCamera == null || playerMovement == null){
            playerCamera = FindObjectOfType<PlayerScript>().playerCam;
            playerMovement = FindObjectOfType<PlayerScript>().playerBody;
        }

        if(image == null){
            image = FindObjectOfType<PlayerScript>().transitionScreen;
            image.gameObject.SetActive(false);
        }

        if (GUI_GET_OUT.activeSelf)
        {
            /*

            what the fuck is that 

            it reload the scene and serve no purpose

            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("LoadingScene");
            }
            */
            if (Input.GetKeyDown(KeyCode.Q))
            {
                GUI_GET_OUT.SetActive(false);
                playerMovement.canMove = true;
                playerCamera.canCameraMove = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        if (interactable.isUsable)
        {
            interactable.InteractableText[0].text = "Press E to go out";
            if (Input.GetKeyDown(KeyCode.E)){
                GUI_GET_OUT.SetActive(true);
                playerMovement.canMove = false;
                playerCamera.canCameraMove = false;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
            }
        }
        else
        {
            interactable.InteractableText[0].text = string.Empty;
        }
    }

    public void LoadNewScene(string scene){
        StartCoroutine(Teleport(scene));
    }

    IEnumerator Teleport(string scene)
    {
        FindObjectOfType<SurfCharacter>().canMove = false;
        image.gameObject.SetActive(true);
        for(float i = 0; i < 255; i += 4)
        {
            image.color = new Color(0, 0, 0, i / 255);
            yield return new WaitForSeconds(0.0003921569f / 2);
        }

        image.color = new Color(0, 0, 0, 255);

        GameGlobal.scenetoload = scene;
        SceneManager.LoadScene("LoadingScene");
        yield return null;
    }

    public void Close()
    {
        GUI_GET_OUT.SetActive(false);
        playerMovement.canMove = true;
        playerCamera.canCameraMove = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
