using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadOrNewGame : MonoBehaviour
{

    public SUB_TYPE SUB_TYPE;

    public GameObject Parent;

    public Button[] Profiles_Parent;

    void Start()
    {
        if(SUB_TYPE == SUB_TYPE.LOAD)
        {
            int i = 1;
            foreach(Button button in Profiles_Parent)
            {
                if (!GameGlobal.getBool(i))
                {
                    button.interactable = false;
                }
                i++;
            }
        }
        if (Parent.activeSelf) { 
            Parent.SetActive(false);
        }
    }

    public void Close()
    {
        Parent.SetActive(false);
    }


    public void LoadProfile(int profile)
    {
        GameGlobal.Profile = profile;

        if (SUB_TYPE == SUB_TYPE.NEW)
        {
            GameGlobal.EraseData(profile);
        }

        PlayerPrefs.SetInt("profile_" + profile + "was_loaded_once", 1);

        SceneManager.LoadScene("MainCharacterChamberScene");
    }


}


public enum SUB_TYPE
{
    NEW,
    LOAD
}