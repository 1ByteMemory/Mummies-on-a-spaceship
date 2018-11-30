using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerHeal : MonoBehaviour {

    public SpawnController sp;
    //public MummyController zombies;

    private int HealBoost;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Zombie" && other.GetComponent<MummyController>().Action() == "Heal")
        {
            HealBoost++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Zombie" && other.GetComponent<MummyController>().Action() == "Heal")
        {
            HealBoost--;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Zombie" && other.GetComponent<MummyController>().Action() == "Heal")
        {
            sp.spawnCurrentHealth += HealBoost * Time.deltaTime; // Spawners health is regenerated based on amount of zombies nearby.
        }
    }
}
