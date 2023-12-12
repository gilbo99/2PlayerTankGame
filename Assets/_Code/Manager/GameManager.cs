using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Andrew
{
    public class GameManager : MonoBehaviour
    {
        private PlayerInputManager inputManager;
        public UI UIManager;
        public List<Transform> playerSpawn;
        public List<GameObject> activePlayers;
        public int playersSpawned;
        public GameObject UIPre;
        
        public void Start()
        {
            UIManager = GetComponent<UI>();
            inputManager = GetComponent<PlayerInputManager>();
            inputManager.onPlayerJoined += OnJoined;
            inputManager.onPlayerLeft += OnLeft;
        }

        private void OnJoined(PlayerInput obj)
        {
            activePlayers.Add(obj.gameObject);
            SetPlayerLocation(obj.gameObject);
            var ui = Instantiate(UIPre);
            ui.GetComponent<Canvas>().worldCamera = GetComponent<Camera>();
            UIManager.AddPlayers(obj.gameObject);

            //obj.gameObject.GetComponent<Rigidbody>().isKinematic = true;

        }

        private void SetPlayerLocation(GameObject player)
        {
            player.transform.position = playerSpawn[playersSpawned].position;
            player.transform.rotation = playerSpawn[playersSpawned].rotation;
            playersSpawned++;
    
        }

        public void OnLeft(PlayerInput obj)
        {
            if (activePlayers.Contains(obj.gameObject))
            {
                activePlayers.Remove(obj.gameObject);
                UIManager.RemovePlayers(obj.gameObject);
                Destroy(obj.gameObject);
             
            }
        }

        public void OnDisable()
        {
            inputManager.onPlayerJoined -= OnJoined;
            inputManager.onPlayerLeft -= OnLeft;
        }


        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (activePlayers.Count <= 2)
                {

                    for (int i = 0; i < activePlayers.Count; i++)
                    {
                        activePlayers[i].GetComponent<Rigidbody>().isKinematic = false;
                    }
                
                }
            }
            
        }
    }
}

