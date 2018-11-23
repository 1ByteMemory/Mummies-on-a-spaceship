using UnityEngine;
using UnityEngine.AI;

public class MummyController : MonoBehaviour {

    public NavMeshAgent agent;
    public GameObject player;
    public Gun gunScript;
    public SpawnController spawner;
    public int enemyDamage = 1;
    public int zombieHealth = 1;
    public float rageSpeed = 7f;

    const string Action_Seek = "Seek";
    const string Action_Rage = "Rage";
    const string Action_Heal = "Heal";


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
                    agent.SetDestination(player.transform.position);
                    agent.speed = rageSpeed;
                }
                break;
            case Action_Heal:
                {
                    // Heals the Spawner
                }
                break;
        }
    }

    string Action()
    {
        if (spawner.spawnerHealth <= spawner.spawnHelpHealth)
        {
            float choice = Mathf.Round(Random.Range(0, 1));

            if (choice == 0)
            {
                Debug.Log("Healing");
                return Action_Heal;
            }
            else
            {
                Debug.Log("AAAARRRGGGGHHHH!!!!");
                return Action_Rage;
            }
        }
        else
        {
            Debug.Log("Brains!");
            return Action_Seek;
        }
    }

    public void ZombieHit()
    {
        if (gunScript.hitInfo.transform == gameObject.transform)
        {
            zombieHealth -= gunScript.damage;
        }

        if (zombieHealth <= 0)
        {
            spawner.numberSpawned--;
            Destroy(gameObject);
        }
    }
}
