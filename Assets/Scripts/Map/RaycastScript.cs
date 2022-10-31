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
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward * 4));

        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward * 4), Color.yellow);
        
        // make so player can't interact 
        // with objects too far from them
        if(target != null)
        {
            if(Vector3.Distance(transform.position, target.transform.position) > 4){
                target.isUsable = false;
                target.UI_PARENT.SetActive(false);
                target = null;
            }
        }

        if(Physics.Raycast(ray, out RaycastHit hit, 5))
        {
            if(hit.collider.tag == "Env") return;

            if(hit.collider.GetComponent<InteractableScript>() != null)
            {
                target = hit.collider.GetComponent<InteractableScript>();
                target.isUsable = true;
                
                target.UI_PARENT.SetActive(true);
            }
        }
    }
}
/*

else if (target != null){
                target.isUsable = false;
                target.UI_PARENT.SetActive(false);
                target = null;
            }

*/