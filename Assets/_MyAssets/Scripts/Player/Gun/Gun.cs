using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public Camera playerCamera;
    public float damage = 1;
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

        if (Input.GetButton("Fire1") && !Cursor.visible)
        {
            anim.Play("GunFireAnimation");
        }
    }

    void Shoot()
    {
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hitInfo))
        {
            if (hitInfo.transform.GetComponent<Target>())
            {
                hitInfo.transform.GetComponent<Target>().TargetTakeDamage(damage);
            }
        }
    }

    void StopAnimation()
    {
        anim.Play("Hold");
    }
}
