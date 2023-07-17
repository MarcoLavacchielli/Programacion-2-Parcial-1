using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionsButton : MonoBehaviour
{
    public GameObject[] PotionsCounters;
    private int indiceActual;

    private void Start()
    {
        // Inicializar el índice actual a cero
        indiceActual = 0;
        // Desactivar todas las imágenes excepto la primera
        for (int i = 1; i < PotionsCounters.Length; i++)
        {
            PotionsCounters[i].gameObject.SetActive(false);
        }
    }

    public void Alternar()
    {
        // Desactivar la imagen actual
        PotionsCounters[indiceActual].gameObject.SetActive(false);

        // Incrementar el índice actual
        indiceActual++;

        // Si el índice actual es mayor o igual al tamaño del arreglo, volver al inicio
        if (indiceActual >= PotionsCounters.Length)
        {
            indiceActual = 0;
        }

        // Activar la siguiente imagen
        PotionsCounters[indiceActual].gameObject.SetActive(true);
    }
}
