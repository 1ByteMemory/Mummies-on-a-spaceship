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
            Shoot();
        }

	}

    void Shoot()
    {
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hitInfo))
        {
            zombieHitScript.ZombieHit();
            spawnerHitScript.SpawnerHit();
        }
        
    }
}
