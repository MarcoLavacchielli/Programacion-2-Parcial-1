using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonHoverEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Button button;
    private Vector3 originalScale;

    private void Start()
    {
        button = GetComponent<Button>();
        originalScale = button.transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Cuando el puntero entra en el botón, agranda el botón
        button.transform.localScale = originalScale * 1.2f; // Puedes ajustar el factor de agrandamiento aquí
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Cuando el puntero sale del botón, restaura el tamaño original
        button.transform.localScale = originalScale;
    }

    
   
}

