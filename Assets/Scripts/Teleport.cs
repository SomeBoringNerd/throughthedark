using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
        this class is used for the debug menu unlike what it's name can make you think
*/
public class Teleport : MonoBehaviour
{
    // debug meny instance
    public GameObject debug_menu;

    // waypoints
    public GameObject item_showcase_object, player_spawn_school;
    
    // fake background
    public GameObject possible_new_background;

    // change the school
    public GameObject school_ld, school_hd;
    bool newSchoolLoaded = true;

    // player object
    public GameObject Player;

    // fog but it dont make sense to toggle it on in that script
    public GameObject fog;

    public Text text;

    void Start()
    {
        // disable debug menu
        debug_menu.SetActive(false);
        fog.SetActive(true);
        text.gameObject.SetActive(false);
    }

    
    void Update()
    {
        if (debug_menu.activeSelf)
        {
            // teleport to the item showcase place
            if (Input.GetKeyDown(KeyCode.F1))
            {
                Player.transform.position = item_showcase_object.transform.position;
                Player.transform.rotation = item_showcase_object.transform.rotation;

                debug_menu.SetActive(false);
            }
            // teleport at the spawnpoint
            else if (Input.GetKeyDown(KeyCode.F2))
            {
                Player.transform.position = player_spawn_school.transform.position;
                Player.transform.rotation = player_spawn_school.transform.rotation;

                debug_menu.SetActive(false);
            }
            // display the visual background
            else if (Input.GetKeyDown(KeyCode.F3))
            {
                possible_new_background.SetActive(!possible_new_background.activeSelf);
                debug_menu.SetActive(false);
            }
            // used for displaying the difference between v2 and v3
            // only execute while in the unity editor
            #if UNITY_EDITOR
            else if (Input.GetKeyDown(KeyCode.F4))
            {
                newSchoolLoaded = !newSchoolLoaded;
                text.text = "school loaded : " + (newSchoolLoaded ? "new" : "old");
                school_hd.SetActive(!newSchoolLoaded);
                school_ld.SetActive(newSchoolLoaded);
                debug_menu.SetActive(false);
            }
            #endif
        }
        else
        {
            // toggle on the debug menu
            if (Input.GetKeyDown(KeyCode.Asterisk))
            {
                debug_menu.SetActive(true);
            }
        }

        // *fall*back if the player somehow fall off the map (see NoFallScript for more infos)
        if(Player.transform.position.y < -50)
        {
            Player.transform.position = player_spawn_school.transform.position;
            Player.transform.rotation = player_spawn_school.transform.rotation;
        }
    }
}
