using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{


    public Card card;
    public Text nametext;
    public Text descriptiontext;
    public Image image;

    public Text attacktext;

    public Deck scriptdeck;
    public int myslot;
    public int attackdmg;

    public string NombredelaCartayEjecutarPasiva;
    public Player player;
    public StadisticPlayer StatsPlayerScript;
    public Enemy enemyy;

    public AudioSource MyAudioSource;
    public AudioClip BigBangAudio;
    public AudioClip fireExplosionAudio;
    public AudioClip DestructionAudio;

    public AudioClip NormalAudioCard;
    public AudioClip komori;
    public AudioClip musicBox;
    public AudioClip railgun;

    public AudioClip[] audiosArray;

    public Combat combatScript;

    public Image notUsable;

    public inventoryObjectsActions inventoryObjectsScript;


    public void EmptySlot()
    {
        card = null;
        nametext = null;
        NombredelaCartayEjecutarPasiva = null;
    }
    private void Start()
    {

        nametext.text = card.name;
        descriptiontext.text = card.description;
        image.sprite = card.image;

        attacktext.text = card.attack.ToString();


    }
    public void Update()
    {
        if (combatScript.playercontador == 1)
        {
            notUsable.gameObject.SetActive(true);
        }
        else
        {
            notUsable.gameObject.SetActive(false);
        }
    }
    public void PlayAudio(AudioClip AC)
    {
        MyAudioSource.clip = AC;
        MyAudioSource.Play();
    }
    public int Thecarddmg()
    {
        if (myslot == 1)
        {
            attackdmg = card.attack;
            return (attackdmg);
        }
        else if (myslot == 2)
        {
            attackdmg = card.attack;
            return (attackdmg);
        }
        else
        {
            attackdmg = card.attack;
            return (attackdmg);
        }
    }
    public void actualizarinfodeUIdeCadaCarta()
    {
        nametext.text = card.name;
        descriptiontext.text = card.description;
        image.sprite = card.image;

        attacktext.text = card.attack.ToString();

    }

    public void setenemy(Enemy enemy)
    {
        enemyy = enemy;
    }
    public void BloodFont()
    {
        enemyy.health -= StatsPlayerScript.bloodFontAditionalDamage;
    }

    public void ejecutarpasivadelacarta()
    {
        NombredelaCartayEjecutarPasiva = card.name;
        /*if(NombredelaCartayEjecutarPasiva=="Sacred Font")
        {
            player.PlayerHealth += 5;
            Debug.Log("te has curado 5 puntos de salud");

        }*/
        switch (NombredelaCartayEjecutarPasiva)
        {
            case "Sacred Font":
                combatScript.damageParticleSlot1.Play();
                combatScript.damageParticleSlot1Combate2.Play();
                combatScript.damageParticleSlot1_Combate3.Play();
                combatScript.damageParticleSlot1_Combate4.Play();
                combatScript.combatUIAnimator.CrossFade("EnemyHearthAnimation", 0f);
                StatsPlayerScript.health += 5;
                StatsPlayerScript.health += StatsPlayerScript.healingRingPassive;
                BloodFont();
                inventoryObjectsScript.HealthPotionParticles.Play();

                PlayAudio(komori);
                Debug.Log("You had <color=green>healed</color>.");
                break;

            case "Big Bang":
                combatScript.damageParticleSlot2.Play();
                combatScript.damageParticleSlot2Combate2.Play();
                combatScript.damageParticleSlot2_Combate3.Play();
                combatScript.damageParticleSlot2_Combate4.Play();
                combatScript.combatUIAnimator.CrossFade("EnemyHearthAnimation", 0f);
                BloodFont();
                PlayAudio(BigBangAudio);
                break;
            case "Fire Explosion":
                combatScript.damageParticleSlot3.Play();
                combatScript.damageParticleSlot3Combate2.Play();
                combatScript.damageParticleSlot3_Combate3.Play();
                combatScript.damageParticleSlot3_Combate4.Play();
                combatScript.combatUIAnimator.CrossFade("EnemyHearthAnimation", 0f);
                BloodFont();
                PlayAudio(fireExplosionAudio);
                break;
            case "Destruction":
                combatScript.damageparticleSlot4.Play();
                combatScript.damageparticleSlot4Combate2.Play();
                combatScript.damageparticleSlot4_Combate3.Play();
                combatScript.damageparticleSlot4_Combate4.Play();
                combatScript.combatUIAnimator.CrossFade("EnemyHearthAnimation", 0f);
                BloodFont();
                PlayAudio(DestructionAudio);
                break;
            case "cristal Pierce":
                combatScript.damageparticleSlot5.Play();
                combatScript.damageparticleSlot5Combate2.Play();
                combatScript.damageparticleSlot5_Combate3.Play();
                combatScript.damageparticleSlot5_Combate4.Play();
                combatScript.combatUIAnimator.CrossFade("EnemyHearthAnimation", 0f);
                BloodFont();
                PlayAudio(komori);
                break;
            case "Magestic":
                combatScript.damageparticleSlot6.Play();
                combatScript.damageparticleSlot6Combate2.Play();
                combatScript.damageparticleSlot6_Combate3.Play();
                combatScript.damageparticleSlot6_Combate4.Play();
                combatScript.combatUIAnimator.CrossFade("EnemyHearthAnimation", 0f);
                PlayAudio(komori);
                BloodFont();
                break;
            case "Mortal Punch":
                combatScript.damageparticleSlot7.Play();
                combatScript.damageparticleSlot7Combate2.Play();
                combatScript.damageparticleSlot7_Combate3.Play();
                combatScript.damageparticleSlot7_Combate4.Play();
                combatScript.combatUIAnimator.CrossFade("EnemyHearthAnimation", 0f);
                BloodFont();
                PlayAudio(railgun);
                break;
            case "Weak Punch":
                combatScript.damageparticleSlot8.Play();
                combatScript.damageparticleSlot8Combate2.Play();
                combatScript.damageparticleSlot8_Combate3.Play();
                combatScript.damageparticleSlot8_Combate4.Play();
                combatScript.combatUIAnimator.CrossFade("EnemyHearthAnimation", 0f);
                BloodFont();
                PlayAudio(musicBox);
                break;
            case "Blood Font":
                combatScript.damageparticleSlot9.Play();
                combatScript.damageparticleSlot9Combate2.Play();
                combatScript.damageparticleSlot9_Combate3.Play();
                combatScript.damageparticleSlot9_Combate4.Play();
                combatScript.combatUIAnimator.CrossFade("EnemyHearthAnimation", 0f);
                StatsPlayerScript.bloodFontAditionalDamage += 1;
                PlayAudio(audiosArray[0]);
                BloodFont();
                break;
            case "Convertion":
                combatScript.damageparticleSlot10.Play();
                combatScript.damageparticleSlot10Combate2.Play();
                combatScript.damageparticleSlot10_Combate3.Play();
                combatScript.damageparticleSlot10_Combate4.Play();
                combatScript.combatUIAnimator.CrossFade("EnemyHearthAnimation", 0f);
                StatsPlayerScript.health += StatsPlayerScript.vigor;
                if (StatsPlayerScript.vigor >= 0)
                {

                    inventoryObjectsScript.HealthPotionParticles.Play();
                }
                PlayAudio(audiosArray[1]);
                StatsPlayerScript.health += StatsPlayerScript.healingRingPassive;
                BloodFont();
                break;
            case "Cursed Mud":
                combatScript.damageparticleSlot11.Play();
                combatScript.damageparticleSlot11Combate2.Play();
                combatScript.damageparticleSlot11_Combate3.Play();
                combatScript.damageparticleSlot11_Combate4.Play();
                combatScript.combatUIAnimator.CrossFade("EnemyHearthAnimation", 0f);
                PlayAudio(audiosArray[2]);
                BloodFont();
                if (StatsPlayerScript.antihealingToEnemies <= 6)
                {
                    StatsPlayerScript.antihealingToEnemies += 2;
                    Debug.Log("The damage taken every time the <color=red>enemy</color> try to heal is" + StatsPlayerScript.antihealingToEnemies + " <color=red>points of damage</color>.");

                }
                else
                {
                    Debug.Log("You already got the max stacks of <color=red>Cursed Mud</color>.");
                }
                break;
            case "Giant Killer":
                combatScript.damageparticleSlot12.Play();
                combatScript.damageparticleSlot12Combate2.Play();
                combatScript.damageparticleSlot12_Combate3.Play();
                combatScript.damageparticleSlot12_Combate4.Play();
                combatScript.combatUIAnimator.CrossFade("EnemyHearthAnimation", 0f);
                float PorcentageReduction = enemyy.health * 0.25f;
                int ResultRounded = (int)Math.Round(PorcentageReduction);
                enemyy.health -= ResultRounded;
                Debug.Log("You had <color=green>25%</color> of the oponent actual health as <color=red>damage</color>.");
                PlayAudio(audiosArray[3]);
                BloodFont();
                break;
            case "Healing Ring":
                combatScript.damageparticleSlot13.Play();
                combatScript.damageparticleSlot13Combate2.Play();
                combatScript.damageparticleSlot13_Combate3.Play();
                combatScript.damageparticleSlot13_Combate4.Play();
                combatScript.combatUIAnimator.CrossFade("EnemyHearthAnimation", 0f);
                StatsPlayerScript.healingRingPassive += 1;
                inventoryObjectsScript.HealthPotionParticles.Play();
                Debug.Log("You had got a stack of <color=green>Healing Ring</color>.");
                BloodFont();
                PlayAudio(audiosArray[4]);
                break;
            case "Nemea BreastPlate":
                combatScript.damageparticleSlot14.Play();
                combatScript.damageparticleSlot14Combate2.Play();
                combatScript.damageparticleSlot14_Combate3.Play();
                combatScript.damageparticleSlot14_Combate4.Play();
                combatScript.combatUIAnimator.CrossFade("EnemyHearthAnimation", 0f);
                if (StatsPlayerScript.damageReduction <= 2)
                {
                    StatsPlayerScript.damageReduction += 1;
                    Debug.Log("You had got a stack of <color=red>Nemea Breastplate</color>.");
                }
                else if (StatsPlayerScript.damageReduction > 2)
                {
                    Debug.Log("You already got the stacks of <color=red>Nemea Breastplate</color>.");
                }
                PlayAudio(audiosArray[5]);
                BloodFont();
                break;
            case "Nemesis":
                combatScript.damageparticleSlot15.Play();
                combatScript.damageparticleSlot15Combate2.Play();
                combatScript.damageparticleSlot15_Combate3.Play();
                combatScript.damageparticleSlot15_Combate4.Play();
                combatScript.combatUIAnimator.CrossFade("EnemyHearthAnimation", 0f);
                enemyy.health -= StatsPlayerScript.vigor;
                Debug.Log("You damaged your <color=red>enemy</color> equal to the amount of <color=blue>vigor</color> you had.");
                PlayAudio(audiosArray[6]);
                BloodFont();
                break;


        }

    }

}
