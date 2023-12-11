using UnityEngine.InputSystem;

public interface IDriveable
{
 
  public void Steer(InputAction.CallbackContext aContext);

  public void Forward(InputAction.CallbackContext aContext);

  public void Break(InputAction.CallbackContext aContext);
}
