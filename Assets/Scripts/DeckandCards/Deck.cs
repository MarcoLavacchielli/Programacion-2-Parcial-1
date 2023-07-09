using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Deck : MonoBehaviour
{
    public Card[] _deck;
    private int availableCardSlots = 3;
    public CardDisplay Slot1;
    public CardDisplay Slot2;
    public CardDisplay Slot3;
    public bool SlotBool1 = false;
    public bool SlotBool2 = false;
    public bool SlotBool3 = false;
    //public Card[] DeckDisplayerInventory;
    public Card[] DeckOfTheDeck;
    public bool[] EquipOrUnequipTheNormalCardBool;
    public List<Card> TrueDeckInCombat = new List<Card>();
    


    private void Awake()
    {
        _deck = Resources.FindObjectsOfTypeAll<Card>();
        
    }
    
    public void BuildMyDeck(Card browser, int ThePlaceInArray)
    {
        
        if (EquipOrUnequipTheNormalCardBool[ThePlaceInArray] == false)
        {
            DeckOfTheDeck[ThePlaceInArray] = browser;
            EquipOrUnequipTheNormalCardBool[ThePlaceInArray] = true;
        }
        else if (EquipOrUnequipTheNormalCardBool[ThePlaceInArray] == true)
        {
            DeckOfTheDeck[ThePlaceInArray] = null;
            EquipOrUnequipTheNormalCardBool[ThePlaceInArray] = false;
        }
    }
    public void CreateListOfMyrCardsBuildForCombat()
    {
        foreach (Card objeto in DeckOfTheDeck)
        {
            if (objeto != null)
            {
                TrueDeckInCombat.Add(objeto);
            }
        }
        TrueDeckInCombat.RemoveAll(item => item == null);
    }

    public void EmptyListOfMyCardsBuildForCombat()
    {
        for(int i = 0; i < TrueDeckInCombat.Count; i++)
        {
            TrueDeckInCombat[i] = null;
        }
    }

    public int PermissionToLeaveTheInventoryMinimumDeckCards(Card[] deckOfTheDeck)
    {
        int contadorNoNulos = 0;
        foreach (Card objeto in deckOfTheDeck)
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
        if (TrueDeckInCombat.Count >= 1)
        {
            for (int i = 0; i <= availableCardSlots; i++)
            {
                Card randomCard = TrueDeckInCombat[Random.Range(0, TrueDeckInCombat.Count)];
                if (i == 0 && SlotBool1 == false)
                {
                    Slot1.card = randomCard;
                    Slot1.actualizarinfodeUIdeCadaCarta();
                   // combatScript.NormalCardsAnimation.CrossFade("NormalCardNewAnimation", 0f);
                    SlotBool1 = true;
                }
                else if (i == 1 && SlotBool2 == false)
                {
                    Slot2.card = randomCard;
                    Slot2.actualizarinfodeUIdeCadaCarta();
                    //combatScript.NormalCardsAnimation.CrossFade("NormalcardNewAnimation2", 0f);
                    SlotBool2 = true;
                }
                else if (i == 2 && SlotBool3 == false)
                {
                    Slot3.card = randomCard;
                    Slot3.actualizarinfodeUIdeCadaCarta();
                    //combatScript.NormalCardsAnimation.CrossFade("NormalCardNewAnimation3", 0f);
                    SlotBool3 = true;
                }

            }

        }


    }
}
