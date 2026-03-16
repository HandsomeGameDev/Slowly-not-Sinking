using UnityEngine;

public class SinkingScript : MonoBehaviour
{
    public float heightCap = -100.0f;
    public float forceMagnitude = 5.0f;
    public float deltaHeightRange = 5.0f;
    private Rigidbody rbPlayer;
    private float heightDistance;

    void Start()
    {
        rbPlayer = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        heightDistance = Mathf.Abs(rbPlayer.position.y) + heightCap;
        if (heightDistance <= deltaHeightRange)
        {
            float forceMultiplier = deltaHeightRange - heightDistance;
            rbPlayer.AddForce(Vector3.down * forceMultiplier * forceMagnitude);
        }
    }
}
