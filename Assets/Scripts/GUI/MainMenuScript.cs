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
            PlayerPrefs.SetInt("Version", version);
        }
    }

    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.F5)) { 
            PlayerPrefs.DeleteAll();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
#endif
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
        loadAndNewSubMenu[0].SetActive(false);
        loadAndNewSubMenu[1].SetActive(false);

        loadAndNewSubMenu[i].SetActive(true);
    }
}
