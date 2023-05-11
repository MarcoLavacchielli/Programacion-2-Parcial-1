using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySectarian : Enemy
{
    public override void Start()
    {
        base.Start();
    }
    public override void Enemyturn()
    {
        if (health <= 15 && health > 11)
        {
            BasicDamage();
        }
        else if (health > 6 && health <= 11)
        {
            HeavyDamage();
        }
        else if (health > 0 && health <= 6)
        {
            Regeneration();
        }
    }
    public void BasicDamage()
    {
        PlayerStadisticsScript.health -= 3;
        Debug.Log("El enemigo inflingio 3 de da�o al jugador con un ataque basico");
    }
    public void HeavyDamage()
    {
        PlayerStadisticsScript.health -= 5;
        Debug.Log("El enemigo inflingio 5 de da�o al jugador con un golpe pesado");
    }
    public void Regeneration()
    {
        health += 5;
        Debug.Log("El enemigo se curo 5 de vida");
    }
}