using UnityEngine;
using UnityEngine.InputSystem;

public class PickingUpSystem : MonoBehaviour
{
    private InputAction clickAction;
    private SinkingScript SinkingS;
    void Awake()
    {
        InputScript.InputSysAc.Player.PickUp.performed += ctx => OnPickUp();
    }

    void Start(){
        SinkingS = GetComponent<SinkingScript>();
    }

    void OnPickUp()
    {
        if(PlayerNearCheck.ToolToPickUp != null)
        {
            Destroy(PlayerNearCheck.ToolToPickUp);
            SinkingS.heightCap += 25;
        }
    }
}
