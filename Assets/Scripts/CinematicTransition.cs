using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CinematicTransition : MonoBehaviour
{
    public Image[] storyImages;

    public CanvasGroup[] theStoryCanvasesForFade;

    public int theSpacesInTheArrays;

    public Button buttonForTransitions;

    public Player playerScript;

    public Image imageThatContainsStory;

    private bool boolImportant=true;
    //cuando entre a la main, sigo el ejempplo de card orange, creo una imagen, le meto un canvas group y si le pongo dialo que vaya adentro de la imagen como hijo
    // la funcion, cuando se termina el fade, se habilita el boton de nuevo

    private void Update()
    {
        if (theSpacesInTheArrays<3&&imageThatContainsStory.gameObject.activeInHierarchy==true&&boolImportant==true)
        {
            if (storyImages[0].enabled == true)
            {
                playerScript.enabled = false;
                Cursor.lockState = CursorLockMode.Confined;
            }
           
        }
    }

    public void PassStoryImage()
    {
        StartCoroutine(FadeOfCanvasStory());
        buttonForTransitions.enabled = false;

    }


    IEnumerator FadeOfCanvasStory()
    {
        float alpha = 1;

        while (alpha >= 0)
        {
            alpha -= 0.1f;
            yield return new WaitForEndOfFrame();
            theStoryCanvasesForFade[theSpacesInTheArrays].alpha = alpha;
        }
        storyImages[theSpacesInTheArrays].gameObject.SetActive(false);

        theStoryCanvasesForFade[theSpacesInTheArrays].alpha = 1;
        buttonForTransitions.enabled = true;
        theSpacesInTheArrays += 1;
        yield return null;
        if (theSpacesInTheArrays >= 3)
        {
            imageThatContainsStory.enabled = false;
            storyImages[0].enabled = false;
            playerScript.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            buttonForTransitions.enabled = false;
            buttonForTransitions.gameObject.SetActive(false);
            boolImportant = false;
        }
    }



}
