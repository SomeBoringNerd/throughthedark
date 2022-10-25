using System;
using UnityEngine;
/*
        dont fucking touch that, last time i tried, i broke everything and had to revert the changes
*/
public class RaycastScript : MonoBehaviour
{

    public InteractableScript target;

    public void Start()
    {
        target = null;
    }

    // new raycast system

    void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward * 3));

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward * 3), Color.yellow);

        if(target != null){
            if(Vector3.Distance(transform.position, target.transform.position) <= 4){
                target.isUsable = false;
                target.UI_PARENT.SetActive(false);
                target = null;
            }
        }

        if(Physics.Raycast(ray, out RaycastHit hit, 3))
        {
            if(hit.collider.tag == "Env") return;

            if(hit.collider.GetComponent<InteractableScript>() != null)
            {
                target = hit.collider.GetComponent<InteractableScript>();
                target.isUsable = true;
                
                target.UI_PARENT.SetActive(true);
            }else if (target != null){
                target.isUsable = false;
                target.UI_PARENT.SetActive(false);
                target = null;
            }
        }
    }
    
    /*
    old code for the raycast system

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
    */
}
