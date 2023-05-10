using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VigorCardsDisplay : MonoBehaviour
{
    public VigorCards card;
    public Text nametext;
    public Text descriptiontext;
    public Image image;

    public Text vigortext;
    public VigorDeck vigorscriptdeck;
    public int myslot;
    public int thevigorCostOfMyCard;

    public string NombredelaCartadeVigoryEjecutarPasiva;
    public Player player;
    public StadisticPlayer stadisticplayerScipt;
    private int SpiritGrowthStacks;
    private int ProtectionTottemStacks;

    public Enemy enemyy;

    private void Start()
    {

        nametext.text = card.name;
        descriptiontext.text = card.description;
        image.sprite = card.image;

        vigortext.text = card.vigorcost.ToString();
        thevigorCostOfMyCard = card.vigorcost;

    }
    public void setenemy(Enemy enemy)
    {
        enemyy = enemy;
    }
    public void actualizarinfodeUIdeCadaCarta()
    {
        nametext.text = card.name;
        descriptiontext.text = card.description;
        image.sprite = card.image;

        vigortext.text = card.vigorcost.ToString();
    }
    public int actualizarinformacióncostedeVigor()
    {
        thevigorCostOfMyCard = card.vigorcost;
        return (thevigorCostOfMyCard);
    }
    public void ejecutarpasivadelacartadevigor()
    {
        NombredelaCartadeVigoryEjecutarPasiva = card.name;
        
        switch (NombredelaCartadeVigoryEjecutarPasiva)
        {
            case "Warrior Pendant":
                stadisticplayerScipt.health += 5;
                protectiontottempasive();
                Debug.Log("te has curado 5 puntos de salud");
                break;
            case "Senpukku":

                protectiontottempasive();
                if (stadisticplayerScipt.health <= 5)
                {
                    enemyy.health -= 7;
                }
                Debug.Log("has cometido Senpukku");
                break;
            case "Sacrifice":

                enemyy.health -= 12;
                protectiontottempasive();
                stadisticplayerScipt.health -= 7;
                Debug.Log("te has inflingido daño pero mucho mas al enemigo");
                break;
            case "Spirit Growth":

                SpiritGrowthStacks += 1;
                protectiontottempasive();
                if (SpiritGrowthStacks >= 7)
                {
                    enemyy.health -= 8;
                    Debug.Log("has inflingido 8 de daño con Spirit Growth");
                }
                break;
            case "Unbreakable":
                stadisticplayerScipt.vigor += 3;
                protectiontottempasive();
                Debug.Log("te has aumentado 3 puntos de vigor");
                break;
            case "Protection Tottem":
                stadisticplayerScipt.health += 1;
                protectiontottempasive();
                Debug.Log("te has curado 1 puntos de salud");
                ProtectionTottemStacks += 1;
                if (ProtectionTottemStacks >= 5)
                {
                    Debug.Log("el tottem de proteccción ya está activado");
                }
                break;
        }

    }
        public void protectiontottempasive()
        {
            if (ProtectionTottemStacks >= 5)
            {
                stadisticplayerScipt.health += 1;
            }

        }
}
