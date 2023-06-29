using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody myRig;
    private float yVelocity;
    [SerializeField] private float speed = 200f;

    private PlayerJumpFuncional jumpy;
    Charview view;

    private void Awake()
    {
        myRig = GetComponent<Rigidbody>();
        jumpy = GetComponent<PlayerJumpFuncional>();
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

            // Check for movement
            if (horizontalMove.magnitude > 0.1f)
            {
                // There is movement, play animation
                view.Isrunning(true);
            }
            else
            {
                // No movement, pause animation
                view.Isrunning(false);
            }
        }
        else // If the player is in the air
        {
            // Apply movement velocity in the movement direction
            Vector3 move = moveDirection * speed * Time.deltaTime;
            myRig.velocity = new Vector3(move.x, myRig.velocity.y, move.z);

            // Pause animation in the air
            view.Isrunning(false);
        }
    }
}