using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class VerticalSwimming : MonoBehaviour
{
    private Rigidbody rbPlayer; //to give the player force(and get their velocity) the player
    public float heightcap = -40f;

    public float speed = 5.0f; //for control of the horizontal force
    public float acceleration = 40.0f;//for control of how fast the player can change direction

    void Start()
    {
        //these just grab the comonents so you don't have to put them in manuelly in the editor
        rbPlayer = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        if (rbPlayer.position.y >= heightcap)
        {
            rbPlayer.linearVelocity = new Vector3(rbPlayer.linearVelocity.x, 0.0f, rbPlayer.linearVelocity.z);
            rbPlayer.AddForce(Vector3.down * 5);
        }

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
