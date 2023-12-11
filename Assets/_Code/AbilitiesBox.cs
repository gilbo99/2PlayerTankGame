using System.Collections.Generic;
using UnityEngine;



public class AbilitiesBox : MonoBehaviour
{
    public List<GameObject> item;
    public GameObject give;
    
    public void Awake()
    {
        give = item[UnityEngine.Random.Range(0, item.Count)];
    }


    public void Killme()
    {
        Destroy(gameObject);
    }
    
   
}

