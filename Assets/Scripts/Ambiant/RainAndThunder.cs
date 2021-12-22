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

    public int random_frequency, x, failed;


    // in frame, the game is supposed to run at 60 fps
    // when it reach that value, the game will decide if thunder should
    // strike with a 50% chance (or 35% during rain and thunder weather)
    // around 12s for a thunderstorm, around 25s for a regular storm
    // with +/- 3/1s of randomness
    // it's more complicated than it should be
    public int Thunder_Frequency;

    public void Start()
    {
        THUNDER_LISTENER.gameObject.SetActive(false);

        x = WEATHER_STATE == WEATHER_STATE.RAIN_AND_THUNDER ? 1080 : 720;
        random_frequency = Random.Range(x - 60, x + 180);

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

                if(Thunder_Frequency >= random_frequency || failed == 3)
                {
                    Debug.Log("random_frequency = " + random_frequency);
                    Thunder_Frequency = 0;
                    int RNG = Random.Range(0, 100);
                    string e = (failed == 3) ? " (forced)" : "";
                    if (RNG <= (WEATHER_STATE == WEATHER_STATE.RAIN_AND_THUNDER ? 35 : 50) || failed == 3)
                    {
                        Debug.Log("a bolt was instructed to summon");

                        //int BOLT_ID = Random.Range(0, thunder_bolt.Length - 1);
                        StartCoroutine(thunder());
                        failed = 0;
                        //SummonBolt(BOLT_ID);
                    }
                    else
                    {
                        Debug.Log("Summoning failed");
                        failed++;
                    }
                    Debug.Log(RNG + " out of " + (WEATHER_STATE == WEATHER_STATE.RAIN_AND_THUNDER ? 35 : 50) + " " + WEATHER_STATE + e);

                    random_frequency = Random.Range(x - 60, x + 120);
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
