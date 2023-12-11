using System;
using System.Collections.Generic;
using UnityEngine;


namespace Andrew
{
    public class SpecialAbilities : MonoBehaviour
    {
        public List<Ability> ability;
        
        
        
        public void UseAbility()
        {
            if (ability.Count == 0){return;}
            
            
            

            Instantiate(ability[0].item, ability[0].spawn);
            ability.Clear();


        }


        public void OnCollisionEnter(Collision other)
        {
            if (!other.transform.GetComponent<AbilitiesBox>()){return;}
            var box = other.transform.GetComponent<AbilitiesBox>();

            var Abilitys = new Ability();
            Abilitys.Setitem(box.give);
            ability.Add(Abilitys);



        }
    }
    
    
    
   
    
    
    
    
    [Serializable]
    public class Ability
    {
        public void Setitem(GameObject receivedItem)
        {
            item = receivedItem;
            
        }
        
        public GameObject item;
        public Transform spawn;
    }
}

