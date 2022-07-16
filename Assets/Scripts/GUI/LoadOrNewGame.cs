using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

/*
        somehow, using that class in the main menu and in game work.
*/
public class LoadOrNewGame : MonoBehaviour
{

    public SUB_TYPE SUB_TYPE;

    public Slider FOV, sensitivity;
    public TMP_Text FOV_TEXT, SENSITIVITY_TEXT;

    public Dropdown resolution;

    public Toggle fullscreen, viewBobbing;

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
            sensitivity.value = GameGlobal.Sensitivity;
            FOV_TEXT.text = GameGlobal.FOV.ToString();
            SENSITIVITY_TEXT.text = GameGlobal.Sensitivity.ToString();
            fullscreen.isOn = Screen.fullScreen;
            viewBobbing.isOn = GameGlobal.ViewBobbing;
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
            GameGlobal.FOV = 90;
            GameGlobal.Sensitivity = 100;
            GameGlobal.ViewBobbing = true;
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

        // i declared sensitivity as a dropdown instead of a slider 💀
        GameGlobal.Sensitivity = (int)sensitivity.value;

        Screen.SetResolution(screenX[resolution.value], screenY[resolution.value], fullscreen.isOn);

        Camera[] cameras = GetComponents<Camera>();

        GameGlobal.ViewBobbing = viewBobbing.isOn;

        if(FindObjectOfType<PlayerAiming>() != null) {
            FindObjectOfType<PlayerAiming>().sensitivityMultiplier = GameGlobal.Sensitivity / 100;
            FindObjectOfType<PlayerAiming>().player_cam.fieldOfView = GameGlobal.FOV;
        }

        Close();
    }

    public void SaveFOV()
    {
        int i = (int) FOV.value;
        FOV_TEXT.text = i.ToString();
    }

    public void UpdateSensitibity()
    {
        int i = (int) sensitivity.value;
        SENSITIVITY_TEXT.text = i.ToString();
    }

}


public enum SUB_TYPE
{
    NEW,
    LOAD,
    OPTION
}
