using UnityEngine;

public class GameGlobal
{
    public static bool Debug
    {
        get => PlayerPrefs.GetInt("Debug") == 1;
        set => PlayerPrefs.SetInt("Debug", (value ? 1 : 0));
    }

    // unused for now
    public static bool PlayerIsNearADoor
    {
        get => PlayerPrefs.GetInt("PlayerIsNearADoor") == 1;
        set => PlayerPrefs.SetInt("PlayerIsNearADoor", (value ? 1 : 0));
    }


    public static int Profile
    {
        get => PlayerPrefs.GetInt("Profile");
        set => PlayerPrefs.SetInt("Profile", value);
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

    public static void setPage(int number, string t)
    {
        if(number >= 0 && number < 51) 
        { 
            PlayerPrefs.SetString("profile_" + GameGlobal.Profile + "_notebook_" + number, t);
        }
    }

    public static void EraseData(int number)
    {
        // remove data about the profile being loaded
        PlayerPrefs.DeleteKey("profile_" + number + "was_loaded_once");
        PlayerPrefs.DeleteKey("last_opened_page_" + Profile);

        // delete every pages of the notebook
        for(int i = -1; i != 51; i++)
        {
            PlayerPrefs.DeleteKey("profile_" + GameGlobal.Profile + "_notebook_" + i);
        }

    }
}
