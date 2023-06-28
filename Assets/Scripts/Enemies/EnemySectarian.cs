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
        Debug.Log("The enemy dealt 2 damage to the player with a basic attack");
        PlayBasicAttackParticles();
    }
    public void HeavyDamage()
    {
        myAnim.Play("Enemy S HAttack");
        PlayerStadisticsScript.health -= 4;
        Debug.Log("The enemy dealt 4 damage to the player with a heavy attack");
        PlayHeavyAttackParticles();
    }
    public void Regeneration()
    {
        myAnim.Play("Enemy Health");
        health += 4;
        health -= PlayerStadisticsScript.antihealingToEnemies;
        if (PlayerStadisticsScript.antihealingToEnemies > 0)
        {
            Debug.Log("Enemy got damage by Cursed Mud when tried to heal himself with 5 points of health");
        }
        else
        {
            Debug.Log("The enemy healed 4 points of health");
            myAnim.Play("Enemy Health");
        }
    }
}