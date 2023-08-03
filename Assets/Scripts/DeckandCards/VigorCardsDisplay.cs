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


    public void EmptySlot()
    {
        card = null;
        nametext = null;
        NombredelaCartadeVigoryEjecutarPasiva = null;
    }
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
                Debug.Log("You <color=green>healed 8 points of health</color>.");
                break;
            case "Senpukku":
                combatScript.damageparticleSlot17.Play();
                combatScript.damageparticleSlot17Combate2.Play();
                combatScript.damageparticleSlot17_Combate3.Play();
                combatScript.damageparticleSlot17_Combate4.Play();
                combatScript.combatUIAnimator.CrossFade("EnemyHearthAnimation", 0f);
                protectiontottempasive();
                enemyy.health -= 4;
                PlayAudio(arrowhit);
                if (stadisticplayerScipt.health <= 20)
                {
                    enemyy.health -= 3;
                }
                Debug.Log("You have done a <color=red>senpukku</color> to yourself.");
                break;
            case "Sacrifice":
                combatScript.damageparticleSlot18.Play();
                combatScript.damageparticleSlot18Combate2.Play();
                combatScript.damageparticleSlot18_Combate3.Play();
                combatScript.damageparticleSlot18_Combate4.Play();
                combatScript.combatUIAnimator.CrossFade("EnemyHearthAnimation", 0f);
                enemyy.health -= 12;
                PlayAudio(magicSuntemple);
                protectiontottempasive();
                stadisticplayerScipt.health -= 3;
                Debug.Log("You just <color=red>damage yourself</color> to deal more to the <color=red>enemy</color>.");
                break;
            case "Spirit Growth":
                combatScript.damageparticleSlot19.Play();
                combatScript.damageparticleSlot19Combate2.Play();
                combatScript.damageparticleSlot19_Combate3.Play();
                combatScript.damageparticleSlot19_Combate4.Play();
                combatScript.combatUIAnimator.CrossFade("EnemyHearthAnimation", 0f);
                stadisticplayerScipt.SpiritGrowthStacks += 1;
                PlayAudio(magicCircle);
                enemyy.health -= 1;
                protectiontottempasive();
                if (stadisticplayerScipt.SpiritGrowthStacks >= 3)
                {
                    enemyy.health -= 4;
                    Debug.Log("You have done <color=red>5 points of damage</color> with spirit growth.");
                }
                break;
            case "Unbreakable":
                
                combatScript.combatUIAnimator.CrossFade("EnemyHearthAnimation", 0f);
                PlayAudio(windowFixing);
                stadisticplayerScipt.vigor += 5;
                protectiontottempasive();
                InvObjActionsScript.vigorParticlesPlayer.Play();
                Debug.Log("You had increase your <color=blue>vigor</color> in <color=blue>5 points</color>.");
                break;
            case "Protection Tottem":
               
                stadisticplayerScipt.health += 1;
                inventoryObjectsScript.HealthPotionParticles.Play();
                protectiontottempasive();
                Debug.Log("You had <color=green>healed 1 point of health</color>.");
                stadisticplayerScipt.ProtectionTottemStacks += 1;
                if (stadisticplayerScipt.ProtectionTottemStacks == 5)
                {
                    PlayAudio(remorseFemale);
                    Debug.Log("Protection Tottem got <color=green>activated</color>.");
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
                combatScript.combatUIAnimator.CrossFade("EnemyHearthAnimation", 0f);
                enemyy.health -= 9;
                protectiontottempasive();
                PlayAudio(CaosAudio);
                Debug.Log("You had done <color=red>9 points of damage</color> to your <color=red>enemy</color>.");
                
                break;
            case "Dead eye":
                combatScript.damageparticleSlot23.Play();
                combatScript.damageparticleSlot23Combate2.Play();
                combatScript.damageparticleSlot23_Combate3.Play();
                combatScript.damageparticleSlot23_Combate4.Play();
                combatScript.combatUIAnimator.CrossFade("EnemyHearthAnimation", 0f);
                enemyy.health -= 7;
                inventoryObjectsScript.HealthPotionParticles.Play();
                stadisticplayerScipt.health += 3;
                protectiontottempasive();
                PlayAudio(DeadEyeAudio);
                Debug.Log("You had done <color=red>7 points of damage</color> and <color=green>healed yourself 3 points</color>.");
               
                break;
            case "Prominence burn":
                combatScript.damageparticleSlot24.Play();
                combatScript.damageparticleSlot24Combate2.Play();
                combatScript.damageparticleSlot24_Combate3.Play();
                combatScript.damageparticleSlot24_Combate4.Play();
                combatScript.combatUIAnimator.CrossFade("EnemyHearthAnimation", 0f);
                enemyy.health -= 3;
                inventoryObjectsScript.HealthPotionParticles.Play();
                PlayAudio(healUp);
                stadisticplayerScipt.health += 3;
                protectiontottempasive();
                Debug.Log("You had done <color=red>3 points of damage</color> and <color=green>healed yourself 3 points</color>.");
               
                break;
            case "Absolution":
                
                combatScript.combatUIAnimator.CrossFade("EnemyHearthAnimation", 0f);
               
                InvObjActionsScript.vigorParticlesPlayer.Play();
                enemyy.health -= 6;
                PlayAudio(iceMagic);
                stadisticplayerScipt.health += 4;
                protectiontottempasive();
                Debug.Log("You had done <color=red>6 points of damage</color> and <color=green>healed yourself 4 points</color>.");
                
                break;
            case "Uncontrolled pride":
                combatScript.damageparticleSlot26.Play();
                combatScript.damageparticleSlot26Combate2.Play();
                combatScript.damageparticleSlot26_Combate3.Play();
                combatScript.damageparticleSlot26_Combate4.Play();
                combatScript.combatUIAnimator.CrossFade("EnemyHearthAnimation", 0f);
                enemyy.health -= 5;
                PlayAudio(CaosAudio);
                Debug.Log("You had done <color=red>7 points of damage</color>.");
                protectiontottempasive();
                
                break;

            case "absortion":
                combatScript.damageparticleSlot27.Play();
                combatScript.damageparticleSlot27Combate2.Play();
                combatScript.damageparticleSlot27_Combate3.Play();
                combatScript.damageparticleSlot27_Combate4.Play();
                combatScript.combatUIAnimator.CrossFade("EnemyHearthAnimation", 0f);
                PlayAudio(audiosVigorArray[0]);
                protectiontottempasive();
                if (stadisticplayerScipt.vigor <= 3)
                {
                    InvObjActionsScript.vigorParticlesPlayer.Play();
                    stadisticplayerScipt.vigor = 7;
                    Debug.Log("You had increased your <color=blue>vigor in 7 points</color>.");
                }
                break;
            case "Balance of Death":
                combatScript.damageparticleSlot28.Play();
                protectiontottempasive();
                combatScript.damageparticleSlot28Combate2.Play();
                combatScript.damageparticleSlot28_Combate3.Play();
                combatScript.damageparticleSlot28_Combate4.Play();
                combatScript.combatUIAnimator.CrossFade("EnemyHearthAnimation", 0f);
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
                Debug.Log("You had done the difference of <color=green>health</color> between you and your oponent as <color=red>damage</color>.");
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
                Debug.Log("You had <color=green>healed yourself</color> the difference of health between you and your oponent.");
                break;

            case "Blood Drainer":
                combatScript.damageparticleSlot30.Play();
                combatScript.damageparticleSlot30Combate2.Play();
                protectiontottempasive();
                combatScript.damageparticleSlot30_Combate3.Play();
                combatScript.damageparticleSlot30_Combate4.Play();
                combatScript.combatUIAnimator.CrossFade("EnemyHearthAnimation", 0f);
                enemyy.health -= 4;
                Debug.Log("You had done <color=red>4 points of damage</color>.");
                stadisticplayerScipt.bloodDrainerCounter += 1;
                PlayAudio(audiosVigorArray[3]);

                if (stadisticplayerScipt.bloodDrainerCounter == 3)
                {
                    InvObjActionsScript.HealthPotions += 1;
                    stadisticplayerScipt.bloodDrainerCounter = 0;
                    Debug.Log("You had got a <color=green>health potion</color>.");
                }
                break;
            case "Death Reaper":
                combatScript.damageparticleSlot31.Play();
                combatScript.damageparticleSlot31Combate2.Play();
                protectiontottempasive();
                combatScript.damageparticleSlot31_Combate3.Play();
                combatScript.damageparticleSlot31_Combate4.Play();
                combatScript.combatUIAnimator.CrossFade("EnemyHearthAnimation", 0f);
                PlayAudio(audiosVigorArray[4]);
                stadisticplayerScipt.vigor += 7;
                InvObjActionsScript.vigorParticlesPlayer.Play();
                Debug.Log("You had increased your <color=blue>vigor in 7 points</color>.");
                if (stadisticplayerScipt.health <= 15)
                {
                    enemyy.health = 0;
                    Debug.Log("You had <color=red>executed</color> your oponent.");
                }
                break;
            case "Devil Eyes":
               
                protectiontottempasive();
                PlayAudio(audiosVigorArray[5]);
                
                inventoryObjectsScript.HealthPotionParticles.Play();
                stadisticplayerScipt.health += combatScript.devilEyesPassive;
                Debug.Log("You had damaged your <color=red>enemy</color> with" + combatScript.devilEyesPassive+ " <color=red>points of damage</color>.");
                break;
            case "Evil Pendant":
                
                protectiontottempasive();
                PlayAudio(audiosVigorArray[6]);
                
                inventoryObjectsScript.HealthPotionParticles.Play();
                stadisticplayerScipt.health += 7;
                stadisticplayerScipt.vigor += 6;
                InvObjActionsScript.vigorParticlesPlayer.Play();
                Debug.Log("You had increased your <color=blue>vigor in 6 points</color> and you had <color=green>healed yourself in 7 points</color>.");
                break;
            case "Souls Strike":
                combatScript.damageparticleSlot34.Play();
                combatScript.damageparticleSlot34Combate2.Play();
                protectiontottempasive();
                combatScript.damageparticleSlot34_Combate3.Play();
                combatScript.damageparticleSlot34_Combate4.Play();
                combatScript.combatUIAnimator.CrossFade("EnemyHearthAnimation", 0f);
                PlayAudio(audiosVigorArray[7]);
                enemyy.health -= 5;
                Debug.Log("You had done <color=red>5 points of damage</color> to your oponent.");
                if (stadisticplayerScipt.health < stadisticplayerScipt.vigor)
                {
                    enemyy.health = 0;
                    Debug.Log("You had <color=red>executed</color> your oponent.");
                }
                break;
            case "Thanatos":
                combatScript.damageparticleSlot35.Play();
                PlayAudio(audiosVigorArray[8]);
                combatScript.damageparticleSlot35Combate2.Play();
                protectiontottempasive();
                combatScript.damageparticleSlot35_Combate3.Play();
                combatScript.damageparticleSlot35_Combate4.Play();
                combatScript.combatUIAnimator.CrossFade("EnemyHearthAnimation", 0f);
                enemyy.health -= 5;
                Debug.Log("You had done <color=red>5 points of damage</color> to your oponent.");
                if (stadisticplayerScipt.health <= 15)
                {
                    InvObjActionsScript.vigorParticlesPlayer.Play();
                    stadisticplayerScipt.vigor += 15;
                    Debug.Log("You had increased your <color=blue>vigor in 15 points</color>.");
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
