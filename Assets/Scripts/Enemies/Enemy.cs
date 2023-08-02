using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Player player;
    public Combat combat;
    CombatPosition _combatposition;
    public int health;
    public string tipodeenemigo;
    public StadisticPlayer PlayerStadisticsScript;

    public Transform ataqueEnemy1SpawnPoint;
    public Transform ataqueEnemigo2SpawnPoint;
    public Transform ataqueEnemy1SpawnPoint_Combate2;
    public Transform ataqueEnemigo2SpawnPoint_Combate2;
    public Transform ataqueEnemy1SpawnPoint_Combate3;
    public Transform ataqueEnemigo2SpawnPoint_Combate3;

    private ParticleSystem ataqueEnemy1;
    private ParticleSystem ataqueEnemigo2;
    private ParticleSystem debris;
    private ParticleSystem ataqueEnemy1_combate2;
    private ParticleSystem ataqueEnemigo2_combate2;
    private ParticleSystem debris_combate2;
    private ParticleSystem ataqueEnemy1_combate3;
    private ParticleSystem ataqueEnemigo2_combate3;
    private ParticleSystem debris_combate3;

    public virtual void Awake()
    {
        
    }
    public virtual void Start()
    {
        Enemyapears();
        GameObject PlayerObject = GameObject.Find("Player");

        if (PlayerObject != null)
        {
            // Obtener la referencia al script "OtroScript" en el objeto encontrado
            combat = PlayerObject.GetComponent<Combat>();

        }

        ataqueEnemy1 = GameObject.Find("AtaqueEnemy1").GetComponent<ParticleSystem>();
        ataqueEnemigo2 = GameObject.Find("AtaqueEnemigo2").GetComponent<ParticleSystem>();
        debris = GameObject.Find("Debris").GetComponent<ParticleSystem>();
        ataqueEnemy1_combate2 = GameObject.Find("AtaqueEnemy1_Combat2").GetComponent<ParticleSystem>();
        ataqueEnemigo2_combate2 = GameObject.Find("AtaqueEnemigo2_Combat2").GetComponent<ParticleSystem>();
        debris_combate2 = GameObject.Find("Debris_Combat2").GetComponent<ParticleSystem>();
        ataqueEnemy1_combate3 = GameObject.Find("AtaqueEnemy1_Combat3").GetComponent<ParticleSystem>();
        ataqueEnemigo2_combate3 = GameObject.Find("AtaqueEnemigo2_Combat3").GetComponent<ParticleSystem>();
        debris_combate3 = GameObject.Find("Debris_Combat3").GetComponent<ParticleSystem>();


        ataqueEnemy1.Stop(); 
        ataqueEnemigo2.Stop();
        debris.Stop();
        ataqueEnemy1_combate2.Stop();
        ataqueEnemigo2_combate2.Stop();
        debris_combate2.Stop();
        ataqueEnemy1_combate3.Stop();
        ataqueEnemigo2_combate3.Stop();
        debris_combate3.Stop();
    }
    void Enemyapears()
    {
        Debug.Log("An <color=red>enemy</color> " + tipodeenemigo + " has appeared.");
    }
    private void Update()
    {
        EnemyDies();
    }
    public virtual void Enemyturn()
    {
        
    }
    
    public void Setcombat(CombatPosition combatPosition)
    {
        _combatposition = combatPosition;
    }
    public void SetPlayer(StadisticPlayer playerreference)
    {
        PlayerStadisticsScript = playerreference;
    }
    public virtual void EnemyDies()
    {
        if (health <= 0)
        {
            combat.EndOfCombat();//prueba
            PlayerStadisticsScript.vigor = 3;//prueba
            _combatposition.salircombate();
            Destroy(gameObject);
        }
    }

    public void PlayBasicAttackParticles()
    {
        ataqueEnemy1.Play();
        ataqueEnemy1_combate2.Play();
        ataqueEnemy1_combate3.Play();
    }

    public void PlayHeavyAttackParticles()
    {
        ataqueEnemigo2.Play();
        ataqueEnemigo2_combate2.Play();
        ataqueEnemigo2_combate3.Play();

        debris.Play();
        debris_combate2.Play();
        debris_combate3.Play();
    }
}
