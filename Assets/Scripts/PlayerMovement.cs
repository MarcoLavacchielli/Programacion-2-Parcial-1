using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public ParticleSystem dust;

    private Rigidbody myRig;
    private float yVelocity;
    public float speed = 200f;

    private PlayerJump jumpy;

    Charview view;

    private void Awake()
    {
        myRig = GetComponent<Rigidbody>();
        jumpy = GetComponent<PlayerJump>();

        view = GetComponent<Charview>();
    }

    private void FixedUpdate()
    {
        // Get the direction of the camera
        Vector3 cameraDirection = Camera.main.transform.forward;
        cameraDirection.y = 0f;
        cameraDirection.Normalize();

        // Get the input axes
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Calculate the movement direction based on camera direction and input axes
        Vector3 moveDirection = (cameraDirection * verticalInput + Camera.main.transform.right * horizontalInput).normalized;

        // Check if the player is on the ground
        if (jumpy.onFloor)
        {
            // Apply movement velocity only on the x and z axes
            Vector3 horizontalMove = moveDirection * speed * Time.deltaTime;
            myRig.velocity = new Vector3(horizontalMove.x, myRig.velocity.y, horizontalMove.z);

            // check if the player is moving and on the ground
            if (moveDirection.magnitude > 0.3f)
            {
                // play the particle system
                /*if (!dust.isPlaying)
                {
                    dust.Play();
                }*/
                view.Isrunning(true);
            }
            else
            {
                // stop the particle system
                /*if (dust.isPlaying)
                {
                    dust.Stop();
                }*/
                view.Isrunning(false);
            }
        }
        else // If the player is in the air
        {
            // Apply movement velocity in the direction the player is facing
            Vector3 forwardMove = transform.forward * speed * Time.deltaTime;
            myRig.velocity = new Vector3(forwardMove.x, myRig.velocity.y, forwardMove.z);
        }
    }
}
