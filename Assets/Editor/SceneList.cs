using System.IO;
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;
public class SceneList : EditorWindow 
{

    [MenuItem("SBN/Scene List")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        SceneList window = (SceneList)EditorWindow.GetWindow(typeof(SceneList));
        window.Show();
    }

    void OnGUI() 
    {
        GUILayout.Label("loaded scene : " + SceneManager.GetActiveScene().name, EditorStyles.label);

        GUILayout.Label("Scene list :", EditorStyles.boldLabel);

        DirectoryInfo info = new DirectoryInfo("Assets/Scenes");

        FileInfo[] files = info.GetFiles("*.unity");

        foreach(FileInfo file in files)
        {
            if (GUILayout.Button(file.Name.Replace(".unity", "")))
            {
                EditorSceneManager.OpenScene("Assets/Scenes/" + file.Name);
            }
        }
    }
}
