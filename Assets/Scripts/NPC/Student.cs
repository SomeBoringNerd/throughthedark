using System;
using System.Collections;
using System.Collections.Generic;
using Fragsurf.Movement;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
 /*
 
        Logic behind the npcs

        todo : Rewrite the dialogue system because holyshit it's bad.
		like, really really bad.
 
 */
public class Student : MonoBehaviour
{
    [Header("Main infos")]
    public int STUDENT_ID;

    public string Student_Name;

    public bool idle;

    [Header("GUI stuff")] 
    public GameObject parentGUI, PressEToContinue;
    public Text dialogBox, speakerName;
    
    [Header("Other variables")]
    public GENDER GENDER;
    public PERSONALITY PERSONALITY;
    public bool CAN_HAVE_ROMANCE, isRoutineAlreadyRunning, leaveForNow;
    public GameObject interactionParent;

    public float maxRotation, minRotation;
    

    [Header("Reference to other scripts")] 
    public InteractableScript interaction;

    public TranslationManager manager;

    public DialogueManager dmanager;

    public PlayerAiming playerReference;
    public SurfCharacter playerMovement;
    
    [Multiline]
    public string Description;

    private void Start()
    {
        // now we do the good stuff.

        if(manager == null){
            manager = FindObjectOfType<TranslationManager>();
        }

        if(dmanager == null){
            dmanager = FindObjectOfType<DialogueManager>();
        }
        
        PressEToContinue.SetActive(false);
        
        leaveForNow = false;
        parentGUI.SetActive(false);
        interactionParent.SetActive(false);
        dialogBox.text = "";
        interaction.InteractableText[0].text = "press E to talk to " + Student_Name;
    }

    void Update()
    {
        Debug.Log(playerReference.transform.rotation.y);
        // logic to see if the player is looking at a npc and pressing E
        // (will add support for custom control later)
        if(playerReference.transform.rotation.y <= maxRotation && playerReference.transform.rotation.y >= minRotation) return;
        if (!(interaction.isUsable && !parentGUI.activeSelf)) return;
        if (!Input.GetKeyDown(KeyCode.E)) return;
        
        // made to avoid player talking to NPC behind walls
        

        GameGlobal.canUseMenus = false;
        playerReference.canCameraMove = false;
        playerMovement.canMove = false;
        
        parentGUI.SetActive(true);
        
        // say a random line
        StartCoroutine(sayStuff(manager.getString("SchoolScene.DialogueManager."+ Student_Name.Replace(" ", "")  +".NONE.1"), Student_Name));
    }

    /// <summary>
    /// This code display a message before showing the interaction menu
    /// </summary>
    /// <param name="text">Text to display</param>
    /// <param name="speaker_name">What to display on the Name label.</param>
    /// <returns>Nothing lol</returns>
    IEnumerator sayStuff(String text, string speaker_name)
    {
        if (isRoutineAlreadyRunning) yield return null;
        dialogBox.text = String.Empty;
        PressEToContinue.SetActive(false);

        isRoutineAlreadyRunning = true;
        speakerName.text = speaker_name;

        char[] letters = text.ToCharArray();
        foreach (char letter in letters)
        {
            yield return new WaitForSeconds(0.04f);
            dialogBox.text += letter;
        }

        PressEToContinue.SetActive(true);
        yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.E));
        PressEToContinue.SetActive(false);

        if(idle)
        {
            parentGUI.SetActive(false);
            interactionParent.SetActive(false);
            playerReference.canCameraMove = true;
            playerMovement.canMove = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            interactionParent.SetActive(true);
            dmanager.setStudentForButton(GetStudent());
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            isRoutineAlreadyRunning = false;
        }
    }
    
    /// <summary>
    /// Initialize a Dialogue loop dictated by the followings facters :
    /// -> character name
    /// -> type of interaction
    /// </summary>
    /// <param name="type">type of interaction</param>
    /// <returns>nothing lol</returns>
    public IEnumerator sayDialogue(INTERACTION_TYPE type)
    {
        if (isRoutineAlreadyRunning) yield return null;

        dialogBox.text = String.Empty;
        isRoutineAlreadyRunning = true;
        
        string[] dialogue = manager.getArray("SchoolScene.DialogueManager." + Student_Name.Replace(" ", "") + "." + type.ToString().ToUpper() + ".%ID%");
        string[] dialogue_speaker = manager.getArray("SchoolScene.DialogueManager." + Student_Name.Replace(" ", "") + "." + type.ToString().ToUpper() + ".%ID%.speaker");
        
        int l = 0;
        foreach (string dialog_line in dialogue)
        {
            speakerName.text = dialogue_speaker[l];
            if(dialog_line != String.Empty && dialog_line != null)
            {
                char[] letters2 = dialog_line.ToCharArray();
                foreach (char letter in letters2)
                {
                    yield return new WaitForSeconds(0.04f);
                    dialogBox.text += letter;
                }
                PressEToContinue.SetActive(true);
                yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.E));
                PressEToContinue.SetActive(false);
                dialogBox.text = String.Empty;
                l++;
            }
            
            leaveForNow = type == INTERACTION_TYPE.SAY_GOOD_BYE;
        }
        
        if(!leaveForNow){
            interactionParent.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
        }
        else
        {
            
            parentGUI.SetActive(false);
            interactionParent.SetActive(false);
            playerReference.canCameraMove = true;
            playerMovement.canMove = true;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        // no matter the outcome, we want those two variable to be reset for the next interaction
        leaveForNow = false;
        isRoutineAlreadyRunning = false;
        PressEToContinue.SetActive(false);
        speakerName.text = Student_Name;
        GameGlobal.canUseMenus = true;
    }
        
    /// <summary>
    /// prettier than a simple "this" IMO
    /// </summary>
    /// <returns>student instance</returns>
    public Student GetStudent()
    {
        return this;
    }
    
}

public enum INTERACTION_TYPE
{
    NONE,
    GREATING,
    INFORMATION,
    FLIRT,
    SAY_GOOD_BYE
}
public enum GENDER
{// if you know, you know
    NAJIMI,
    MALE,
    FEMALE
}

public enum PERSONALITY
{
    NONE,
    ONEE,
    LONER,
    BULLY,
    TEACHER,
    SOCIAL,
}
