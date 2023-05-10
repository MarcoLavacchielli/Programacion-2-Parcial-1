using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class CanvasPausa : MonoBehaviour
{
    //[SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject pauseMenuDesing;

    public static bool gamePause = false;
    public CombatPosition combat;

    private void Start()
    {
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePause)
            {
                resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        // cuando se pausa, el tiempo se detiene y se saca el boton
        gamePause = true;
        Time.timeScale = 0f;
        //pauseButton.SetActive(false);
        pauseMenuDesing.SetActive(true);

        //tambien se pausa la musica
        /*AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audios)
        {
            a.Pause();
        }*/

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void resume()
    {
        //si se saca la pausa, el tiempo vuelve a la normalidad y vuelve a aparecer el boton
        if (combat.battlePosition == true)
        {
            Cursor.visible = true;
        }
        else 
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
        gamePause = false;
        Time.timeScale = 1f;
        //pauseButton.SetActive(true);
        pauseMenuDesing.SetActive(false);

        //la musica se reanuda
        /*AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audios)
        {
            a.Play();
        }*/

        
    }

    public void restart()
    {
        //si se reinicia el tiempo vuelve a 1 porque si no el juego seguiria en pausa
        gamePause = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        foreach (AudioSource a in audios)
        {
            a.Play();
        }

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    //carga una escena especifica
    public void quit(string SceneName)
    {
        //Application.Quit();
        //Cursor.visible = true;
        SceneManager.LoadScene(SceneName);
    }
}
