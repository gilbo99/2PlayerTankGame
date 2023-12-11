using UnityEngine;

namespace Andrew
{
    [SelectionBase]
    public class PlayerController : MonoBehaviour
    {

        public GilboInput gilboInput;
        public GameObject tank;

        public void Start()
        {
            gilboInput = new GilboInput();

            gilboInput.InCar.Enable();
            gilboInput.InCar.Move.performed += aContext => tank.GetComponent<IDriveable>().Steer(aContext);
            gilboInput.InCar.Move.performed += aContext => tank.GetComponent<IDriveable>().Forward(aContext);
            gilboInput.InCar.Move.performed += aContext => tank.GetComponent<IDriveable>().Break(aContext);
            
        }
    }
}
