using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2 - Santiago Andres Sanchez Barrio

public class ReverseFan : MonoBehaviour
{
    [SerializeField] private float absortionStrength = 10f;
    [SerializeField] private float absortionLength = 5f;
    [SerializeField] private LayerMask playerLayer;
    private Color gizmoColor = Color.yellow;

    private void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position + transform.right * absortionLength / 2f, new Vector3(absortionLength, 2f, 2f) / 2f, transform.rotation, playerLayer);

        foreach (Collider collider in colliders)
        {
            // Calcular la dirección del jugador hacia el cubo
            Vector3 direccion = transform.position - collider.transform.position;

            // Aplicar fuerza hacia el cubo
            Rigidbody rb = collider.attachedRigidbody;
            if (rb != null)
            {
                direccion.y = 0f; // Evitar que el jugador levite
                rb.AddForce(direccion.normalized * absortionStrength, ForceMode.Acceleration);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireCube(transform.position + transform.right * absortionLength / 2f, new Vector3(absortionLength, 2f, 2f));
    }
}
