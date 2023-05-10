using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class AnimacionCartas : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 initialScale;

    public Image spriteSeleccionado;

    void Start()
    {
        spriteSeleccionado.gameObject.SetActive(false);
        initialScale = transform.localScale; 
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
        LeanTween.scale(gameObject, initialScale * 1.2f, 0.2f);
        spriteSeleccionado.gameObject.SetActive(true);

        spriteSeleccionado.transform.position = transform.position;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
        LeanTween.scale(gameObject, initialScale, 0.2f);
        spriteSeleccionado.gameObject.SetActive(false);
    }
}
