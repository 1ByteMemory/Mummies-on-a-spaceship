using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public Camera playerCamera;
    public float damage = 1;
    public float range = 100f;
    public GameObject muzzleFlash;
    public GameObject impactAffect;

    private Material impactMat;
    private RaycastHit hitInfo;
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
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hitInfo)) //  If raycast has hit something
        {
            if (hitInfo.transform.tag == "Zombie") // if is hit a zombie.
            {
                impactMat = hitInfo.transform.GetComponentInChildren<Renderer>().materials[0]; // Get's the material of zombie.
            }
            else
            {
                impactMat = hitInfo.transform.GetComponent<MeshRenderer>().material;
            }

            impactAffect.transform.GetComponent<ParticleSystemRenderer>().material = impactMat; // Applies material to the impact effect.
            GameObject imp = Instantiate(impactAffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal)); // Instantiates an impact effect at impact.
            Destroy(imp, 3);


            if (hitInfo.transform.GetComponent<Target>())
            {
                hitInfo.transform.GetComponent<Target>().TargetTakeDamage(damage); // if the hit ibject has a target script, take damage.
            }
        }
    }

    void StopAnimation()
    {
        anim.Play("Hold");
    }
}
