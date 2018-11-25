using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public Gun gunScript;
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

        if (Mathf.Round(time) % spawnDelay == 0)
        {
            SpawnEnemies();
        }
    }

    public void SpawnerHit()
    {
        spawnCurrentHealth -= gunScript.damage;
        

        if (spawnCurrentHealth <= 0)
        {
            gameObject.transform.DetachChildren();
            Destroy(gameObject);
        }
    }

    private void SpawnEnemies ()
    {

        if (numberSpawned <= maxEnemies)
        {
            numberSpawned++;
        
            float spawnX = Random.Range(minSpawnRadius, maxSpawnRadius);
            float spawnZ = Random.Range(minSpawnRadius, maxSpawnRadius);
        
            Vector3 spawnPoint = new Vector3(spawnX, transform.position.y, spawnZ) + transform.position;
        
            GameObject inst = Instantiate(zombie, spawnPoint, new Quaternion());
        
            inst.transform.parent = gameObject.transform;
        }
    }
}
