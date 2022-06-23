using System;
using UnityEngine;
/*
        That script will manage the logic behind the increase / decrease of the player's reputation

        the idea behind it is the following : 
        -> if you are unliked, students wont accept to give you infos or interact with them, but you are less susceptible to be exposed by the cult

        -> if you are liked, students will help you, but you'll become a prime target.

        while it will be expliqued in game, the best way of playing is to stay in the low 50 of reputation or high 40.
*/
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

    // in theory, should handle every possible value of the GameGlobal.Reputation
    public REPUTATION_NAME reput()
    {
        // YandereDev would be proud.
        if(GameGlobal.Reputation > -100 && GameGlobal.Reputation < -50){
            return REPUTATION_NAME.OUTCAST;
        } else if(GameGlobal.Reputation > -50 && GameGlobal.Reputation < -10){
            return REPUTATION_NAME.UNLIKED;
        } else if(GameGlobal.Reputation > -10 && GameGlobal.Reputation < 10){
            return REPUTATION_NAME.NO_NAME;
        } else if(GameGlobal.Reputation > 10 && GameGlobal.Reputation < 50){
            return REPUTATION_NAME.LIKED;
        } else if(GameGlobal.Reputation > 50 && GameGlobal.Reputation < 75){
            return REPUTATION_NAME.LOVED;
        } else if(GameGlobal.Reputation > 75 && GameGlobal.Reputation < 100){
            return REPUTATION_NAME.GODDESS;
        } else{
            return REPUTATION_NAME.OUT_OF_BOUND;
        }
    }

    // used for GUI display
    public string reputAsString(){
        switch(reput()){
            case REPUTATION_NAME.OUT_OF_BOUND:
                return "HackerMan";

            case REPUTATION_NAME.OUTCAST:
                return "Social Outcast";
            
            case REPUTATION_NAME.UNLIKED:
                return "Unpopular";
            
            case REPUTATION_NAME.NO_NAME:
                return "Unknown";
            
            case REPUTATION_NAME.LIKED:
                return "Popular";
            
            case REPUTATION_NAME.LOVED:
                return "Really Popular";
            
            case REPUTATION_NAME.GODDESS:
                return "HackerMan";
            
            default:
                return "How did you even did that that ? it shouldn't even be possible";
        }
    }
}


public enum REPUTATION_NAME
{
    OUT_OF_BOUND,       // for any unsupported values (shouldn't happen, but just in case)
    OUTCAST,            // -100 to -50
    UNLIKED,            // -50 to -10
    NO_NAME,            // -10 to 10
    LIKED,              //  10 to 50
    LOVED,              //  50 to 75
    GODDESS             //  75 to 100
}