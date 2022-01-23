using System;
using UnityEngine;

public class ReputationMecanic : MonoBehaviour
{
    public void Start()
    {
        // if reputation is not between -100 and 100, we reset it to the nearest limit
        if (GameGlobal.Reputation < -100)
        {
            GameGlobal.Reputation = -100;
        }
        else if (GameGlobal.Reputation > 100)
        {
            GameGlobal.Reputation = 100;
        }
    }
}

public enum REPUTATION_NAME
{
    OUTCAST,            // -100 to -50
    UNLIKED,            // -50 to -10
    UNKNOWN,            // -10 to 10
    LIKED,              //  10 to 50
    LOVED,              //  50 to 75
    GODDESS             //  75 to 100
}