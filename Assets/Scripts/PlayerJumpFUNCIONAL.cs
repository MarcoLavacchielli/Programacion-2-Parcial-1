using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpFUNCIONAL : MonoBehaviour
{
    //public ParticleSystem dustJump;

    Rigidbody myRig;
    public float jumpForce = 5;
    public bool onFloor = true;

    Charview view;

    void Awake()
    {
        myRig = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onFloor)
        {
            view.AnimJump();
            Vector3 jumpDirection = transform.forward * myRig.velocity.magnitude;
            jumpDirection.y = jumpForce;

            myRig.velocity = jumpDirection;
            onFloor = false;

            //dustJump.Play();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            onFloor = true;
            //dustJump.Play();
        }
    }
}
