
using System;
using UnityEngine;

public class TankControl : MonoBehaviour
{
    public GilboInput gilboInput;
    

    public void Awake()
    {
        gilboInput = new GilboInput();
        gilboInput.InCar.Enable();
    }
}
