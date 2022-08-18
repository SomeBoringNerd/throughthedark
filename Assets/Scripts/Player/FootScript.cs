using UnityEngine;

public class FootScript : MonoBehaviour 
{


    public void playFootstep(int type)
    {
        FindObjectOfType<PlayerScript>().foots.PlayOneShot(FindObjectOfType<PlayerScript>().footsteps[type]);
    }
}