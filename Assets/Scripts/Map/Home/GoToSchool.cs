using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{

    public Text text;

    public GameObject Door, Player;

    public GameObject GUI_GET_OUT;

    void Start()
    {
        text.text = string.Empty;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(Door.transform.position, Player.transform.position) < 3.5)
        {
            text.text = "Press E to go out";
            if(Input.GetKeyDown(KeyCode.E)){
                GUI_GET_OUT.SetActive(true);
            }

        }else{
            text.text = string.Empty;
        }
    }
}
