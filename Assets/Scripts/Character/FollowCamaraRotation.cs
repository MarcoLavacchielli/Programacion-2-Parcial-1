using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2 - Santiago Andres Sanchez Barrio

public class FollowCamaraRotation : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform target;

    private void Update()
    {
        Quaternion camRotation = mainCamera.transform.rotation;
        target.rotation = camRotation;
    }
}
