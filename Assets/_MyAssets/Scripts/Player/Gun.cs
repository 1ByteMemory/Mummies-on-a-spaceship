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
    public ParticleSystem zombieImpact;
    public GameObject muzzleFlash;

    private Animator anim;
    private bool canFire = true;

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        muzzleFlash.SetActive(false);
	}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            anim.Play("GunFireAnimation");
        }
    }

    void Shoot()
    {

        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hitInfo))
        {
            if (hitInfo.transform.tag == "Zombie")
            {
                ParticleSystem inst = Instantiate(zombieImpact, hitInfo.transform.position + new Vector3(0, 0.6f, 0), Quaternion.Euler(-90, 0, 0));
                inst.Play();
                hitInfo.transform.GetComponent<MummyController>().ZombieHit();
            }
            else if (hitInfo.transform.tag == "Spawner")
            {
                hitInfo.transform.GetComponent<SpawnController>().SpawnerHit();
            }
        }
    }

    void StopAnimation()
    {
        anim.Play("Hold");
    }
}
