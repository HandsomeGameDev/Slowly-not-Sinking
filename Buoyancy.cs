using UnityEngine;

[RequireComponent(typeof(Rigidbody))] // This gives the object the rigid body component if it doesn't have one
public class Buoyancy : MonoBehaviour
{
    public float buoyantForce = 5.0f;
    public bool enableBuoyancy = true;

    [Header("Drag")]
    public float waterDrag = 2.0f;
    public float waterAngularDrag = 4.0f;

    private Rigidbody rbPlayer;

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>(); // Grabs the Rigidbody componet for you
        rbPlayer.linearDamping = waterDrag;
        rbPlayer.angularDamping = waterAngularDrag;
    }

    void FixedUpdate()
    {
        if (enableBuoyancy)
        {
            rbPlayer.AddForce(Vector3.up * buoyantForce, ForceMode.Acceleration);
        }
    }
}
