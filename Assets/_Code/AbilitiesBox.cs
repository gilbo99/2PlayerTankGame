using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;


public class AbilitiesBox : MonoBehaviour
{
    public List<GameObject> item;
    private GameObject give;
    
    public void Awake()
    {
        give = item[Random.Range(0, item.Count)];
    }
    
    public GameObject SendItem()
    {
        return give;
    }
}
