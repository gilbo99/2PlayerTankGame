using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Andrew;
public class Mine : MonoBehaviour, IAbilitiesStats
{
    private Rigidbody rb;
    private GameManager gm;
    
    public Transform transform { get; set; }
    public GameObject owner { get; set; }

    public Transform spawn;
    public new string name;
    
    //Mine stats
    public int damage;
    public void Awake()
    {
        transform = spawn;
        gm = FindObjectOfType<GameManager>();
        rb = this.GetComponent<Rigidbody>();
        //rb.velocity = Vector3.zero;
    }
    
    private void OnCollisionEnter(Collision other)
    {
            if (other.gameObject.GetComponent<TankStats>())
            {
                Destroy(this.gameObject);
                //other.gameObject.GetComponent<TankStats>().TakeDamage(damage, playerID, name);
                
            }
        
    }
    
    public void SetOwner(GameObject tank)
    {
        owner = tank;

    }

    
}
