using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    public Camera playerCamera;
    public float damage = 1;
    public float range = 100f;
    public GameObject muzzleFlash;

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
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hitInfo))
        {
            //impactMat = hitInfo.transform.GetComponent<MeshRenderer>().material;
            
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
