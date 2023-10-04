using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartOff : MonoBehaviour
{
    
    public GameObject uiStart;
    private void OnEnable()
    {
        uiStart.SetActive(false);
        
    }

    private void Update()
    {
        
    }

    private void OnDestroy()
    {
       
    }
}
