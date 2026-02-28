using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerControls : MonoBehaviour
{
    private Rigidbody rbPlayer; //to give the player force(and get their velocity) the player
    public Transform tfCamera; //for direction since it is relative to the camera, recommend setting as a parent to the camera(or parent to parent camera)
    private Animator animator; //for animations

    public float speed = 5.0f; //for control of the horizontal force
    public float jumpHeight = 5.0f; //for control of jump height force
    public float acceleration = 40.0f;//for control of how fast the player can change direction

    public bool jump = false; //a simple bool that tells the player to jump
    public bool isGrounded = false; //a bool for knowing if the player is on the ground


    void Start()
    {
        //these just grab the comonents so you don't have to put them in manuelly in the editor
        rbPlayer = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }



    void FixedUpdate()
    {
        //grabs the input values
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        Vector3 inputDirection = new Vector3(xInput, 0, yInput); //this if statement insures you can't move faster in a diagonal direction

        if (inputDirection.magnitude > 1.0f)
        {
            inputDirection.Normalize();
        }

        //this is so that the direction is relitive to the direction the camera is facing(except it's forward tilit so that the xRotation of the camera doesn't affect the direction you go)
        Vector3 camForward = tfCamera.forward;
        Vector3 camRight = tfCamera.right;

        Vector3 targetVelocity = (camForward * inputDirection.z + camRight * inputDirection.x) * speed; //this calculates what velocity we want to go

        Vector3 velocityChange = targetVelocity - new Vector3(rbPlayer.linearVelocity.x, 0.0f, rbPlayer.linearVelocity.z); //this calculates the difference between how fast we want to go, and our current velocity

        Vector3 velocityChangeClamped = Vector3.ClampMagnitude(velocityChange, acceleration * Time.fixedDeltaTime);//this clamps the velocityChange so you can't accelerate too much between movements and potentially cancel out any physics interaction

        rbPlayer.AddForce(velocityChangeClamped * rbPlayer.mass, ForceMode.Impulse); //and this finally applies that force realitive to the objects mass

        if (xInput != 0.0f || yInput != 0.0f) //this if/else statement just sets the animation correctly
        {
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }



        //this if statement essitially says, if you are moving at all, change the rotation variable of the object(transform.rotation) to be the angle of both inputs(Mathf.Atan2(xInput,yInput) * Mathf.Rad2Deg) realitive to the direction of the camera's y rotation(tfCamera.up), offset by the current camera's rotation(tfCamera.eulerAngles.y)(offset because the direction the camera is pointed and the camera's current rotation are different things so you need both to make it point correctly)
        if (xInput != 0 || yInput != 0)
        {
            transform.rotation = Quaternion.AngleAxis(Mathf.Atan2(xInput, yInput) * Mathf.Rad2Deg + tfCamera.eulerAngles.y, tfCamera.up);
        }



        if (Input.GetAxis("Jump") > 0.0f)// simple if statement setting the jump variable to true if you pressed jump
        {
            jump = true;
        }


        if (rbPlayer.linearVelocity.y >= -0.5f && rbPlayer.linearVelocity.y <= 0.5f) //this checks if you are at a vertical linearVelocity of about 0
        {
            Collider[] hitColliders = Physics.OverlapCapsule(transform.position, transform.position, 0.25f); //this grabs of list of collisions for this collider at the player's feet
            foreach (Collider hit in hitColliders) //this goes through the list of collisions and if you are touching something tagged ground, sets isGrounded to true
            {
                if (hit.CompareTag("Ground"))
                {
                    isGrounded = true;
                    break;
                }
            }
        }
        else //if you are not at a vertical velocity of about 0, you are definitly not on the ground so this sets the isGrounded tag to false
        {
            isGrounded = false;
        }


        if (isGrounded && jump) //this just jumps you if jump is true and isGrounded is true
        {
            rbPlayer.AddForce(new Vector3(0.0f, jumpHeight, 0.0f), ForceMode.Impulse);
        }

        jump = false; //sets jump to false because you either jumped or couldn't there for jump is an invalid input
    }
}
