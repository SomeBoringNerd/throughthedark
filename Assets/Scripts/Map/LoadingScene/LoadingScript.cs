using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{

    bool canLoad = true;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.LoadSceneAsync("SchoolScene");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canLoad)
        {
            SceneManager.LoadSceneAsync("SchoolScene");
            canLoad = false;
        }
    }
}
