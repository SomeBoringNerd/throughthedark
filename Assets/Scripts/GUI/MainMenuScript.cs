using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{

    public GameObject[] loadAndNewSubMenu;
    public Text Title;

    int version = 1;
    string type = "prototype";

    public GameObject warningObject;
    
    // Start is called before the first frame update
    void Start()
    {
        Title.text = "version-" + type + "-" + version;
        Application.targetFrameRate = 60;
        if (PlayerPrefs.GetInt("Version") != version)
        {
            if(PlayerPrefs.GetInt("Version") < version)
            {
                GameGlobal.ViewBobbing = true;
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
}
