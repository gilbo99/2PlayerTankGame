using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    private Rigidbody rb;
    private GameManager gm;
    
    //Mine stats
    public int damage;
    public void Awake()
    {
        gm = FindObjectOfType<GameManager>();
        rb = this.GetComponent<Rigidbody>();
        
    }
    
    private void OnCollisionEnter(Collision other)
    {
            if (other.gameObject.GetComponent<TankStats>())
            {
                Destroy(this.gameObject);
                other.gameObject.GetComponent<TankStats>().TakeDamaged(damage);
                
            }
        
    }
}
