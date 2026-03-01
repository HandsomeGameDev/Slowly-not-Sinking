using UnityEngine;

public class PlayerNearCheck : MonoBehaviour
{
    public static GameObject ToolToPickUp;
    public void OnTriggerEnter(Collider collider)
    {
        ToolToPickUp = this.gameObject;
    }
    public void OnTriggerExit(Collider collider)
    {
        ToolToPickUp = null;
    }
}
