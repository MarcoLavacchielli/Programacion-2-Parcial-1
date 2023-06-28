using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class VigorDeck : MonoBehaviour
{
    public VigorCards[] _deck;
    private int availableCardSlots = 3;
    public VigorCardsDisplay Slot4;
    public VigorCardsDisplay Slot5;
    public VigorCardsDisplay Slot6;
    public bool SlotBool4 = false;
    public bool SlotBool5 = false;
    public bool SlotBool6 = false;
    public VigorCards[] DeckOfTheVigorDeck;
    public bool[] EquipOrUnequipTheCardBool;
    public List<VigorCards> TrueVigorDeckInCombat = new List<VigorCards>();
   

    private void Awake()
    {
        _deck = Resources.FindObjectsOfTypeAll<VigorCards>();

        //DeckOfTheDeck.CopyTo(_deck, 0);
        //DeckOfTheVigorDeck[2] = _deck[2];
        //_deck.CopyTo(DeckOfTheVigorDeck, browser);
        //DeckOfTheVigorDeck[browser] = _deck[browser];
        //cardsondeck = EquipOrUnequipTheCardBool.Count
    }
    public void CreateListOfMyVigorCardsBuildForCombat()
    {
        foreach (VigorCards objeto in DeckOfTheVigorDeck)
        {
            if (objeto != null)
            {
                TrueVigorDeckInCombat.Add(objeto);
            }
        }
    }

    public void BuildMyVigorDeck(VigorCards browser, int ThePlaceInArray)
    {
        //DeckOfTheVigorDeck[ThePlaceInArray] = browser;
        //DeckOfTheVigorDeck[ThePlaceInArray] = null;
        if (EquipOrUnequipTheCardBool[ThePlaceInArray]==false)
        {
            DeckOfTheVigorDeck[ThePlaceInArray] = browser;
            EquipOrUnequipTheCardBool[ThePlaceInArray] = true;
        }
        else if(EquipOrUnequipTheCardBool[ThePlaceInArray] == true)
        {
            DeckOfTheVigorDeck[ThePlaceInArray] = null;
            EquipOrUnequipTheCardBool[ThePlaceInArray] = false;
        }
    }

    public int PermissionToLeaveTheInventoryMinimumVigorDeckCards(VigorCards[] deckOfTheVigorDeck)
    {
        int contadorNoNulos = 0;
        foreach (VigorCards objeto in deckOfTheVigorDeck)
        {
            if (objeto != null)
            {
                contadorNoNulos++;
            }
        }
        return contadorNoNulos;
    }

    public void DrawCards()
    {
        if (TrueVigorDeckInCombat.Count >= 1)
        {
            for (int i = 0; i <= availableCardSlots; i++)
            {
                VigorCards randomCard = TrueVigorDeckInCombat[Random.Range(0, TrueVigorDeckInCombat.Count)];
                if (i == 0 && SlotBool4 == false)
                {
                    Slot4.card = randomCard;
                    Slot4.actualizarinfodeUIdeCadaCarta();
                    
                    SlotBool4 = true;

                    
                }
                else if (i == 1 && SlotBool5 == false)
                {
                    Slot5.card = randomCard;
                    Slot5.actualizarinfodeUIdeCadaCarta();
                   
                    SlotBool5 = true;

                   
                }
                else if (i == 2 && SlotBool6 == false)
                {
                    Slot6.card = randomCard;
                    Slot6.actualizarinfodeUIdeCadaCarta();
                    
                    SlotBool6 = true;

                    
                }

            }

        }


    }
}
