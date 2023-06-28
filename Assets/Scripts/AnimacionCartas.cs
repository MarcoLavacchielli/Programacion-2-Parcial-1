using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class AnimacionCartas : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 initialScale;

    public Image MySprite;
   
    public Combat combatScript;
    public Button MyButton;

    void Start()
    {
        MySprite.gameObject.SetActive(false);
       

        initialScale = transform.localScale; 
    }
    private void Update()
    {
       
        if (MyButton.interactable == false)
        {
            MySprite.GetComponent<Image>().gameObject.SetActive(false);
        }
        else if (MyButton.interactable == true)
        {
            MySprite.GetComponent<Image>().gameObject.SetActive(true);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
       

        LeanTween.scale(gameObject, initialScale * 1.2f, 0.2f);

       
        
        MySprite.transform.position = transform.position;
        

        if (MyButton.interactable == false)
        {
            MySprite.GetComponent<Image>().gameObject.SetActive(false);
        }
        else if(MyButton.interactable == true)
        {
            MySprite.GetComponent<Image>().gameObject.SetActive(true);
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       
        LeanTween.scale(gameObject, initialScale, 0.2f);

        MySprite.gameObject.SetActive(false);
      
    }
}
