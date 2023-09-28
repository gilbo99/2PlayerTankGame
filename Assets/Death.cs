using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    
    public void KillMe()
    {
        Destroy(this.gameObject);
    }
}
