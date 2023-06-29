using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpFuncional : MonoBehaviour
{
    Rigidbody myRig;
    //private PlayerJumpFuncional jumpy;
    [SerializeField] private float jumpForce = 5;
    public bool onFloor = true;
    Charview view;

    void Awake()
    {
        myRig = GetComponent<Rigidbody>();
        //jumpy = GetComponent<PlayerJumpFuncional>();
        view = GetComponent<Charview>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && onFloor == true)
        {
            view.Salto(true);
            AnimRealJump();
            onFloor = false;
        }
    }

    void AnimRealJump()
    {
        Vector3 jumpDirection = Vector3.up * jumpForce;

        myRig.velocity += jumpDirection;
        onFloor = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        view.Salto(false);
        if (collision.gameObject.tag == "Floor")
        {
            onFloor = true;
        }
    }
}
