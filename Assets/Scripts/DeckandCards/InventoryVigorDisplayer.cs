using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryVigorDisplayer : MonoBehaviour
{
    public VigorCards card;
    public Text nametext;
    public Text descriptiontext;
    public Image image;
    public int MyPlaceOnTheVigorArray;
    public Text vigortext;
    public VigorDeck VigorDeckScript;
    public bool VigorCardEquipedEffectBool;
    public Image EquipedEffectVigor;


    private void Awake()
    {
        ActualizationData();
    }

    private void Start()
    {
        ActualizationData();
    }
    private void Update()
    {
        ActualizationData();
    }
    public void ActualizationData()
    {
        nametext.text = card.name;
        descriptiontext.text = card.description;
        image.sprite = card.image;
        vigortext.text = card.vigorcost.ToString();
    }
    public void CardEffectFunction()
    {
        VigorCardEquipedEffectBool = !VigorCardEquipedEffectBool;
        EquipedEffectVigor.gameObject.SetActive(VigorCardEquipedEffectBool);
    }
    public void AddCardToMyVigorDeck()
    {
        VigorDeckScript.BuildMyVigorDeck(card, MyPlaceOnTheVigorArray);
        CardEffectFunction();
    }

}
