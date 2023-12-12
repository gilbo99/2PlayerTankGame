using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Andrew
{
    public class SpecialAbilities : MonoBehaviour
    {
        public List<Ability> ability;
       
        
        
        
        public void UseAbility()
        {
            if (ability.Count == 0){return;}
            
            
            var clone = Instantiate(ability[0].item, ability[0].spawn, new Quaternion());
            clone.GetComponent<IAbilitiesStats>().owner = gameObject;
            if (ability[0].item.name == "Shield")
            {
                clone.transform.parent = transform;
                clone.transform.position = transform.position;
            }
            ability.Clear();


        }


        

        public void OnTriggerEnter(Collider other)
        {
            
            if (ability.Count != 0) {return;}
            if (!other.gameObject.GetComponent<AbilitiesBox>()){return;}
            var box = other.transform.GetComponent<AbilitiesBox>();
            var Abilitys = new Ability();
            Abilitys.Setitem(box.give, gameObject);
            ability.Add(Abilitys);
            other.gameObject.GetComponent<AbilitiesBox>().KillMe();


        }

        
    }
    
    
    
   
    
    
    
    
    [Serializable]
    public class Ability
    {
        public void Setitem(GameObject receivedItem, GameObject tank)
        {
            item = receivedItem;
            spawn = GetSpawn(receivedItem.name);
            item.GetComponent<IAbilitiesStats>().owner = tank;
        }
        
        public GameObject item;
        public Vector3 spawn;
        
        
        public Vector3 GetSpawn(string itemName)
        {
            //hack
            if (itemName == "Rocket")
            {
                return new Vector3(0,2,0);

            }
            if (itemName == "Mine")
            {
                return new Vector3(0,0,-2);
            }
            if (itemName == "Shield")
            {
                return new Vector3(0,0,0);
            }


            return new Vector3();
        }
    }
    
}

