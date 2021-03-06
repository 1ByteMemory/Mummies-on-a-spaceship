﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public GameManager gameManager;
    public GameObject zombie;
    public float spawnerMaxHealth = 10;
    public float spawnHelpHealth = 6;
    public float spawnDelay = 5;
    public int maxEnemies = 15;

    public float minSpawnRadius = 1.5f;
    public float maxSpawnRadius = 3.5f;

    [HideInInspector]
    public int numberSpawned = 0;
    [HideInInspector]
    public float spawnCurrentHealth;

    private bool enabledSpawner = true;

    // Draw Gismos to see where zombies will spawn.
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position, new Vector3(minSpawnRadius, 0, minSpawnRadius));
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, new Vector3(maxSpawnRadius, 0, maxSpawnRadius));
    }
    
    private void Start()
    {
        spawnCurrentHealth = spawnerMaxHealth;

        if (spawnHelpHealth > spawnerMaxHealth)
        {
            Debug.LogError("Spawner Help Health must be smaller than Spawner Health! In Spawn Controller Componant on " + gameObject);
            spawnHelpHealth = spawnerMaxHealth - 1;
        }
    }

    // Update is called once per frame
    void Update () {
        float time = Time.time;
        
        //Debug.Log(spawnCurrentHealth);

        // Spawns zombies every x amount of seconds.
        if (Mathf.Round(time) % spawnDelay == 0 && enabledSpawner)
        {
            SpawnEnemies();
        }
    }

    public void SpawnerHit()
    {
        spawnCurrentHealth = GetComponent<Target>().targetHP;
    }

    public void SpawnerDeath()
    {
        enabledSpawner = false;

        gameObject.transform.DetachChildren();
        gameManager.spawnersDestroyed++;

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Target>().enabled = false;

        StartCoroutine(Respawn());
    }

    private void SpawnEnemies ()
    {

        if (numberSpawned <= maxEnemies)
        {
            numberSpawned++;
            
            // Chooses a random point around spawner.
            float spawnX = Random.Range(minSpawnRadius, maxSpawnRadius);
            float spawnZ = Random.Range(minSpawnRadius, maxSpawnRadius);
        
            Vector3 spawnPoint = new Vector3(spawnX, 0, spawnZ) + transform.position;
        
            GameObject inst = Instantiate(zombie, spawnPoint, new Quaternion());
        
            inst.transform.parent = gameObject.transform;
        }
    }

    // Re-enables spawner as if a new one has apperad.
    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(10);

        enabledSpawner = true;

        spawnerMaxHealth++;
        spawnHelpHealth++;
        spawnCurrentHealth = spawnerMaxHealth;
        GetComponent<Target>().targetHP = spawnCurrentHealth;
        maxEnemies++;

        Debug.Log(spawnCurrentHealth);

        GetComponent<MeshRenderer>().enabled = true;
        GetComponent<BoxCollider>().enabled = true;
        GetComponent<Target>().enabled = true;
    }

}
