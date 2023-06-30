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
    public inventoryObjectsActions InvObjActionsScript;
    public Combat combatScript;
    public int myslot;
    public int thevigorCostOfMyCard;



    public string NombredelaCartadeVigoryEjecutarPasiva;
    public Player player;
    public StadisticPlayer stadisticplayerScipt;


    public Enemy enemyy;

    public AudioSource MyAudioSource;
    public AudioClip WarriorPendantAudio;
    public AudioClip DeadEyeAudio;
    public AudioClip CaosAudio;
    public AudioClip arrowhit;
    public AudioClip magicSuntemple;
    public AudioClip magicCircle;
    public AudioClip windowFixing;
    public AudioClip claps;
    public AudioClip healUp;
    public AudioClip iceMagic;
    public AudioClip remorseFemale;

    public AudioClip[] audiosVigorArray;

    public Image notUsable;

    public inventoryObjectsActions inventoryObjectsScript;

    public void PlayAudio(AudioClip AC)
    {
        MyAudioSource.clip = AC;
        MyAudioSource.Play();
    }
    private void Start()
    {

        nametext.text = card.name;
        descriptiontext.text = card.description;
        image.sprite = card.image;

        vigortext.text = card.vigorcost.ToString();
        thevigorCostOfMyCard = card.vigorcost;

    }

    public void Update()
    {
        if (actualizarinformacióncostedeVigor() > stadisticplayerScipt.vigor)
        {
            notUsable.gameObject.SetActive(true);
        }
        else
        {
            notUsable.gameObject.SetActive(false);
        }
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
                
                inventoryObjectsScript.HealthPotionParticles.Play();
                stadisticplayerScipt.health += 8;
                protectiontottempasive();
                PlayAudio(WarriorPendantAudio);
                Debug.Log("You healed 8 points of health");
                break;
            case "Senpukku":
                combatScript.damageparticleSlot17.Play();
                combatScript.damageparticleSlot17Combate2.Play();
                combatScript.damageparticleSlot17_Combate3.Play();
                combatScript.damageparticleSlot17_Combate4.Play();
                
                protectiontottempasive();
                enemyy.health -= 4;
                PlayAudio(arrowhit);
                if (stadisticplayerScipt.health <= 20)
                {
                    enemyy.health -= 3;
                }
                Debug.Log("You have done a senpuku to yourself");
                break;
            case "Sacrifice":
                combatScript.damageparticleSlot18.Play();
                combatScript.damageparticleSlot18Combate2.Play();
                combatScript.damageparticleSlot18_Combate3.Play();
                combatScript.damageparticleSlot18_Combate4.Play();
                enemyy.health -= 12;
                PlayAudio(magicSuntemple);
                protectiontottempasive();
                stadisticplayerScipt.health -= 3;
                Debug.Log("You just damage yourself to deal more to the enemy");
                break;
            case "Spirit Growth":
                combatScript.damageparticleSlot19.Play();
                combatScript.damageparticleSlot19Combate2.Play();
                combatScript.damageparticleSlot19_Combate3.Play();
                combatScript.damageparticleSlot19_Combate4.Play();
                stadisticplayerScipt.SpiritGrowthStacks += 1;
                PlayAudio(magicCircle);
                enemyy.health -= 1;
                protectiontottempasive();
                if (stadisticplayerScipt.SpiritGrowthStacks >= 3)
                {
                    enemyy.health -= 4;
                    Debug.Log("You have done 5 points of damage with spirit growth");
                }
                break;
            case "Unbreakable":
                combatScript.damageparticleSlot20.Play();
                combatScript.damageparticleSlot20Combate2.Play();
                combatScript.damageparticleSlot20_Combate3.Play();
                combatScript.damageparticleSlot20_Combate4.Play();
                PlayAudio(windowFixing);
                stadisticplayerScipt.vigor += 5;
                protectiontottempasive();
                Debug.Log("You have increase your vigor in 5 points");
                break;
            case "Protection Tottem":
               
                stadisticplayerScipt.health += 1;
                //inventoryObjectsScript.HealthPotionParticles.Play();
                protectiontottempasive();
                Debug.Log("You have healed 1 point of health");
                stadisticplayerScipt.ProtectionTottemStacks += 1;
                if (stadisticplayerScipt.ProtectionTottemStacks == 5)
                {
                    PlayAudio(remorseFemale);
                    Debug.Log("Protection tottem got activated");
                }
                else
                {
                    PlayAudio(claps);

                }
                break;
            case "Caos":
                combatScript.damageparticleSlot22.Play();
                combatScript.damageparticleSlot22Combate2.Play();
                combatScript.damageparticleSlot22_Combate3.Play();
                combatScript.damageparticleSlot22_Combate4.Play();
                enemyy.health -= 9;
                protectiontottempasive();
                PlayAudio(CaosAudio);
                Debug.Log("You have done 9 points of damage to your enemy");
                
                break;
            case "Dead eye":
                combatScript.damageparticleSlot23.Play();
                combatScript.damageparticleSlot23Combate2.Play();
                combatScript.damageparticleSlot23_Combate3.Play();
                combatScript.damageparticleSlot23_Combate4.Play();
                enemyy.health -= 7;
                inventoryObjectsScript.HealthPotionParticles.Play();
                stadisticplayerScipt.health += 3;
                protectiontottempasive();
                PlayAudio(DeadEyeAudio);
                Debug.Log("You have done 7 points of damage and healed yourself in 3 points");
               
                break;
            case "Prominence burn":
                combatScript.damageparticleSlot24.Play();
                combatScript.damageparticleSlot24Combate2.Play();
                combatScript.damageparticleSlot24_Combate3.Play();
                combatScript.damageparticleSlot24_Combate4.Play();
                enemyy.health -= 3;
                inventoryObjectsScript.HealthPotionParticles.Play();
                PlayAudio(healUp);
                stadisticplayerScipt.health += 3;
                protectiontottempasive();
                Debug.Log("You have done 3 points of damage and healed yourself in 3 points");
               
                break;
            case "Absolution":
                combatScript.damageparticleSlot25.Play();
                combatScript.damageparticleSlot25Combate2.Play();
                combatScript.damageparticleSlot25_Combate3.Play();
                combatScript.damageparticleSlot25_Combate4.Play();
                enemyy.health -= 6;
                PlayAudio(iceMagic);
                stadisticplayerScipt.health += 4;
                protectiontottempasive();
                Debug.Log("You have done 6 points of damage and healed yourself in 4 points");
                
                break;
            case "Uncontrolled pride":
                combatScript.damageparticleSlot26.Play();
                combatScript.damageparticleSlot26Combate2.Play();
                combatScript.damageparticleSlot26_Combate3.Play();
                combatScript.damageparticleSlot26_Combate4.Play();
                enemyy.health -= 5;
                PlayAudio(CaosAudio);
                Debug.Log("You have done 7 points of damage");
                protectiontottempasive();
                
                break;

            case "absortion":
                combatScript.damageparticleSlot27.Play();
                combatScript.damageparticleSlot27Combate2.Play();
                combatScript.damageparticleSlot27_Combate3.Play();
                combatScript.damageparticleSlot27_Combate4.Play();
                PlayAudio(audiosVigorArray[0]);
                protectiontottempasive();
                if (stadisticplayerScipt.vigor <= 3)
                {
                    stadisticplayerScipt.vigor = 7;
                    Debug.Log("You have increase your vigor in 7 points");
                }
                break;
            case "Balance of Death":
                combatScript.damageparticleSlot28.Play();
                protectiontottempasive();
                combatScript.damageparticleSlot28Combate2.Play();
                combatScript.damageparticleSlot28_Combate3.Play();
                combatScript.damageparticleSlot28_Combate4.Play();
                PlayAudio(audiosVigorArray[1]);
                int i = enemyy.health - stadisticplayerScipt.health;
                if (i < 0)
                {
                    i*= -1;
                    enemyy.health -= i;
                }
                else
                {
                    enemyy.health -= i;
                }
                Debug.Log("You have done the difference of health between you and your oponent as damage");
                break;
            case "Balance of Life":
                
                protectiontottempasive();
                
                PlayAudio(audiosVigorArray[2]);
                int u = enemyy.health - stadisticplayerScipt.health;
                if (u < 0)
                {
                    u *= -1;
                    stadisticplayerScipt.health += u;
                    inventoryObjectsScript.HealthPotionParticles.Play();
                }
                else
                {
                    stadisticplayerScipt.health += u;
                }
                Debug.Log("You have healed yourself the difference of health between you and your oponent");
                break;

            case "Blood Drainer":
                combatScript.damageparticleSlot30.Play();
                combatScript.damageparticleSlot30Combate2.Play();
                protectiontottempasive();
                combatScript.damageparticleSlot30_Combate3.Play();
                combatScript.damageparticleSlot30_Combate4.Play();
                enemyy.health -= 4;
                Debug.Log("You have done 4 points of damage");
                stadisticplayerScipt.bloodDrainerCounter += 1;
                PlayAudio(audiosVigorArray[3]);

                if (stadisticplayerScipt.bloodDrainerCounter == 3)
                {
                    InvObjActionsScript.HealthPotions += 1;
                    stadisticplayerScipt.bloodDrainerCounter = 0;
                    Debug.Log("You got a health potion");
                }
                break;
            case "Death Reaper":
                combatScript.damageparticleSlot31.Play();
                combatScript.damageparticleSlot31Combate2.Play();
                protectiontottempasive();
                combatScript.damageparticleSlot31_Combate3.Play();
                combatScript.damageparticleSlot31_Combate4.Play();
                PlayAudio(audiosVigorArray[4]);
                stadisticplayerScipt.vigor += 7;
                Debug.Log("You have increase your vigor in 7 points");
                if (stadisticplayerScipt.health <= 15)
                {
                    enemyy.health = 0;
                    Debug.Log("You have execute your oponent");
                }
                break;
            case "Devil Eyes":
               
                protectiontottempasive();
                PlayAudio(audiosVigorArray[5]);
                
                inventoryObjectsScript.HealthPotionParticles.Play();
                stadisticplayerScipt.health += combatScript.devilEyesPassive;
                Debug.Log("You have damage your enemy with"+combatScript.devilEyesPassive+" points of damage");
                break;
            case "Evil Pendant":
                
                protectiontottempasive();
                PlayAudio(audiosVigorArray[6]);
                
                inventoryObjectsScript.HealthPotionParticles.Play();
                stadisticplayerScipt.health += 7;
                stadisticplayerScipt.vigor += 6;
                Debug.Log("You have increase your vigor in 6 points and you healed yourself in 7 points");
                break;
            case "Souls Strike":
                combatScript.damageparticleSlot34.Play();
                combatScript.damageparticleSlot34Combate2.Play();
                protectiontottempasive();
                combatScript.damageparticleSlot34_Combate3.Play();
                combatScript.damageparticleSlot34_Combate4.Play();
                PlayAudio(audiosVigorArray[7]);
                enemyy.health -= 5;
                Debug.Log("You have done 5 points of damage to your oponent");
                if (stadisticplayerScipt.health < stadisticplayerScipt.vigor)
                {
                    enemyy.health = 0;
                    Debug.Log("You have execute your oponent");
                }
                break;
            case "Thanatos":
                combatScript.damageparticleSlot35.Play();
                PlayAudio(audiosVigorArray[8]);
                combatScript.damageparticleSlot35Combate2.Play();
                protectiontottempasive();
                combatScript.damageparticleSlot35_Combate3.Play();
                combatScript.damageparticleSlot35_Combate4.Play();
                enemyy.health -= 5;
                Debug.Log("You have done 5 points of damage to your oponent");
                if (stadisticplayerScipt.health <= 15)
                {
                    stadisticplayerScipt.vigor += 15;
                    Debug.Log("You have increase your vigor in 15 points");
                }
                break;
                




        }


    }
    public void protectiontottempasive()
    {
        if (stadisticplayerScipt.ProtectionTottemStacks >= 5)
        {
            inventoryObjectsScript.HealthPotionParticles.Play();
            stadisticplayerScipt.health += 1;
        }

    }
}
