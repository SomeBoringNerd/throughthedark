using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DoorScript : MonoBehaviour
{
    // 0 = from inside the classroom || 1 = from outside
    public Transform[] OpenRotation;
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
                    // code to make the door swing both way depending of the player's position using the trigger system. 
                    // Check DeterminePlayersPositionInSchoolScript for more context
                    switch (PlayerPosScript.POSSIBLE_POSITION_OF_A_PLAYER)
                    {
                        case POSSIBLE_POSITION_OF_A_PLAYER.IN_A_CLASSROOM:
                            DOOR_OPENED_STATE = DOOR_OPENED_STATE.INSIDE;
                            DoorObject.transform.rotation = OpenRotation[0].rotation;
                            break;
                        default:
                            DOOR_OPENED_STATE = DOOR_OPENED_STATE.OUTSIDE;
                            DoorObject.transform.rotation = OpenRotation[1].rotation;
                            break;
                    }
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
    OUTSIDE,
    INSIDE,
    CLOSED
}
