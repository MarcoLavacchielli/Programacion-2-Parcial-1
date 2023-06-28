using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;

public class CardsInventoryCounter : MonoBehaviour
{
    public Deck DeckScript;
    public int cardsonNormaldeck;
    private TextMeshProUGUI ContadorCartasNormalEnMazo;


    private void Start()
    {
        ContadorCartasNormalEnMazo = GetComponent<TextMeshProUGUI>();
    }
    public void VigorCardsOnDeckCounter()
    {
        cardsonNormaldeck = DeckScript.EquipOrUnequipTheNormalCardBool.Count(b => b);
    }
    private void Update()
    {
        VigorCardsOnDeckCounter();
        ContadorCartasNormalEnMazo.text = cardsonNormaldeck.ToString()+("/6");
    }
}
