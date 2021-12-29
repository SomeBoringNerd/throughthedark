using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableScript : MonoBehaviour
{
    public GameObject UI_PARENT;
    public Text[] InteractableText;
    public bool isUsable;

    public void Start()
    {
        UI_PARENT.SetActive(false);
    }
}
