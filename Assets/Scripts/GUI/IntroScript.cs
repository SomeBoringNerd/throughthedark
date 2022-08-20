using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class IntroScript : MonoBehaviour
{

    public TranslationManager manager;

    public Text dialogue_name, dialogue;

    public GameObject PressEToContinue;

    public AudioClip[] voices;

    public AudioSource ears;

    void Start()
    {
        if(manager == null){
            manager = FindObjectOfType<TranslationManager>();
        }

        StartCoroutine(cutscene());
    }

    IEnumerator cutscene()
    {
        bool skip = false;
        for(int i = 1; i < 8; i++)
        {
            Debug.Log(i);
            PressEToContinue.SetActive(false);

            dialogue.text = "";
            dialogue_name.text = manager.getString("IntroScene.introscript.dialogue" + i + ".name");

            char[] dial = manager.getString("IntroScene.introscript.dialogue" + i).ToCharArray();

            foreach(char chr in dial)
            {
                if(!Input.GetKey(KeyCode.F))
                {
                    dialogue.text += chr;
                    ears.PlayOneShot(voices[i - 1]);
                    yield return new WaitForSeconds(0.06f);
                    skip = true;
                }
                else
                { 
                    dialogue.text = manager.getString("IntroScene.introscript.dialogue" + i);
                }
            }

            PressEToContinue.SetActive(true);
            skip = false;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        }

        GameGlobal.scenetoload = "MainCharacterChamberScene";
        SceneManager.LoadScene("LoadingScene");

        yield return null;
    }
}
