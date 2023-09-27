using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TankMovementN : MonoBehaviour
{
    public float speed;
    public float boostSpeed;
    private float counter;
    public float timer;
    private Rigidbody rb;
    public int rotateSpeed;


 
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        PlayerControler playerControler = new PlayerControler();
        //playerControler.Enable();
        playerControler.InGamePlayerOne.Enable();

        //playerControler.InGamePlayerOne.Fire.performed

        playerControler.InGamePlayerOne.WASD.performed += MoveOnPerformed;

    }

    private void MoveOnPerformed(InputAction.CallbackContext context)
    {
        Debug.Log(context.ReadValue<Vector2>());
      
    }


    // Update is called once per frame
    void Update()
    {
       
    }
    
    
    

}
