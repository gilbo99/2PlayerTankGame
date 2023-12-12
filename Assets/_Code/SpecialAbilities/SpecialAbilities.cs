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


        

        public void OnTriggerEnter(Collider other)
        {
            
            if (ability.Count != 0) {return;}
            if (!other.gameObject.GetComponent<AbilitiesBox>()){return;}
            var box = other.transform.GetComponent<AbilitiesBox>();
            var Abilitys = new Ability();
            Abilitys.Setitem(box.give, box.transform, gameObject);
            ability.Add(Abilitys);
            other.gameObject.GetComponent<AbilitiesBox>().KillMe();


        }
    }
    
    
    
   
    
    
    
    
    [Serializable]
    public class Ability
    {
        public void Setitem(GameObject receivedItem, Transform transform, GameObject tank)
        {
            item = receivedItem;
            spawn = transform;
            item.GetComponent<IAbilitiesStats>().owner = tank;
        }
        
        public GameObject item;
        public Transform spawn;
    }
}

