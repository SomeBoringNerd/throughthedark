using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student : MonoBehaviour
{
    [Header("Main infos")]
    public int STUDENT_ID;

    public string Student_Name;

    [Header("Text lines")]
    public string[] RegularLines;

    [Tooltip("if student can't have romance with player, leave blank")]
    public string[] FlirtLines;

    public string[] InfoLines;
    public string[] ByeLines;

    [Header("Other variables")]
    public GENDER GENDER;
    public PERSONALITY PERSONALITY;
    public bool CAN_HAVE_ROMANCE;


    [Multiline]
    public string Description;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

public enum GENDER
{
    MALE,
    FEMALE,
    UNDEFINED
}

public enum PERSONALITY
{
    ONEE,
    LONER,
    BULLY,
    TEACHER,
    UNDEFINED
}
