using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslationManager : MonoBehaviour
{

    Dictionary<string, string> strings = new Dictionary<string, string>();

    // Start is called before the first frame update
    void Start()
    {
        string[] lines = System.IO.File.ReadAllLines(Application.streamingAssetsPath + "/translation/english.ttdlg");

        foreach(string line in lines)
        {
            if(!line.StartsWith("#") && line != "")
            {
                string[] args = line.Split(" = ");
                strings.Add(args[0], args[1]);
            }
        }
    }
    
    /// <summary>
    /// return a string found in StreamingAssets/translation
    /// note : if you know exactly how many entries you need for a loop,
    /// it's a valid idea to use it in a loop, otherwise use <c>getArray</c>
    /// </summary>
    /// <param name="key">name of the string in the localisation file</param>
    /// <returns>string ready to use</returns>
    public string getString(string key)
    {
        if(strings.ContainsKey(key))
        {
            return strings[key];
        }else
        {
            Debug.LogError("THE STRING " + key + " WASN'T FOUND IN LOCALISATION FILE !!!");
            return key;
        }
    }

    /// <summary>
    /// return an array of strings. Useful for scripts that can have array of strings of different size for character dialogues for exemple
    /// </summary>
    /// <exemple>
    /// // %ID% NEED TO BE PRESENT in the passed value, read the code to find why
    /// TranslationManager.getArray("IntroScene.introscript.dialogue%ID%");
    /// </exemple>
    /// <param name="key">name of the string in the localisation file (replace numbers by %ID%</param>
    /// <returns></returns>
    public string[] getArray(string key)
    {
        List<string> tmp = new List<string>();

        key = key.Replace("%ID%", "");
        int i = 1;
        foreach(KeyValuePair<string, string> entry in strings)
        {
            if(entry.Key.Replace("1", "")
            .Replace("2", "")
            .Replace("3", "")
            .Replace("4", "")
            .Replace("5", "")
            .Replace("6", "")
            .Replace("7", "")
            .Replace("8", "")
            .Replace("9", "")
            .Replace("0", "").Trim().ToLower() == key.Trim().ToLower())
            {
                tmp.Add(entry.Value);
                i++;
            }else{

            }
        }
        if(i != 0)
        {
            string[] string_to_return = new string[i];

            int j = 0;
            foreach(string str in tmp)
            {
                string_to_return[j] = str;
                j++;
            }
            return string_to_return;
        }else
        {
            Debug.LogError("THE STRING " + key + " WASN'T FOUND IN LOCALISATION FILE !!!");

            string[] string_to_return = new string[1];

            string_to_return[0] = key;

            return string_to_return;
        }
    }
}
