using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySectarian : Enemy
{
    public Animator myAnim;
    public override void Awake()
    {
        myAnim = GetComponent<Animator>();
        base.Awake();
    }
    public override void Start()
    {
        base.Start();
    }
    public override void Enemyturn()
    {
        if (health <= 30 && health > 20)
        {
            int Numero = Random.Range(1, 101);
            if (Numero >= 15)
            {
                BasicDamage();
            }
            else if (Numero < 15)
            {
                HeavyDamage();
            }
        }
        else if (health > 10 && health <= 20)
        {
            int Numero2 = Random.Range(1, 101);
            if (Numero2 >= 20)
            {
                BasicDamage();
            }
            else if (Numero2 < 20)
            {
                HeavyDamage();
            }
        }
        else if (health > 0 && health <= 10)
        {
            int Numero3 = Random.Range(1, 101);
            if (Numero3 >= 25)
            {
                BasicDamage();
            }
            else if (Numero3 < 25)
            {
                HeavyDamage();
            }
            if (Numero3 <= 15)
            {
                Regeneration();
            }
        }
    }
    public void BasicDamage()
    {
        myAnim.Play("Enemy S Attack");
        PlayerStadisticsScript.health -= 2;
        Debug.Log("The <color=red>enemy</color> dealt <color=red>2 points of damage</color> to the player with a basic attack.");
        PlayBasicAttackParticles();
    }
    public void HeavyDamage()
    {
        myAnim.Play("Enemy S HAttack");
        PlayerStadisticsScript.health -= 4;
        Debug.Log("The <color=red>enemy</color> dealt <color=red>4 points of damage</color> to the player with a heavy attack.");
        PlayHeavyAttackParticles();
    }
    public void Regeneration()
    {
        myAnim.Play("Enemy Health");
        health += 4;
        health -= PlayerStadisticsScript.antihealingToEnemies;
        if (PlayerStadisticsScript.antihealingToEnemies > 0)
        {
            Debug.Log("<color=red>Enemy</color> got <color=red>damaged</color> by Cursed Mud when tried to heal himself with <color=green>5 points of health</color>.");
        }
        else
        {
            Debug.Log("The <color=red>enemy</color> healed <color=green>4 points of health</color>.");
            myAnim.Play("Enemy Health");
        }
    }
}