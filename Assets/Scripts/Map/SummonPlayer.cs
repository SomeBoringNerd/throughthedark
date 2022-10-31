using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SummonPlayer : MonoBehaviour
{
    public GameObject playerInstance, spawnpoint;

    public GameObject AlternativeSpawnPoint;
    void Start()
    {
        if(PlayerPrefs.GetString("flag") == "UseAlternativeSpawnPoint" && AlternativeSpawnPoint != null)
        {
            Instantiate(playerInstance, AlternativeSpawnPoint.transform.position, AlternativeSpawnPoint.transform.rotation);
            PlayerPrefs.DeleteKey("flag");
        }
        else
        {
            Instantiate(playerInstance, spawnpoint.transform.position, spawnpoint.transform.rotation);
        }
        
    }
}
