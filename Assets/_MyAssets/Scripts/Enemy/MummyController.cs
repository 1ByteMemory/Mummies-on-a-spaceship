using UnityEngine;
using UnityEngine.AI;

public class MummyController : MonoBehaviour {
    
    public int enemyDamage = 1;
    public float rageSpeed = 7f;
    public ParticleSystem deathParticles;

    private NavMeshAgent agent;
    private GameObject player;
    private SpawnController spawner;
    private Animator anim;

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
        anim = GetComponent<Animator>();

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

        // Switch Case to deturmine action.
        switch (Action())
        {
            case Action_Seek:
                {
                    anim.SetBool("isWalk", true);
                    agent.SetDestination(player.transform.position); // Follows player.
                }
                break;

            case Action_Rage:
                {
                    anim.SetBool("isRun", true);
                    agent.speed = rageSpeed; // Speed incresed
                    agent.SetDestination(player.transform.position); // follows player.
                }
                break;
            case Action_Heal:
                {
                    agent.SetDestination(spawner.transform.position); // Goes to spawner to heal it.
                }
                break;
            case Action_Stay:
                {
                    // Defunct part of script.
                    // Play healling particles.
                }
                break;
        }
    }

    // the AI bit.
    public string Action()
    {
        if (spawner != null)
        {
            // Zombies will either heal the spawner or rage at the player when spawner is attacked.
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
        if (spawner != null) { spawner.numberSpawned--; } // Allows spawner to spawn another zombie.
        ParticleSystem inst = Instantiate(deathParticles, transform.position, Quaternion.Euler(-90, 0, 0)); // Death particles.
        inst.Play();
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Deals damage to player
        if (collision.transform.tag == "Player")
        {
            anim.SetBool("isAttack", true);
            collision.transform.GetComponent<Target>().TargetTakeDamage(enemyDamage);
        }

        if (collision.transform.tag == "Spawner")
        {
            anim.SetBool("isDancing", true);
        }
    }
}
