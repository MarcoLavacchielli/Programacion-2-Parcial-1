using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escalera : MonoBehaviour
{
    public float ladderSpeed = 3.0f; // La velocidad a la que sube o baja el jugador por la escalera
    public Transform ladderTop; // La posición en la parte superior de la escalera
    public Transform ladderBottom; // La posición en la parte inferior de la escalera

    private bool isClimbing = false; // Indica si el jugador está subiendo o bajando por la escalera
    private GameObject player; // Referencia al objeto del jugador
    private Rigidbody playerRigidbody; // Referencia al Rigidbody del jugador
    private Vector3 lastPosition; // Última posición conocida del jugador en la escalera

    private void Start()
    {
        // Obtiene la referencia al Rigidbody del jugador
        playerRigidbody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        // Comprueba si el jugador está en contacto con la escalera
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2f, Quaternion.identity);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                player = collider.gameObject; // Obtiene la referencia al objeto del jugador
                isClimbing = true;
                playerRigidbody.useGravity = false; // Desactiva la gravedad del jugador para que no se caiga mientras está en la escalera
                break;
            }
        }

        // Si el jugador está subiendo o bajando por la escalera
        if (isClimbing && player != null)
        {
            float verticalInput = Input.GetAxisRaw("Vertical");

            if (verticalInput != 0)
            {
                lastPosition = player.transform.position; // Actualiza la última posición conocida del jugador en la escalera

                Vector3 newPosition = lastPosition;
                Vector3 movement = new Vector3(0, verticalInput * ladderSpeed * Time.deltaTime, 0);
                newPosition = player.transform.position + movement;
                newPosition.x = ladderBottom.position.x;
                newPosition.z = ladderBottom.position.z;
                // Limita la posición del jugador a la escalera
                if (newPosition.y > ladderTop.position.y)
                {
                    newPosition.y = ladderTop.position.y;
                }
                else if (newPosition.y < ladderBottom.position.y)
                {
                    newPosition.y = ladderBottom.position.y;
                }

                // Actualiza la posición del jugador utilizando el Rigidbody
                playerRigidbody.MovePosition(newPosition);

                // Si el jugador llega a la parte superior o inferior de la escalera, desactiva el modo escalera
                if (newPosition.y == ladderTop.position.y || newPosition.y == ladderBottom.position.y)
                {
                    isClimbing = false;
                    playerRigidbody.useGravity = true; // Reactiva la gravedad del jugador sólo si está en el aire
                }
            }
            else if (lastPosition != Vector3.zero && player.transform.position != lastPosition && Input.GetAxisRaw("Vertical") == 0)
            {
                // Si el jugador no se mueve y ha dejado una última posición conocida, y no hay entrada vertical, el jugador no se mueve
                playerRigidbody.MovePosition(lastPosition);
            }
        }
        else
        {
            // Si el jugador no está en contacto con la
            isClimbing = false;
            player = null;
            lastPosition = Vector3.zero;
        }
    }
}

