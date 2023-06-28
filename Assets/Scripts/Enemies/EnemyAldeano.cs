using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyAldeano : Enemy
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
        if (health <= 20 && health > 15)
        {
            int Numero = Random.Range(1, 101);
            if (Numero >= 10)
            {
                BasicDamage();
            }
            else if (Numero < 10)
            {
                HeavyDamage();
            }
        }
        else if (health > 5 && health <= 15)
        {
            int Numero2 = Random.Range(1, 101);
            if (Numero2 >= 15)
            {
                BasicDamage();
            }
            else if (Numero2 < 15)
            {
                HeavyDamage();
            }
        }
        else if (health > 0 && health <= 5)
        {
            int Numero3 = Random.Range(1, 101);
            if (Numero3 >= 20)
            {
                BasicDamage();
            }
            else if (Numero3 < 20)
            {
                HeavyDamage();
            }
            if (Numero3 <= 10)
            {
                Regeneration();
            }
        }
    }
    public void BasicDamage()
    {
        myAnim.Play("Enemy Attack");
        PlayerStadisticsScript.health -= 1;
        Debug.Log("The enemy dealt 1 damage to the player with a basic attack");
        PlayBasicAttackParticles();
    }
    public void HeavyDamage()
    {
        myAnim.Play("Enemy HAttack");
        PlayerStadisticsScript.health -= 3;
        Debug.Log("The enemy dealt 3 damage to the player with a heavy attack");
        PlayHeavyAttackParticles();
    }
    public void Regeneration()
    {
        health += 2;
        health -= PlayerStadisticsScript.antihealingToEnemies;
        if (PlayerStadisticsScript.antihealingToEnemies > 0)
        {
            Debug.Log("Enemy got damage by Cursed Mud when tried to heal himself with 3 points of health");
        }
        else
        {
            Debug.Log("The enemy healed 2 points of health");
            myAnim.Play("Enemy Health");
        }
    }
    public void Isattack(bool attack)
    {
        myAnim.SetBool("isattack", attack);
    }
}