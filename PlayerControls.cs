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
        float yInput = Input.GetAxis("Vertical");
        if (yInput != 0)
        {

            float targetVelocity = yInput * speed; //this calculates what velocity we want to go

            float velocityChange = targetVelocity - rbPlayer.linearVelocity.y; //this calculates the difference between how fast we want to go, and our current velocity

            float velocityChangeClamped = Mathf.Clamp(velocityChange, -acceleration * Time.fixedDeltaTime, acceleration * Time.fixedDeltaTime);//this clamps the velocityChange so you can't accelerate too much between movements and potentially cancel out any physics interaction

            rbPlayer.AddForce(new Vector3(0.0f, velocityChangeClamped * rbPlayer.mass, 0.0f), ForceMode.Impulse); //and this finally applies that force realitive to the objects mass
        }
    }
}
