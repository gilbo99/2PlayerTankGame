using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
    public List<GameObject> playerHud;
   
   public List<TextMeshProUGUI> playerhp;

   public List<TextMeshProUGUI> score;

   public List<int> currentScore;

   public List<GameObject> shield;

   public List<GameObject> boost;
   
   
   public GameObject reset;

   public ArenaManager gameMode;

   public void Start()
   {
      // gameMode.Score += UpdateScore;
       gameMode.uiSetup += LayoutUI;
       LayoutUI(2);
   }

   private void LayoutUI(int player)
   {
       for (int j = 0; j < player; j++)
       {
           var clone = Instantiate(playerHud[j]);
           playerhp.Add(clone.transform.GetChild(0).GetComponent<TextMeshProUGUI>()); 
           shield.Add(clone.transform.GetChild(2).gameObject); 
           boost.Add(clone.transform.GetChild(3).gameObject); 
           score.Add(clone.transform.GetChild(4).GetComponent<TextMeshProUGUI>()); 
       }
       
   }


   public void OnDisable()
   {
      /// gameMode.Score -= UpdateScore;
   }

   public void SetPlayerHP(int hp , int id)
   {
       playerhp[id].text = hp.ToString();
      
   }

   

   public void ShieldOn(int id,bool t)
   {
       shield[id].SetActive(t);
   }
   public void BoostOn(int id,bool t)
   {
       boost[id].SetActive(t);
   }

    void UpdateScore(GameObject player)
   {
       /*
           currentScore[id]++;
           var test = currentScore[id].ToString();
           score[id].text = test;
           */
   }


   public void HealthSubTo(GameObject tank)
   {

       //tank.GetComponent<TankStats>().setHealth += SetPlayerHP;

   }
   
   public void HealthUnSubTo(GameObject tank)
   {

       //tank.GetComponent<TankStats>().setHealth -= SetPlayerHP;

   }
   
   



   
   
   


}
