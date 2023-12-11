using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    private Rigidbody rb;
    private GameManager gm;

    public int playerID;

    public new string name;
    
    //Mine stats
    public int damage;
    public void Awake()
    {
        
        gm = FindObjectOfType<GameManager>();
        rb = this.GetComponent<Rigidbody>();
        //rb.velocity = Vector3.zero;
    }
    
    private void OnCollisionEnter(Collision other)
    {
            if (other.gameObject.GetComponent<TankStats>())
            {
                Destroy(this.gameObject);
                other.gameObject.GetComponent<TankStats>().TakeDamage(damage, playerID, name);
                
            }
        
    }
    
    public void SetID(int id)
    {
        playerID = id;
        
    }
}
