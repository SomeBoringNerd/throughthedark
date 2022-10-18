using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fragsurf.Movement;
public class waypointScript : MonoBehaviour
{

    public RawImage image;
    public GameObject player, target;
    /**
    *   <p> good luck figuring that out </p>
    */
    public int rotation;

    public Text teleportHud;

    void Start()
    {
        GameGlobal.PlayerIsNearADoor = false;
        teleportHud.text = "";

        image.color = new Color(0, 0, 0, 0);
    }
    void Update()
    {
        if(!(Vector3.Distance(player.transform.position, transform.position) <= 5)) return;
        teleportHud.text = ((Vector3.Distance(player.transform.position, transform.position) <= 4)) ? "Press E to take the stairs" : "";

        if(GameGlobal.PlayerIsNearADoor) return;
        if(!Input.GetKeyDown(KeyCode.E)) return;

        StartCoroutine(Teleport());
    }

    IEnumerator Teleport()
    {
        FindObjectOfType<SurfCharacter>().canMove = false;
        for(float i = 0; i < 255; i += 2)
        {
            image.color = new Color(0, 0, 0, i / 255);
            yield return new WaitForSeconds(0.0003921569f / 2);
        }
        player.transform.position = target.transform.position;
        player.transform.rotation = new Quaternion(0, rotation, 0, 1);
        for(float i = 255; i > 0; i -= 2)
        {
            Debug.Log(i);
            image.color = new Color(0, 0, 0, i / 255);
            yield return new WaitForSeconds(0.0003921569f / 2);
        }
        FindObjectOfType<SurfCharacter>().canMove = true;
        yield return null;
    }
}
