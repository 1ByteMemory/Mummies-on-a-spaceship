﻿using UnityEngine;
using UnityEngine.AI;

public class MummyController : MonoBehaviour {

    public NavMeshAgent agent;
    public GameObject player;
    public Gun gunScript;
    public SpawnController spawner;
    public int enemyDamage = 1;
    public int zombieHealth = 1;
    public float rageSpeed = 7f;

    private int choice;

    [HideInInspector]
    public bool helping = false;

    const string Action_Seek = "Seek";
    const string Action_Rage = "Rage";
    const string Action_Heal = "Heal";
    const string Action_Stay = "Stay";

    private void Start()
    {
        choice = Random.Range(0, 2);
    }


    // Update is called once per frame
    void Update()
    {
        switch (Action())
        {
            case Action_Seek:
                {
                    agent.SetDestination(player.transform.position);
                }
                break;

            case Action_Rage:
                {
                    agent.speed = rageSpeed;
                    agent.SetDestination(player.transform.position);
                }
                break;
            case Action_Heal:
                {
                    agent.SetDestination(spawner.transform.position);
                }
                break;
            case Action_Stay:
                {
                    // Play healling particles.
                }
                break;
        }
    }

    public string Action()
    {
        if (spawner != null)
        {
            if (helping && choice == 0)
            {
                return Action_Heal;
            }
            else if (helping && choice == 1)
            {
                return Action_Rage;
            }
            else
            {
                return Action_Seek;
            }
        }
        else
        {
            return Action_Rage;
        }
    }

    public void ZombieHit()
    {
        zombieHealth -= gunScript.damage;
        //Debug.LogWarning(zombieHealth);

        if (zombieHealth <= 0)
        {
            if (spawner != null) { spawner.numberSpawned--; }
            Destroy(gameObject);
        }
    }
}
