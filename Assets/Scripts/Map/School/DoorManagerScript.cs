using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DoorManagerScript : MonoBehaviour
{
    public DoorScript[] AllTheDoors;
    public Text DoorText;

    public bool OneOfTheDoorsIsInRangeOfThePlayer;

    void Start()
    {   // get every doorScript in the scene to enable them
        AllTheDoors = FindObjectsOfType<DoorScript>();

        foreach (DoorScript door in AllTheDoors)
        {
            door.gameObject.SetActive(true);
        }
    }

    void Update()
    {   // we check if the player is near one of the doors
        int tmp = 0;
        foreach(DoorScript door in AllTheDoors)
        {
            if (!door.playerIsNearTheDoor)
            {
                tmp++;
            }
        }
        // that mean that the player is near no door
        OneOfTheDoorsIsInRangeOfThePlayer = !(tmp == AllTheDoors.Length);

        // change the debug text to the correct text
        if (OneOfTheDoorsIsInRangeOfThePlayer)
        {
            DoorText.text = "Player is in range of one door";
        }
        else
        {
            DoorText.text = "Player is not in range of a door";
        }
    }
}
