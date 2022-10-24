using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class City_ChillZone_InteractPanel : MonoBehaviour
{

    public static City_ChillZone_Sofa sofa;

    /// <summary>
    ///     Used to know where the player is sitting
    /// </summary>
    /// <param name="sofa">instance that the player choose to use</param>
    public static void SetActiveSofa(City_ChillZone_Sofa _sofa)
    {
        sofa = _sofa;
    }

    /// <summary>
    ///     Allow to order a bunch of stuff
    /// </summary>
    /// <param name="id">item to summon</param>
    void Order(int id)
    {

    }

    void Leave(){}
}