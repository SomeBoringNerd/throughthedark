using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainAndThunder : MonoBehaviour
{
    public WEATHER_STATE WEATHER_STATE;

    public GameObject[] thunder_bolt;

    public GameObject[] rain_particle_cast;

    public AudioSource WEATHER_LISTENER;

    public AudioSource THUNDER_LISTENER;

    // 0 = rain
    public AudioClip[] weather_effect;


    // in frame, the game is supposed to run at 60 fps
    // when it reach that value, the game will decide if thunder should
    // strike with a 50% chance
    // every 25s by default, 10s during a storm with a 75% chance
    public int Thunder_Frequency;

    public void Start()
    {
        THUNDER_LISTENER.gameObject.SetActive(false);

        foreach (GameObject rain_effect in rain_particle_cast)
        {
            rain_effect.SetActive(false);
        }

        switch (WEATHER_STATE)
        {
            case WEATHER_STATE.RAIN:
            case WEATHER_STATE.RAIN_AND_THUNDER:
            case WEATHER_STATE.THUNDERSTORM:
                WEATHER_LISTENER.clip = weather_effect[0];
                foreach (GameObject rain_effect in rain_particle_cast)
                {
                    rain_effect.SetActive(true);
                }
                break;
            default:
                // no implementation
                break;
        }
    }

    public void Update()
    {
        switch (WEATHER_STATE)
        {
            case WEATHER_STATE.RAIN_AND_THUNDER:
            case WEATHER_STATE.THUNDERSTORM:

                if(Thunder_Frequency == (WEATHER_STATE == WEATHER_STATE.RAIN_AND_THUNDER ? 1500 : 600))
                {
                    Thunder_Frequency = 0;
                    int RNG = Random.Range(0, 100);

                    if (RNG <= (WEATHER_STATE == WEATHER_STATE.RAIN_AND_THUNDER ? 50 : 75))
                    {
                        Debug.Log("a bolt was instructed to summon");

                        //int BOLT_ID = Random.Range(0, thunder_bolt.Length - 1);
                        StartCoroutine(thunder());
                        //SummonBolt(BOLT_ID);
                    }
                    else
                    {
                        Debug.Log("Summoning failed");
                    }
                    Debug.Log(RNG + " out of " + (WEATHER_STATE == WEATHER_STATE.RAIN_AND_THUNDER ? 50 : 75) + " " + WEATHER_STATE);

                }
                else
                {
                    Thunder_Frequency++;
                }

                break;
        }
    }

    IEnumerator thunder()
    {
        THUNDER_LISTENER.gameObject.SetActive(true);
        yield return new WaitForSeconds(8);
        THUNDER_LISTENER.gameObject.SetActive(false);
        yield return null;
    }

    void SummonBolt(int boltID)
    {
        // in a script made for that, a cooldown of x seconds will
        // make the bolt disappear after a while.
        // @TODO : particle effect, sound effect
        thunder_bolt[boltID].SetActive(true);
    }


}

public enum WEATHER_STATE
{
    CLEAR,
    RAIN,
    RAIN_AND_THUNDER,
    THUNDERSTORM,
    WINTER
}
