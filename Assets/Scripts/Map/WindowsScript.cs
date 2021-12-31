using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindowsScript : MonoBehaviour
{

    public InteractableScript interaction;
    public DOOR_OPENED_STATE WINDOWS_STATE;
    public GameObject[] Windows;

    public void Start()
    {
        Windows[1].SetActive(false);
    }

    void Update()
    {
        if(interaction.isUsable)
        {
            foreach(Text text in interaction.InteractableText) { 
                text.text = "press E to " + (WINDOWS_STATE == DOOR_OPENED_STATE.OPEN ? "close" : "open");
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                WINDOWS_STATE = (WINDOWS_STATE == DOOR_OPENED_STATE.OPEN ? DOOR_OPENED_STATE.CLOSED : DOOR_OPENED_STATE.OPEN);

                Windows[(WINDOWS_STATE == DOOR_OPENED_STATE.OPEN ? 1 : 0)].SetActive(true);
                Windows[(WINDOWS_STATE == DOOR_OPENED_STATE.OPEN ? 0 : 1)].SetActive(false);
            }
        }
    }
}
