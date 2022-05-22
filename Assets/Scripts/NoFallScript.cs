using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoFallScript : MonoBehaviour
{

    public GameObject player;
    
    // Update is called once per frame
    void Update()
    {
        base.gameObject.transform.position = new Vector3(player.transform.position.x, 0, player.transform.position.z);
    }
}
