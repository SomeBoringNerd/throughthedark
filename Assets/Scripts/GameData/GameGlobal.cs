using UnityEngine;

public class GameGlobal
{
    public static bool Debug
    {
        get => PlayerPrefs.GetInt("Debug") == 1;
        set => PlayerPrefs.SetInt("Debug", (value ? 1 : 0));
    }

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

    public static bool getBool(int number)
    {
        return PlayerPrefs.GetInt("profile_" + number + "was_loaded_once") == 1 ? true : false;
    }

    public static void EraseData(int profile)
    {

    }
}
