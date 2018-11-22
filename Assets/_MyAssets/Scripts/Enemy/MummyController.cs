using UnityEngine;
using UnityEngine.AI;

public class MummyController : MonoBehaviour {

    public NavMeshAgent agent;
    public int enemyDamage = 1;
    public GameObject player;

	// Update is called once per frame
	void Update () {
        agent.SetDestination(player.transform.position);
	}





}
