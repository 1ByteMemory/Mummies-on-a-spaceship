using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour {

    public GameObject zombie;
    public int spawnerHealth = 10;
    public int spawnHelpHealth = 6;
    public float spawnDelay = 5;
    public int spawnAmount = 5;
    public int maxEnemies = 15;


    public float minSpawnRadius = 1.5f;
    public float maxSpawnRadius = 3.5f;

    private int numberSpawned = 0;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position, new Vector3(minSpawnRadius, 0, minSpawnRadius));
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(transform.position, new Vector3(maxSpawnRadius, 0, maxSpawnRadius));
    }



    private void Start()
    {
        if (spawnHelpHealth > spawnerHealth)
        {
            Debug.LogError("Spawner Help Health must be smaller than Spawner Health! In Spawn Controller Componant on " + gameObject);
        }
    }

    // Update is called once per frame
    void Update () {
        float time = Time.time;
        Debug.Log(Mathf.Round(time));

        if (Mathf.Round(time) % spawnDelay == 0 && numberSpawned < maxEnemies)
        {
            SpawnEnemies();
        }
    }


    private void SpawnEnemies ()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            numberSpawned++;

            float spawnX = Random.Range(minSpawnRadius, maxSpawnRadius);
            float spawnZ = Random.Range(minSpawnRadius, maxSpawnRadius);

            Vector3 spawnPoint = new Vector3(spawnX, transform.position.y, spawnZ) + transform.position;

            GameObject inst = Instantiate(zombie, spawnPoint, new Quaternion());

            inst.transform.parent = gameObject.transform;

            if (spawnerHealth <= spawnHelpHealth)
            {
                // Changes the choice of the Zombies.
            }
        }
    }
}
