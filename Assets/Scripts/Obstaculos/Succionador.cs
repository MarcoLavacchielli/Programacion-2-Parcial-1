using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Succionador : MonoBehaviour
{
    public float fuerzaAbsorcion = 10f;
    public float rangoAbsorcion = 5f;
    public LayerMask jugadorLayer;
    public Color gizmoColor = Color.yellow;

    private void FixedUpdate()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position + transform.right * rangoAbsorcion / 2f, new Vector3(rangoAbsorcion, 2f, 2f) / 2f, transform.rotation, jugadorLayer);

        foreach (Collider collider in colliders)
        {
            // Calcular la dirección del jugador hacia el cubo
            Vector3 direccion = transform.position - collider.transform.position;

            // Mover al jugador en la dirección del ventilador
            CharacterController controller = collider.GetComponent<CharacterController>();
            if (controller != null)
            {
                direccion.y = 0f; // Evitar que el jugador levite
                controller.Move(direccion.normalized * fuerzaAbsorcion * Time.fixedDeltaTime);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = gizmoColor;
        Gizmos.DrawWireCube(transform.position + transform.right * rangoAbsorcion / 2f, new Vector3(rangoAbsorcion, 2f, 2f));
    }
}
