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
        // Cuando el puntero entra en el bot�n, agranda el bot�n
        button.transform.localScale = originalScale * 1.2f; // Puedes ajustar el factor de agrandamiento aqu�
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Cuando el puntero sale del bot�n, restaura el tama�o original
        button.transform.localScale = originalScale;
    }

    
   
}

