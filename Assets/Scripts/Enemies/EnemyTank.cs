using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : Enemy
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
        if (health <= 40 && health > 25)
        {
            int Numero = Random.Range(1, 101);
            if (Numero >= 20)
            {
                BasicDamage();
            }
            else if (Numero < 20)
            {
                HeavyDamage();
            }
        }
        else if (health > 15 && health <= 25)
        {
            int Numero2 = Random.Range(1, 101);
            if (Numero2 >= 25)
            {
                BasicDamage();
            }
            else if (Numero2 < 25)
            {
                HeavyDamage();
            }
        }
        else if (health > 0 && health <= 15)
        {
            int Numero3 = Random.Range(1, 101);
            if (Numero3 >= 30)
            {
                BasicDamage();
            }
            else if (Numero3 < 30)
            {
                HeavyDamage();
            }
            if (Numero3 <= 20)
            {
                Regeneration();
            }
        }
    }
    public void BasicDamage()
    {
        myAnim.Play("Enemy T Attack");
        PlayerStadisticsScript.health -= 3;
        Debug.Log("The <color=red>enemy</color> dealt <color=red>3 points of damage</color> to the player with a basic attack.");
        PlayBasicAttackParticles();
    }
    public void HeavyDamage()
    {
        myAnim.Play("Enemy T HAttack");
        PlayerStadisticsScript.health -= 5;
        Debug.Log("The <color=red>enemy</color> dealt <color=red>5 points of damage</color> to the player with a heavy attack.");
        PlayHeavyAttackParticles();
    }
    public void Regeneration()
    {
        myAnim.Play("Enemy Health");
        health += 6;
        health -= PlayerStadisticsScript.antihealingToEnemies;
        if (PlayerStadisticsScript.antihealingToEnemies > 0)
        {
            Debug.Log("<color=red>Enemy</color> got <color=red>damaged</color> by Cursed Mud when tried to heal himself with <color=green>6 points of health</color>.");
        }
        else
        {
            Debug.Log("The <color=red>enemy</color> healed <color=green>6 points of health</color>.");
            myAnim.Play("Enemy Health");
        }

    }
}