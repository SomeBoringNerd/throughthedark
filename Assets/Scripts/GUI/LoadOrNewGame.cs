using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class LoadOrNewGame : MonoBehaviour
{

    public SUB_TYPE SUB_TYPE;

    public Slider FOV;
    public TMP_Text FOV_TEXT;

    public Dropdown resolution;

    public Toggle fullscreen;

    int[] screenX = new int[]{
        1366,
        1366,
        1280,
        1920,
        1920
    };

    int[] screenY = new int[]{
        768,
        766,
        720,
        1080,
        1440
    };

    public GameObject Parent;

    public Button[] Profiles_Parent;

    void Start()
    {
        if(SUB_TYPE == SUB_TYPE.LOAD)
        {
            int i = 1;
            foreach(Button button in Profiles_Parent)
            {
                if (!GameGlobal.wasProfileLoaded(i))
                {
                    button.interactable = false;
                }
                i++;
            }
        }
        if(SUB_TYPE == SUB_TYPE.OPTION)
        {
            FOV.value = GameGlobal.FOV;
            FOV_TEXT.text = GameGlobal.FOV.ToString();
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

            for(int i = 0; i != 51; i++)
            {
                GameGlobal.setPage(i, "");
            }
        }

        PlayerPrefs.SetInt("profile_" + profile + "was_loaded_once", 1);

        SceneManager.LoadScene("MainCharacterChamberScene");
    }

    public void SaveOptions()
    {
        GameGlobal.FOV = (int) FOV.value;

        Screen.SetResolution(screenX[resolution.value], screenY[resolution.value], fullscreen.isOn);
        
        Close();
    }

    public void SaveFOV()
    {
        int i = (int) FOV.value;
        FOV_TEXT.text = i.ToString();
    }

}


public enum SUB_TYPE
{
    NEW,
    LOAD,
    OPTION
}