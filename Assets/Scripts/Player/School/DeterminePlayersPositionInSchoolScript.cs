using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeterminePlayersPositionInSchoolScript : MonoBehaviour
{
    public Text PositionText;

    public Transform PlayerTransform;

    public POSSIBLE_POSITION_OF_A_PLAYER POSSIBLE_POSITION_OF_A_PLAYER;

    //teleport only
    public void TeleportPlayer(float x, float y, float z)
    {
        PlayerTransform.transform.position = new Vector3(x, y, z);
    }

    //teleport with rotation
    public void TeleportPlayer(float x, float y, float z, float rot_x, float rot_y, float rot_z)
    {
        PlayerTransform.transform.position = new Vector3(x, y, z);
        PlayerTransform.transform.rotation = new Quaternion(x, y, z, 1);
    }

    //make a player look at someething
    public void ForcePlayerToLookAt(Transform stuff)
    {
        PlayerTransform.LookAt(stuff);
    }

    //update some texte
    public void Update()
    {
        PositionText.text = POSSIBLE_POSITION_OF_A_PLAYER.ToString();
    }

}

public enum POSSIBLE_POSITION_OF_A_PLAYER
{
    IN_THE_SCHOOL,
    IN_A_CLASSROOM
}