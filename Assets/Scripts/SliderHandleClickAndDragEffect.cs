using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderHandleClickAndDragEffect : MonoBehaviour, IPointerClickHandler, IDragHandler, IEndDragHandler
{
    private Slider slider;
    private RectTransform handle;
    private Vector3 originalScale;
    public bool isDragging = false;

    private void Start()
    {
        slider = GetComponent<Slider>();
        handle = slider.handleRect;
        originalScale = handle.localScale;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        // Cuando se realiza un clic en el Handle, agranda el Handle
        handle.localScale = originalScale * 1.5f; 
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Se está arrastrando el Slider
        isDragging = true;
        handle.localScale = originalScale * 1.5f;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Se ha finalizado el arrastre del Slider
        isDragging = false;
        handle.localScale = originalScale;
    }
}






