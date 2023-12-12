using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Andrew
{
    public class UI : MonoBehaviour
    {
        public List<GameObject> currentPlayers;
        public GameManager gameManager;
        
        
        
        public void AddPlayers(GameObject player)
        {
            currentPlayers.Add(player);
            player.GetComponent<TankStats>();
        }
        
        public void RemovePlayers(GameObject player)
        {
            if (currentPlayers.Contains(player))
            {
                currentPlayers.Remove(player);
            }
        }
    }


   
}
