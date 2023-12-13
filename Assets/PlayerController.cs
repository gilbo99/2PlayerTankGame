using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Andrew
{
    [SelectionBase]
    public class PlayerController : MonoBehaviour
    {

        public GilboInput gilboInput;
        public GoCar tank;
        public TankShoot tankShoot;
        public SpecialAbilities abilities;
        
        public PlayerInput player;
 
        public void Start()
        {
            //gilboInput = new GilboInput();

            //gilboInput.InCar.Enable();
            player.actions.FindAction("Aim").performed += aContext => tank.GetComponent<IDriveable>().Steer(aContext);
            player.actions.FindAction("Forward").performed += aContext => tank.GetComponent<IDriveable>().Forward(aContext);
            player.actions.FindAction("Backward").performed += aContext => tank.GetComponent<IDriveable>().Break(aContext);
            player.actions.FindAction("Shoot").performed += aContext => tankShoot.GetComponent<TankShoot>().Shoot();
            player.actions.FindAction("Abilities").performed += aContext => abilities.GetComponent<SpecialAbilities>().UseAbility();
            gilboInput.InCar.Leave.performed += aContext => PlayerLeft();
           
            
        }
        
        
        public void PlayerLeft()
        {
            Destroy(player);
            Destroy(tank);
            gilboInput.Dispose();
           
        }

       
        
    }
}
 