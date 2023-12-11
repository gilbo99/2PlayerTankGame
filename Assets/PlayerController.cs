using UnityEngine;

namespace Andrew
{
    [SelectionBase]
    public class PlayerController : MonoBehaviour
    {

        public GilboInput gilboInput;
        private GameObject tank;

        public void Start()
        {
            tank = gameObject;
            gilboInput = new GilboInput();

            gilboInput.InCar.Enable();
            gilboInput.InCar.Aim.performed += aContext => tank.GetComponent<IDriveable>().Steer(aContext);
            gilboInput.InCar.Move.performed += aContext => tank.GetComponent<IDriveable>().Forward(aContext);
            gilboInput.InCar.Move.performed += aContext => tank.GetComponent<IDriveable>().Break(aContext);
            gilboInput.InCar.Shoot.performed += aContext => tank.GetComponent<TankShoot>().Shoot();
            gilboInput.InCar.Abilities.performed += aContext => tank.GetComponent<SpecialAbilities>().UseAbility();

        }
    }
}
