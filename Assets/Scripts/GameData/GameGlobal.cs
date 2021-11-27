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
}
