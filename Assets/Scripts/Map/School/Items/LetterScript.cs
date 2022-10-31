using System;
using UnityEngine;

[Obsolete]
public class LetterScript : MonoBehaviour
{
    
    public string aaaaa_hint = "Content that was i never implemented. DM me if you can find out why it was made!";
    public GameObject letter;
    public InteractableScript interaction;
    
    
    public void Update()
    {
        if (interaction.isUsable)
        {
            
        }    
    }
}