using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TP2 - Santiago Andres Sanchez Barrio

public class FragilePlatform : MonoBehaviour
{
    private float timeBetweenStates = 5f;
    [SerializeField] private Collider platformCollider;
    [SerializeField] private Material activeMaterial;
    [SerializeField] private Material inactiveMaterial;
    [SerializeField] private GameObject activeModel;
    [SerializeField] private GameObject inactiveModel;
    [SerializeField] private float shakeMagnitude = 0.07f;
    [SerializeField] private float shakeDuration = 2f;
    [SerializeField] private ParticleSystem dustShake;

    private bool isActive = true;
    private Renderer platformRenderer;

    private void Start()
    {
        platformRenderer = GetComponent<Renderer>();

        // Iniciar la corrutina que cambia el estado de la plataforma
        StartCoroutine(ChangePlatformState());
    }

    private IEnumerator ChangePlatformState()
    {
        while (true)
        {
            if (!isActive)
            {
                yield return new WaitForSeconds(timeBetweenStates);
            }

            // Cambiar el estado de la plataforma
            isActive = true;

            // Actualizar el material y el modelo activo
            platformRenderer.material = activeMaterial;
            activeModel.SetActive(true);

            // Desactivar el modelo inactivo
            inactiveModel.SetActive(false);

            // Actualizar el box collider de la plataforma
            platformCollider.enabled = true;

            // Esperar a que el jugador salga de la plataforma
            while (isActive)
            {
                yield return null;
            }

            // Hacer que la plataforma tiemble
            StartCoroutine(ShakePlatform());

            // Desactivar la plataforma y cambiar el material y modelo
            yield return new WaitForSeconds(shakeDuration);
            platformCollider.enabled = false;
            platformRenderer.material = inactiveMaterial;
            activeModel.SetActive(false);
            inactiveModel.SetActive(true);

            yield return new WaitForSeconds(timeBetweenStates - shakeDuration);

            // Cambiar el estado de la plataforma
            isActive = true;
        }
    }

    private IEnumerator ShakePlatform()
    {
        float elapsedTime = 0f;
        Vector3 originalPosition = transform.position;

        while (elapsedTime < shakeDuration)
        {
            dustShake.Play();
            // Calcular la posición de la plataforma en cada fotograma
            Vector3 newPosition = originalPosition + Random.insideUnitSphere * shakeMagnitude;

            // Actualizar la posición de la plataforma
            transform.position = newPosition;

            // Esperar al siguiente fotograma
            yield return null;

            elapsedTime += Time.deltaTime;
        }

        // Volver la plataforma a su posición original
        transform.position = originalPosition;
        dustShake.Stop();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && isActive)
        {
            dustShake.Play();
            StartCoroutine(ShakePlatform());
            // La plataforma se mantendrá activa durante 2 segundos después de que el jugador colisione con ella
            StartCoroutine(DeactivatePlatform());
        }
    }

    private IEnumerator DeactivatePlatform()
    {
        yield return new WaitForSeconds(2f);
        dustShake.Stop();
        isActive = false;
    }
}
