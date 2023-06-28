using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    public GameManager myGM;
    private bool isInventoryActive = false;
    private bool isMenuActive = false;
    private bool isControlsActive = false;
    private Vector3 initialScale;
    public Deck DeckScript;
    public VigorDeck VigorDeckScript;
    public MyCamera camerascript;

    public AudioClip MyEffectAudio;
    public AudioSource MyAudioSource;
    public TextMeshProUGUI NotAppropiateDeckWarningText;
    [SerializeField]
    private CombatPosition CombatPositionScript;
    [SerializeField]
    private Image InventoryBlockerImage;
    [SerializeField]
    private InventoryDisplayer[] ArrayOfInventoryDisplayer;
    private int Counter;

    [SerializeField]
    private GameObject OptionsMenu;

    [SerializeField]
    private GameObject firstPageOfInventory;

    [SerializeField]
    private GameObject secondPageOfInventory;
    [SerializeField]
    private Button switchPagesInventory;

    private bool boolForPages=false;
    public void PlayAudio(AudioClip AC)
    {
        MyAudioSource.clip = AC;
        MyAudioSource.Play();
    }
    public void DataInventoryFixer()
    {
        for (Counter = 0; Counter <= 7; Counter++)
        {
            ArrayOfInventoryDisplayer[Counter].ActualizationData();
        }
    }
    private void Update()
    {
        EffectAudioPlayer();

        if (CombatPositionScript.battlePosition == true)
        {
            InventoryBlockerImage.gameObject.SetActive(true);
        }
        else
        {
            InventoryBlockerImage.gameObject.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            DataInventoryFixer();
            if (!isMenuActive)
                ToggleInventory();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isInventoryActive)
                ToggleInventory();
            if (isMenuActive)
                ToggleMenu();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isInventoryActive)
                ToggleMenu();
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isMenuActive)
                ToggleMenu();
        }
    }
    public void ToggleInventory()
    {
        int deckCardsCount = DeckScript.PermissionToLeaveTheInventoryMinimumDeckCards(DeckScript.DeckOfTheDeck);
        int vigorCardsCount = VigorDeckScript.PermissionToLeaveTheInventoryMinimumVigorDeckCards(VigorDeckScript.DeckOfTheVigorDeck);
        if (deckCardsCount < 4 || deckCardsCount > 6 || vigorCardsCount < 5 || vigorCardsCount > 8)
        {
            NotAppropiateDeckWarningText.gameObject.SetActive(true);
        }
        else
        {
            NotAppropiateDeckWarningText.gameObject.SetActive(false);
        }
        if (!isInventoryActive)
        {
            isInventoryActive = true;
            myGM.Activeinventory();
            Cursor.lockState = CursorLockMode.Confined;
            camerascript.enabled = false;
        }
        else if (isInventoryActive && deckCardsCount >= 4 && deckCardsCount <= 6 && vigorCardsCount >= 5 && vigorCardsCount <= 8)
        {
            isInventoryActive = false;
            myGM.DesactivateInventory();
            Cursor.lockState = CursorLockMode.Locked;
            camerascript.enabled = true;
        }
    }

    public void ToggleInventoryPage()
    {
        boolForPages = !boolForPages;
        
        if (boolForPages == false)
        {
            firstPageOfInventory.gameObject.SetActive(true);
            secondPageOfInventory.gameObject.SetActive(false);
        }
        else 
        {
            secondPageOfInventory.gameObject.SetActive(true);
            firstPageOfInventory.gameObject.SetActive(false);
        }
    }

    public void ToggleMenu()
    {
        isMenuActive = !isMenuActive;
        if (isMenuActive)
        {
            myGM.Menuactivate();
            Cursor.lockState = CursorLockMode.Confined;
            camerascript.enabled = false;
        }
        else
        {
            myGM.Menudesactivate();
            Cursor.lockState = CursorLockMode.Locked;
            camerascript.enabled = true;
        }
    }
    public void ToggleControls()
    {
        isControlsActive = !isControlsActive;
        if (isControlsActive)
        {
            myGM.Showcontrols();
        }
        else
        {
            myGM.Hidecontrols();
        }
    }

    public void EffectAudioPlayer()
    {

        if (OptionsMenu.activeSelf)
        {
            PlayAudio(MyEffectAudio);
        }
        else
        {
            MusicOFF();
        }
    }

    public void MusicON()
    {
        MyAudioSource.clip = MyEffectAudio;
        MyAudioSource.Play();
    }
    public void MusicOFF()
    {
        MyAudioSource.Stop();
    }
}