using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{

    public GameObject[] loadAndNewSubMenu;
    public Text Title;

    int version = 2;
    string type = "prototype";

    public GameObject warningObject, debug_menu;
    
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 9999;
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            //Loader.Loader.Hook();
        }
        
        Title.text = "version-" + type + "-" + version;
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
        if (Input.GetKeyDown(KeyCode.F5) && SceneManager.GetActiveScene().name == "MainMenu") { 
            PlayerPrefs.DeleteAll();
            Screen.SetResolution(1280, 720, false);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void onEnable()
    {
        Time.timeScale = 0;
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
