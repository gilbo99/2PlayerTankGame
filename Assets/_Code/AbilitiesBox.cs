using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class AbilitiesBox : MonoBehaviour
{
    public List<GameObject> item;
    private GameObject give;
    
    public void Awake()
    {
        give = item[UnityEngine.Random.Range(0, item.Count)];
    }
    
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent<SpecialAbilities>(out SpecialAbilities Special) && Special.ability == null)
        {
            Special.SetAbility(give);
            Destroy(this.gameObject);
        }
    }
    
   
}

