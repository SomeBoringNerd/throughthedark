using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOnE : MonoBehaviour
{
    public GameObject objectToToggle;

    void Update()
    {
        if(!Input.GetKeyDown(KeyCode.E)) return;

        objectToToggle.SetActive(!objectToToggle.activeSelf);
    }
}
