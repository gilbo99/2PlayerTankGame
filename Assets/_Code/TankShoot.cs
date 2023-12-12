using UnityEngine;
using UnityEngine.InputSystem;

public class TankShoot : MonoBehaviour
{
    
    public GameObject bullet;
    public Transform spawnbullet;
    public bool shooting;
    public float ShootingForce;

    public float cooldown;

    public void Update()
    {

        if (cooldown < 0 && shooting)
        {
            var clone = Instantiate(bullet, spawnbullet.position, spawnbullet.rotation);
            clone.GetComponent<Bullet>().owner = gameObject;
            cooldown = clone.GetComponent<Bullet>().cooldown;
            var Push = new Vector3(0,0,-ShootingForce);
            GetComponent<Rigidbody>().AddForce(Push);
        }
        else
        {
            shooting = false;
        }

        cooldown -= Time.deltaTime;

    }

    public void Shoot()
    {
        shooting = true;
    }
    
    
    
}
