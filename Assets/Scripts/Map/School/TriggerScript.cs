using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerScript : MonoBehaviour
{
    public DeterminePlayersPositionInSchoolScript PlayerPositionScript;

    public POSSIBLE_POSITION_OF_A_PLAYER TRIGGER_POSITION;

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            if (PlayerPositionScript != null)
            {
                PlayerPositionScript.POSSIBLE_POSITION_OF_A_PLAYER = TRIGGER_POSITION;
            }
            else
            {
                Debug.LogError("a trigger can't work because it lack the component DeterminePlayersPositionInSchoolScript so fix it !");
            }
        }
    }
}
