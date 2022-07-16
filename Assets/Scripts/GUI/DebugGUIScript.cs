using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugGUIScript : MonoBehaviour
{

    public GameObject DebugGUI;

    public GameObject TextDialogue;

    void Start()
    {
        DebugGUI.SetActive(false);
        TextDialogue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.F3)) return;
        
        DebugGUI.SetActive(!DebugGUI.activeSelf);
    }
}
