using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WaypointScript : MonoBehaviour
{

    public GameObject destination, player;
    public RawImage black;

    private float speed = 0.000075f;

    public float rot;

    void Start()
    {
        black.color = new Color(0, 0, 0, 0.5f);
        GameGlobal.PlayerIsInWaypoint = false;
    }

    void OnTriggerStay(Collider other)
    {
        //if(other.tag == "Player"){
            Debug.Log("Player is in range");
            if(Input.GetKeyDown(KeyCode.E) && !GameGlobal.PlayerIsInWaypoint)
            {
                GameGlobal.PlayerIsInWaypoint = true;
                StartCoroutine(teleport());
            }
        //}
    }

    IEnumerator teleport()
    {
        for(float i = 128; i <= 255; i++)
        {
            black.color = new Color(0, 0, 0, i/255);
            Debug.Log(i);
            yield return new WaitForSeconds(speed);
        }

        player.transform.position = destination.transform.position;

        player.transform.rotation = new Quaternion(0, rot, 0, 1);

        Debug.Log("player's rotation is now " + player.transform.rotation.y);

        for(float i = 255; i >= 128; i--)
        {
            black.color = new Color(0, 0, 0, i/255);
            Debug.Log(i);
            yield return new WaitForSeconds(speed);
        }
        GameGlobal.PlayerIsInWaypoint = false;
        yield return null;
    }
}
