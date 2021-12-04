using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DoorScript : MonoBehaviour
{
    // 0 = from inside the classroom || 1 = from outside
    public Transform OpenRotation;
    public Transform ClosedTransform;

    // explicit
    public DOOR_OPENED_STATE DOOR_OPENED_STATE;

    // Distance calculation
    public GameObject DoorObject;
    public GameObject PlayerObject;

    // debug stuff
    public Text onScreenDoorIndicator;

    // bools
    public bool DoorIsOpen, playerIsNearTheDoor;

    // Script for position related stuff
    public DeterminePlayersPositionInSchoolScript PlayerPosScript;


    public void Start()
    {
        // close all door
        DOOR_OPENED_STATE = DOOR_OPENED_STATE.CLOSED;
        DoorObject.transform.rotation = ClosedTransform.rotation;
        playerIsNearTheDoor = false;
    }

    public void Update()
    {
        // check for distance
        if(Vector3.Distance(PlayerObject.transform.position, DoorObject.transform.position) <= 3)
        {
            // check DoorManagerScript for more informations about the context of usage of that variable
            playerIsNearTheDoor = true;
            // wait for input
            if (Input.GetKeyDown(KeyCode.E))
            {   // open or close the door depending of it's state
                if (!DoorIsOpen) 
                {
                    DoorIsOpen = true;

                    DOOR_OPENED_STATE = DOOR_OPENED_STATE.OPEN;
                    DoorObject.transform.rotation = OpenRotation.rotation;

                }
                else
                {   // close door
                    DoorIsOpen = false;
                    DOOR_OPENED_STATE = DOOR_OPENED_STATE.CLOSED;
                    DoorObject.transform.rotation = ClosedTransform.rotation;
                }
            }
        }
        else
        {
            playerIsNearTheDoor = false;
        }
    }
}

public enum DOOR_OPENED_STATE
{
    OPEN,
    CLOSED
}
