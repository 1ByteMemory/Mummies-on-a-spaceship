﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerHeal : MonoBehaviour {

    public SpawnController sp;
    public MummyController zombies;

    private int HealBoost;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Zombie" && zombies.Action() == "Heal")
        {
            HealBoost++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Zombie" && zombies.Action() == "Heal")
        {
            HealBoost--;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Zombie" && zombies.Action() == "Heal")
        {
            sp.spawnerMaxHealth += HealBoost * Time.deltaTime;
        }
    }
}
