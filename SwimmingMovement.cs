using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))] // This gives the object the rigid body component if it doesn't have one
public class SwimmingMovement : MonoBehaviour
{
    public Transform direction; // This should be the camera so if you look down and go forward, you swim down
    public InputSystemActions controls; // this is the input system for the player
    public bool allowSwimming = true;

    [Header("Swimming")]
    public float speed = 4.0f; // The speed you want to be able to swim at
    public float acceleration = 15.0f; // How fast you can change your speed
    public float verticalSpeedMultiplier = 0.85f; // This is how much faster or slower you want your vertical swimming to be

    private Rigidbody rbPlayer; // The rigidbody component for your player so you can move them and find velocity
    private Vector2 horizontalInput; // this variable is for grabbing your input for the x and z direction
    private float verticalInput; // this variable is for grabbing your input for the y direction

    void Awake()
    {
        rbPlayer = GetComponent<Rigidbody>(); // Grabs the Rigidbody component for you

        controls = InputScript.InputSysAc; // This Grabs the input system script

        // These grab your input values from the input system and sets the input variables accordingly(for this to work, jump must be an axis in your input system)
        controls.Player.Move.performed += ctx => horizontalInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => horizontalInput = Vector2.zero;
        controls.Player.Jump.performed += ctx => verticalInput = ctx.ReadValue<float>();
        controls.Player.Jump.canceled += ctx => verticalInput = 0.0f;

    }



    void FixedUpdate()
    {
        if (allowSwimming)
        {
            Vector3 inputDirectionX = direction.right * horizontalInput.x; // This multiplies your right/left input by the right direction of the camera
            Vector3 inputDirectionY = Vector3.up * verticalInput; // This multiplies the up direction by the universal up direction so up doesn't move you back, and so that you don't get turned around
            Vector3 inputDirectionZ = direction.forward * horizontalInput.y; // This multiplies your forward/back input by the forward direction of the camera

            Vector3 moveDirection = inputDirectionX + inputDirectionY + inputDirectionZ; // This combines all of the directions

            Vector3 targetDirection = Vector3.ClampMagnitude(moveDirection, 1.0f); // this normalizes the moveDirection if it is greater than 1.0f to get the target vector
            targetDirection.y *= verticalSpeedMultiplier; // this multiplies the y direction by verticalSpeedMultiplier so swimming in the y direction is slower than the horizontal direction

            Vector3 targetVelocity = targetDirection * speed; // this multiplies your targetDirection by speed to find the vector for velocity you want to go you want to go

            Vector3 velocityChange = targetVelocity - rbPlayer.linearVelocity; // this calculates the vector for pushing from your current velocity to the velocity you want to go

            // these lines prevent the velocityChange from applying a force stronger than the targetVelocity, in each direction
            velocityChange.x = Mathf.Clamp(velocityChange.x, -Mathf.Abs(targetVelocity.x), Mathf.Abs(targetVelocity.x));
            velocityChange.y = Mathf.Clamp(velocityChange.y, -Mathf.Abs(targetVelocity.y), Mathf.Abs(targetVelocity.y));
            velocityChange.z = Mathf.Clamp(velocityChange.z, -Mathf.Abs(targetVelocity.z), Mathf.Abs(targetVelocity.z));

            Vector3 velocityChangeClamped = Vector3.ClampMagnitude(velocityChange, acceleration * Time.fixedDeltaTime); // This clamps the amount of force you can give yourself every second by fixedDeltaTime and the acceleration you set to, further prevent canceling out physics interaction

            rbPlayer.AddForce(velocityChangeClamped, ForceMode.VelocityChange); //this finally adds the force(using ForceMode.VelocityChange to ignore your mass)
        }
    }
}
