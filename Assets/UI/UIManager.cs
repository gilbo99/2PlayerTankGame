using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
   
   public List<TextMeshProUGUI> players;

   public List<TextMeshProUGUI> score;

   public List<int> currentScore;

   public List<GameObject> shield;

   public List<GameObject> boost;
   
   
   public GameObject reset;

   public GameManager gm;


   public void OnEnable()
   {
       gm.Score += UpdateScore;
   }
    
   public void OnDisable()
   {
       gm.Score -= UpdateScore;
   }

   public void SetPlayerHP(int hp , int id)
   {
         players[id].text = hp.ToString();
      
   }

   public void Toggle(bool active)
   {
       if (reset.gameObject != null)
       { 
           reset.gameObject.SetActive(active);
           
       }
      
   }

   public void ShieldOn(int id,bool t)
   {
       shield[id].SetActive(t);
   }
   public void BoostOn(int id,bool t)
   {
       boost[id].SetActive(t);
   }

   public void UpdateScore(int id)
   {
       currentScore[id]++;
       var test = currentScore[id].ToString();
       score[id].text = test;
   }


   public void HealthSubTo(GameObject tank)
   {

       tank.GetComponent<TankStats>().setHealth += SetPlayerHP;

   }
   
   public void HealthUnSubTo(GameObject tank)
   {

       tank.GetComponent<TankStats>().setHealth -= SetPlayerHP;

   }
   
   



   
   
   


}
