using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour 
{
    public Button Flirt;



    Student student;


    public void Start()
    {

    }

    /// <summary>
    /// Finally, I dont need an entire panel per NPC
    /// </summary>
    /// <param name="_student">Active student, the with the dialogue lines we want</param>
    public void setStudentForButton(Student _student)
    {
        student = _student;
        
        Flirt.interactable = _student.CAN_HAVE_ROMANCE;
    }

    public void GreatingDialogueInit(int state)
    {
        if(student == null){
            Debug.LogError("STUDENT IN DIALOGUEMANAGER IS NULL, THIS MEAN THE FUNCTION WAS CALLED OUTSIDE OF IT'S INTENDED SCOPE (aka, AFTER setStudentForButton WAS CALLED WITH VALID TARGET");
            return;
        }
        if(student.isRoutineAlreadyRunning) return;

        student.interactionParent.SetActive(false);
        
        switch (state)
        {
            case 0:
                StartCoroutine(student.sayDialogue(INTERACTION_TYPE.GREATING));
                break;
            case 1:
                StartCoroutine(student.sayDialogue(INTERACTION_TYPE.INFORMATION));
                break;
            case 2:
                StartCoroutine(student.sayDialogue(INTERACTION_TYPE.FLIRT));
                break;
            case 3:
                StartCoroutine(student.sayDialogue(INTERACTION_TYPE.SAY_GOOD_BYE));
                break;
        }
    }
}