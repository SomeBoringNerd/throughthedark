using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookAtPlayer : MonoBehaviour
{
    public Transform player, child;
    bool running = false;
    
    public float Y;
    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        Y = transform.rotation.y * 180;
        child.transform.rotation = new Quaternion(child.rotation.x, Y - 0.01f, child.rotation.z, 0);
    }

    void Start(){
        StartCoroutine(hide());
    }

    private void OnTriggerEnter(Collider collider)
    {
        //Debug.Log("someone has entered the collider");
        StopCoroutine(hide());
        StartCoroutine(show());
    }

    private void OnTriggerExit(Collider collider)
    {
        //Debug.Log("someone has exited the collider");
        
        StopCoroutine(show());
        StartCoroutine(hide());
    }

    IEnumerator show()
    {
        running = true;
        child.transform.localScale = Vector3.zero;

        while(child.transform.localScale.x < 1)
        {
            child.transform.localScale = new Vector3(child.transform.localScale.x + 0.016f, child.transform.localScale.y + 0.016f, child.transform.localScale.z + 0.016f);
            yield return new WaitForSeconds(0.004f);
        }
        running = false;
        yield return null;
    }

    IEnumerator hide()
    {
        running = true;
        child.transform.localScale = new Vector3(1, 1, 1);

        while(child.transform.localScale.x > 0)
        {
            child.transform.localScale = new Vector3(child.transform.localScale.x - 0.016f, child.transform.localScale.y - 0.016f, child.transform.localScale.z - 0.016f);
            yield return new WaitForSeconds(0.004f);
        }
        running = false;
        yield return null;
    }
}
