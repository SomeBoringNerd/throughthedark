using System;
using UnityEngine;

public class RaycastScript : MonoBehaviour
{

    public InteractableScript target;

    public void Start()
    {
        target = null;
        Application.targetFrameRate = 60;
    }

    public void OnTriggerStay(Collider entity)
    {
        if(target == null) { 
            if (entity.GetComponent<InteractableScript>() != null)
            {
                target = entity.GetComponent<InteractableScript>();
                target.isUsable = true;
                
                target.UI_PARENT.SetActive(true);
            }
        }
    }

    public void OnTriggerExit(Collider entity)
    {
        if(target != null) { 
            if (entity.GetComponent<InteractableScript>() == target)
            {
                target.isUsable = false;
                target.UI_PARENT.SetActive(false);
                target = null;
            }
        }
    }
}
