using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
        just some dumb code to avoid the player falling.

        Might disable later idk
*/
public class NoFallScript : MonoBehaviour
{

    public GameObject player;
    
    // Update is called once per frame
    void Update()
    {
        base.gameObject.transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z);
    }
}
