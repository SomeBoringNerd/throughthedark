using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugGUIScript : MonoBehaviour
{

    public GameObject DebugGUI;

    void Start()
    {
        DebugGUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F3))
        {
            DebugGUI.SetActive(!DebugGUI.activeSelf);
        }
    }
}
