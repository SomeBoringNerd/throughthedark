using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public GameObject debug_menu;

    public GameObject Player, item_showcase_object, player_spawn_school;

    void Start()
    {
        debug_menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (debug_menu.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.F1))
            {
                Player.transform.position = item_showcase_object.transform.position;
                Player.transform.rotation = item_showcase_object.transform.rotation;

                debug_menu.SetActive(false);
            }else if (Input.GetKeyDown(KeyCode.F2))
            {
                Player.transform.position = player_spawn_school.transform.position;
                Player.transform.rotation = player_spawn_school.transform.rotation;

                debug_menu.SetActive(false);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Asterisk))
            {
                debug_menu.SetActive(true);
            }
        }


        if(Player.transform.position.y < -50)
        {
            Player.transform.position = player_spawn_school.transform.position;
            Player.transform.rotation = player_spawn_school.transform.rotation;
        }
    }
}
