using UnityEngine;

public class GameGlobal
{
    // as long as the game isn't in pre-release or release, no point in disabling the debug mode
    public static bool Debug
    {
        get => true;
        set => PlayerPrefs.SetInt("Debug", 1);

        /*
        get => PlayerPrefs.GetInt("Debug") == 1;
        set => PlayerPrefs.SetInt("Debug", (value ? 1 : 0));
        */
    }

    // unused
    public static bool PlayerIsNearADoor
    {
        get => PlayerPrefs.GetInt("PlayerIsNearADoor") == 1;
        set => PlayerPrefs.SetInt("PlayerIsNearADoor", (value ? 1 : 0));
    }
    
    // determine if the player is going through a waypoint
    // it use the "Player is Near A Door" variable because fuck it, i'm a lazy cunt and cant be bother to edit the copy pasted code
    public static bool PlayerIsInWaypoint
    {
        get => PlayerPrefs.GetInt("PlayerIsNearADoor") == 1;
        set => PlayerPrefs.SetInt("PlayerIsNearADoor", (value ? 1 : 0));
    }
    

    // the shaking head animation, should it play ?
    public static bool ViewBobbing
    {
        get => PlayerPrefs.GetInt("ViewBobbing") == 1;
        set => PlayerPrefs.SetInt("ViewBobbing", (value ? 1 : 0));
    }
    
    // unused for now, should be used to allow a player to show or not the menus
    public static bool canUseMenus
    {
        get => PlayerPrefs.GetInt("canUseMenus") == 1;
        set => PlayerPrefs.SetInt("canUseMenus", (value ? 1 : 0));
    }
    
    // 
    public static int Profile
    {
        get => PlayerPrefs.GetInt("Profile");
        set => PlayerPrefs.SetInt("Profile", value);
    }

    public static float Sensitivity
    {
        get => PlayerPrefs.GetFloat("Sensitivity");
        set => PlayerPrefs.SetFloat("Sensitivity", value);
    }

    public static int FOV
    {
        get => PlayerPrefs.GetInt("FOV");
        set => PlayerPrefs.SetInt("FOV", value);
    }
    
    public static int Reputation
    {
        get => PlayerPrefs.GetInt("reputation_" + Profile);
        set => PlayerPrefs.SetInt("reputation_" + Profile, value);
    }

    public static int LastOpenedPage
    {
        get => PlayerPrefs.GetInt("last_opened_page_" + Profile);
        set => PlayerPrefs.SetInt("last_opened_page_" + Profile, value);
    }

    public static bool wasProfileLoaded(int number)
    {
        return PlayerPrefs.GetInt("profile_" + number + "was_loaded_once") == 1 ? true : false;
    }

    public static string getPage(int number)
    {
        int profile = Profile;
        return PlayerPrefs.GetString("profile_" + GameGlobal.Profile + "_notebook_" + number);
    }

    public static string scenetoload
    {
        get => PlayerPrefs.GetString("scenetoload");
        set => PlayerPrefs.SetString("scenetoload", value);
    }

    public static void setPage(int number, string t)
    {
        if(number >= 0 && number < 51) 
        { 
            PlayerPrefs.SetString("profile_" + GameGlobal.Profile + "_notebook_" + number, t);
        }
    }

    public static void EraseData(int number)
    {

        int fov_temp = GameGlobal.FOV;
        float sens_temp = GameGlobal.Sensitivity;
        
        // remove data about the profile being loaded
        PlayerPrefs.DeleteKey("profile_" + number + "was_loaded_once");
        PlayerPrefs.DeleteKey("last_opened_page_" + Profile);
        PlayerPrefs.DeleteKey("");

        // delete every pages of the notebook
        for(int i = -1; i != 51; i++)
        {
            PlayerPrefs.DeleteKey("profile_" + GameGlobal.Profile + "_notebook_" + i);
        }
        
    }
}
