using System;
using System.Collections;
using System.Collections.Generic;
using Fragsurf.Movement;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
 
public class Student : MonoBehaviour
{
    [Header("Main infos")]
    public int STUDENT_ID;

    public string Student_Name;

    [Header("Text lines")]
    public string[] RegularLines;
    public string[] RegularLines_Speaker;
    public string[] GreatingDialogue;
    public string[] GreatingDialogue_Speaker;
    
    [Tooltip("if student can't have romance with player, leave blank")]
    public string[] FlirtDialogue;
    public string[] FlirtDialogue_Speaker;
    
    public string[] InfoDialogue;
    public string[] InfoDialogue_Speaker;
    
    public string[] ByeDialogue;
    public string[] ByeDialogue_Speaker;

    [Header("GUI stuff")] 
    public GameObject parentGUI;
    public Text dialogBox, speakerName;
    
    [Header("Other variables")]
    public GENDER GENDER;
    public PERSONALITY PERSONALITY;
    public bool CAN_HAVE_ROMANCE, isRoutineAlreadyRunning, leaveForNow;
    public GameObject interactionParent;
    

    [Header("Reference to other scripts")] 
    public InteractableScript interaction;

    public PlayerAiming playerReference;
    public SurfCharacter playerMovement;
    
    [Multiline]
    public string Description;

    private void Start()
    {
        leaveForNow = false;
        parentGUI.SetActive(false);
        interactionParent.SetActive(false);
        dialogBox.text = "";
        interaction.InteractableText[0].text = "press E to talk to " + Student_Name;
    }

    void Update()
    {
        if (interaction.isUsable && !parentGUI.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                playerReference.canCameraMove = false;
                playerMovement.canMove = false;
                
                parentGUI.SetActive(true);
                
                int rng = Random.Range(1, 2);
                Debug.Log(rng);
                
                StartCoroutine(sayStuff(RegularLines[(rng == 1 ? 0 : 2)], Student_Name));
            }
        }
    }

    // this code allow to display text on screen
    IEnumerator sayStuff(String text, string speaker_name)
    {
        if (!isRoutineAlreadyRunning)
        {
            isRoutineAlreadyRunning = true;
            speakerName.text = speaker_name;
            char[] letters = text.ToCharArray();
            foreach (char letter in letters)
            {
                yield return new WaitForSeconds(0.04f);
                // Debug.Log(letter);
                dialogBox.text += letter;
            }

            interactionParent.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            isRoutineAlreadyRunning = false;
        }
    }
    
    // same thing, but for interactions
    IEnumerator sayDialogue(INTERACTION_TYPE type)
    {
        Debug.Log("routine :" + isRoutineAlreadyRunning);
        if (!isRoutineAlreadyRunning)
        {
            dialogBox.text = String.Empty;
            isRoutineAlreadyRunning = true;
            
            switch (type)
            {
                case INTERACTION_TYPE.GREATING:
                    int i = 0;
                    foreach (string dialog_line in GreatingDialogue)
                    {
                        speakerName.text = GreatingDialogue_Speaker[i];
                        char[] letters2 = dialog_line.ToCharArray();
                        foreach (char letter in letters2)
                        {
                            yield return new WaitForSeconds(0.04f);
                            dialogBox.text += letter;
                        }
                        Debug.Log("test 4");
                        yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.E));
                        dialogBox.text = String.Empty;
                        i++;
                    }
                    break;
                case INTERACTION_TYPE.INFORMATION:
                    int i = 0;
                    foreach (string dialog_line in InfoDialogue)
                    {
                        speakerName.text = InfoDialogue_Speaker[i];
                        char[] letters2 = dialog_line.ToCharArray();
                        foreach (char letter in letters2)
                        {
                            yield return new WaitForSeconds(0.04f);
                            // Debug.Log(letter);
                            dialogBox.text += letter;
                        }
                        yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.E));
                        dialogBox.text = String.Empty;
                    }
                    break;
                case INTERACTION_TYPE.FLIRT:
                    int i = 0;
                    foreach (string dialog_line in FlirtDialogue)
                    {
                        speakerName.text = FlirtDialogue_Speaker[i];
                        char[] letters2 = dialog_line.ToCharArray();
                        foreach (char letter in letters2)
                        {
                            yield return new WaitForSeconds(0.04f);
                            dialogBox.text += letter;
                        }
                        yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.E));
                        dialogBox.text = String.Empty;
                    }
                    break;
                case INTERACTION_TYPE.SAY_GOOD_BYE:
                    int i = 0;
                    foreach (string dialog_line in ByeDialogue)
                    {
                        speakerName.text = ByeDialogue_Speaker[i];
                        char[] letters2 = dialog_line.ToCharArray();
                        foreach (char letter in letters2)
                        {
                            yield return new WaitForSeconds(0.04f);
                            dialogBox.text += letter;
                        }
                        yield return new WaitUntil(() => Input.GetKeyUp(KeyCode.E));
                        dialogBox.text = String.Empty;
                        leaveForNow = true;
                    }

                    leaveForNow = true;
                    break;
            }
            if(!leaveForNow){
                interactionParent.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                parentGUI.SetActive(false);
                playerReference.canCameraMove = true;
                playerMovement.canMove = true;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            // no matter the outcome, we want those two variable to be reset for the next interaction
            leaveForNow = false;
            isRoutineAlreadyRunning = false;
        }
    }
    
    // why the fuck i can't use enum in a button OnClick event ?!
    public void GreatingDialogueInit(int state)
    {
        Debug.Log("routine :" + isRoutineAlreadyRunning);
        if(!isRoutineAlreadyRunning){
            interactionParent.SetActive(false);
            Debug.Log("launching routine");
            switch (state)
            {
                case 0:
                    StartCoroutine(sayDialogue(INTERACTION_TYPE.GREATING));
                    break;
                case 1:
                    StartCoroutine(sayDialogue(INTERACTION_TYPE.INFORMATION));
                    break;
                case 2:
                    StartCoroutine(sayDialogue(INTERACTION_TYPE.FLIRT));
                    break;
                case 3:
                    StartCoroutine(sayDialogue(INTERACTION_TYPE.SAY_GOOD_BYE));
                    break;
            }
            
            
        }
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
    TEACHER
}
