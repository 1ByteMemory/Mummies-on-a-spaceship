using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public Camera playerCamera;
    public int damage = 1;
    public float range = 100f;
    public RaycastHit hitInfo;
    public MummyController zombieHitScript;
    public SpawnController spawnerHitScript;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1"))
        {
            //Debug.Log("Fire");
            Shoot();
        }

	}

    void Shoot()
    {
        
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hitInfo))
        {
            if (hitInfo.transform.tag == "Zombie")
            {
                hitInfo.transform.GetComponent<MummyController>().ZombieHit();
            }
            else if (hitInfo.transform.tag == "Spawner")
            {
                hitInfo.transform.GetComponent<SpawnController>().SpawnerHit();
            }
        }
    }
}
