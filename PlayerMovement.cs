using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public GameObject CameraGO;
    public Rigidbody rb;
    public float Speed = 5f;
    public Vector2 PlayerInput;
    public InputSystemActions controls;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        controls = InputScript.InputSysAc;
        controls.Player.Move.performed += ctx => PlayerInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => PlayerInput = Vector2.zero;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 PlayerForwardMovement = CameraGO.transform.forward * PlayerInput.y * Speed;
        Vector3 PlayerHorizontalMovement = CameraGO.transform.right * PlayerInput.x * Speed;
        rb.linearVelocity = PlayerHorizontalMovement + PlayerForwardMovement;
    }
}
