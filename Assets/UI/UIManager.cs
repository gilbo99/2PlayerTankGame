using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class UIManager : MonoBehaviour
{
   
   public List<TextMeshProUGUI> players;

   public GameObject reset;

   public void SetPlayerHP(int hp , int id)
   {
         players[id].text = hp.ToString();
      
   }

   public void Toggle(bool active)
   {
       reset.gameObject.SetActive(active);
   }

  


}
