using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScript : MonoBehaviour
{

    public Text loadingText;

    // Start is called before the first frame update
    void Start()
    {
        // let's hope that it work well.
        //Time.timeScale = .001f;
        SceneManager.LoadSceneAsync("SchoolScene");

    }

    // it fucking don't work. Shit.
    IEnumerator SchoolScene()
    {
        AsyncOperation operation = null;

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            loadingText.text = "Scene is " + progress + "% loaded";
        }

        yield return null;
    }
}

