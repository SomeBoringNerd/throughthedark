using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{

    public GameObject[] loadAndNewSubMenu;
    public Text Title, MOTD;

    int version = 3;
    string type = "pre-alpha";

    public GameObject warningObject, debug_menu;
    
    // Start is called before the first frame update
    void Start()
    {        
        string[] lines = System.IO.File.ReadAllLines(Application.streamingAssetsPath + "/NotImportantData/splash.txt");

        int rng = Random.Range(0, lines.Length - 1);

        MOTD.text = lines[rng];

        Title.text = "version " + type + "-" + (version - 2);

        // this is going to be a mess later on.
        if (PlayerPrefs.GetInt("Version") != version)
        {
            if(PlayerPrefs.GetInt("Version") <= 0)
            {
                GameGlobal.ViewBobbing = true;
            }
            if(PlayerPrefs.GetInt("Version") <= 2)
            {
                GameGlobal.Sensitivity = 100;
            }
            PlayerPrefs.SetInt("Version", version);
        }
    }

    void Update()
    {
        if (!(Input.GetKeyDown(KeyCode.F5) && SceneManager.GetActiveScene().name == "MainMenu")) return;
        
        PlayerPrefs.DeleteAll();
        Screen.SetResolution(1280, 720, false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void onEnable()
    {
        Time.timeScale = 0;
        FindObjectOfType<PlayerAiming>().canCameraMove = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void Close()
    {
        onDisable();
        gameObject.SetActive(false);
    }

    public void onDisable()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        FindObjectOfType<PlayerAiming>().canCameraMove = true;
    }

    void DisplayWarning()
    {
        warningObject.SetActive(true);
    }

    public void quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void ShowItem(int i)
    {
        Debug.Log("test " + i);
        loadAndNewSubMenu[0].SetActive(false);
        loadAndNewSubMenu[1].SetActive(false);
        loadAndNewSubMenu[2].SetActive(false);

        loadAndNewSubMenu[i].SetActive(true);
    }

    public void debugmenu()
    {
        if (debug_menu == null) return;
        
        
    }
}
