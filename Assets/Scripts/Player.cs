using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float horizonalMove;
    public float verticalMove;
    private Vector3 playerInput;
    public Camera mainCamera;
    private Vector3 camForward;
    private Vector3 camRight;
    private Vector3 movePLayer;
    
    Charview view;
    public MenuManager menumanagerscript;

    public CharacterController player;
    public float playerspeed;
    public int _maxhealth = 30;
    public int vigorPoints = 40;
    public float gravity = 9.8f;

    public float _currenthealth;

    public string nombreEscenaACargar;
    public string nombreEscenaACargar2;



    private void Awake()
    {
        view = GetComponent<Charview>();
    }
    private void Start()
    {
        player = GetComponent<CharacterController>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            menumanagerscript.Restartscene();
        }

        horizonalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        //PlayerDies();
        playerInput = new Vector3(horizonalMove, 0, verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput, 1);

        camDirection();

        movePLayer = playerInput.x * camRight + playerInput.z * camForward;

        player.transform.LookAt(player.transform.position + movePLayer);

        setGravity();

        player.Move(movePLayer * playerspeed * Time.deltaTime);

        if (movePLayer.magnitude > 0.3f)
        {
            view.Isrunning(true);
        }
        else
        {
            view.Isrunning(false);
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ObjetoColisionable"))
        {
            SceneManager.LoadScene(nombreEscenaACargar);
            Cursor.lockState = CursorLockMode.Confined;
        }
        if (other.CompareTag("ObjetoColisionable2"))
        {
            SceneManager.LoadScene(nombreEscenaACargar2);
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    void camDirection()
    {
        camForward = mainCamera.transform.forward;
        camRight = mainCamera.transform.right;

        camForward.y = 0;
        camRight.y = 0;

        camForward = camForward.normalized;
        camRight = camRight.normalized;
    }
    void setGravity()
    {
        movePLayer.y = -gravity * Time.deltaTime;

    }
   

}
