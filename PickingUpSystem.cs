using UnityEngine;
using UnityEngine.InputSystem;

public class PickingUpSystem : MonoBehaviour
{
    public InputSystemActions controls;
    public VerticalSwimming VSwimming;
    void Awake(){
        controls = InputScript.InputSysAc;
        controls.Player.PickUp.performed += ctx => PickUpMethod(ctx);
    }

    void Start(){
        VSwimming = GetComponent<VerticalSwimming>();
    }
    void PickUpMethod(InputAction.CallbackContext ctx)
    {
        if(PlayerNearCheck.ToolToPickUp != null)
        {
            Destroy(PlayerNearCheck.ToolToPickUp);
            VSwimming.heightcap += 24;
        }
    }
}
