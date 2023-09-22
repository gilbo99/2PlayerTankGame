using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class AbilitiesBox : MonoBehaviour
{
    private Abilities abilities;
    public List<GameObject> item;
    private GameObject give;

    private enum Abilities
    {
        Rocket,
        Mine,
        Shield
    }


    public void Awake()
    {

        abilities = (Abilities)Random.Range(0,Enum.GetNames(typeof(Abilities)).Length);

        
        switch (abilities)
        {
            case Abilities.Rocket:
                give = item[0];
                break;
            case Abilities.Mine:
                give = item[1];
                break;
            case Abilities.Shield:
                give = item[2];
                break;
            
        }
        
    }


    public GameObject SendItem()
    {
        return give;
    }
}
