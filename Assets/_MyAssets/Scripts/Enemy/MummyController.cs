using UnityEngine;
using UnityEngine.AI;

public class MummyController : MonoBehaviour {
    
    public int enemyDamage = 1;
    public float rageSpeed = 7f;
    public ParticleSystem deathParticles;

    private NavMeshAgent agent;
    private GameObject player;
    private SpawnController spawner;

    private int choice;

    [HideInInspector]
    public bool helping = false;

    const string Action_Seek = "Seek";
    const string Action_Rage = "Rage";
    const string Action_Heal = "Heal";
    const string Action_Stay = "Stay";

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        spawner = GetComponentInParent<SpawnController>();

        choice = Random.Range(0, 2);
    }


    // Update is called once per frame
    void Update()
    {
        if (spawner.spawnCurrentHealth <= spawner.spawnHelpHealth)
        {
            helping = true;
        }

        if (spawner.spawnCurrentHealth >= spawner.spawnerMaxHealth)
        {
            helping = false;
        }

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

    public void ZombieDeath()
    {
        if (spawner != null) { spawner.numberSpawned--; }
        ParticleSystem inst = Instantiate(deathParticles, transform.position, Quaternion.Euler(-90, 0, 0));
        inst.Play();
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            collision.transform.GetComponent<Target>().TargetTakeDamage(enemyDamage);
        }
    }
}
