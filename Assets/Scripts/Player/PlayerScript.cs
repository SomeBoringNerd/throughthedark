using UnityEngine;
using UnityEngine.UI;
using Fragsurf.Movement;
using System.Collections;
using System.Collections.Generic;
public class PlayerScript : MonoBehaviour 
{
    [HideInInspector]
    public string aaaNote = "That script contain variables for scripts due to how player is spawned";
    public AudioClip[] footsteps;

    public AudioSource foots;

    public GameObject getOutScreen, writtingBook, playerInstance;

    public PlayerAiming playerCam;

    public RawImage transitionScreen;
    public SurfCharacter playerBody;

    public Text InteractText;

    void Start(){
        StartCoroutine(Anim());
    }

    IEnumerator Anim()
    {
        transitionScreen.gameObject.SetActive(true);
        transitionScreen.color = new Color(0, 0, 0, 255);
        for(float i = 255; i > 0; i -= 1)
        {
            transitionScreen.color = new Color(0, 0, 0, i / 255);
            yield return new WaitForSeconds(0.001f);
        }
        transitionScreen.color = new Color(0, 0, 0, 0);
        transitionScreen.gameObject.SetActive(false);
        yield return null;
    }
}