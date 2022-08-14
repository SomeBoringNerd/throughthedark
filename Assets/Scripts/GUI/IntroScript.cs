using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IntroScript : MonoBehaviour
{

    public TranslationManager manager;

    public Text dialogue_name, dialogue;

    public GameObject PressEToContinue;

    void Start()
    {
        if(manager == null){
            manager = FindObjectOfType<TranslationManager>();
        }

        StartCoroutine(cutscene());
    }

    IEnumerator cutscene()
    {
        for(int i = 1; i < 8; i++)
        {
            Debug.Log(i);
            PressEToContinue.SetActive(false);

            dialogue.text = "";
            dialogue_name.text = manager.getString("IntroScene.introscript.dialogue" + i + ".name");

            char[] dial = manager.getString("IntroScene.introscript.dialogue" + i).ToCharArray();

            foreach(char chr in dial)
            {
                dialogue.text += chr;
                yield return new WaitForSeconds(0.06f);
            }

            PressEToContinue.SetActive(true);
            
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.E));
        }


        yield return null;
    }
}
