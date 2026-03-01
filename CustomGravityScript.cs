using UnityEngine;

public class CustomGravityScript : MonoBehaviour
{
    public Rigidbody rb;
    public float GravityScale = 5f;
    void Start(){
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        rb.AddForce(Vector3.down * GravityScale);
    }
}
