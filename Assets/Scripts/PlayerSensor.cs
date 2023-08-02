using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;

public class PlayerSensor : MonoBehaviour
{
    [SerializeField] UnityEvent EV_OnPlayerEnter;
    [SerializeField] UnityEvent EV_OnPlayerExit;

    public float DoorContador;
    public CinemachineVirtualCamera DoorCamera;
    public Player player;
    public Collider playerColl;
    public Rigidbody playerRB;
    public List<CinemachineVirtualCamera> CamarasDoor;
    public CinemachineVirtualCamera ActiveCamera;
    public MyCamera mycamera;

    public Light keyLight;

    public ParticleSystem particleKey;

    private void OnTriggerEnter(Collider other)
    {
        print("Found a <color=yellow>key</color>.");
        if (IsPlayer(other))
        {
            SwitchCameraDoor(CamarasDoor[1]);
            player.enabled = false;
            mycamera.canMoveCamera = false;
            playerRB.constraints = RigidbodyConstraints.FreezeAll;
            EV_OnPlayerEnter.Invoke();
            playerColl.enabled = false;
            keyLight.enabled = false;
            particleKey.Stop();
            StartCoroutine(CameraTransation());
        }
    }

    
   
    public void SwitchCameraDoor(CinemachineVirtualCamera Door)
    {
        Door.Priority = 10;
        ActiveCamera = Door;

        foreach (CinemachineVirtualCamera c in CamarasDoor)
        {
            if (c != Door && c.Priority != 0)
            {
                c.Priority = 0;
            }
        }


    }
    bool IsPlayer(Collider col)
    {
        Player c = col.GetComponent<Player>();
        if (c == GameManager.instance.Player())
        {
            return true;
        }
        return false;
    }

    IEnumerator CameraTransation()
    {
        yield return new WaitForSeconds(DoorContador);

        transition();
        Invoke("Playerenabled", 2.5f);

        yield return null;
    }

    void transition()
    {
        SwitchCameraDoor(CamarasDoor[0]);
        EV_OnPlayerExit.Invoke();

    }
    void Playerenabled()
    {
        player.enabled = true;
        playerRB.constraints = RigidbodyConstraints.None;
        playerRB.constraints = RigidbodyConstraints.FreezeRotation;
        mycamera.canMoveCamera = true;

    }
}
