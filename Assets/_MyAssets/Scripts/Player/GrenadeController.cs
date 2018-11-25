using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeController : MonoBehaviour {

    public GameObject grenade;
    public Camera FPS_Camera;
    public float throwForce;

    private bool throwable = true;
    private Rigidbody rb;

    private void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            ThrowGrenade();
        }
    }


    void ThrowGrenade()
    {
        GameObject inst = Instantiate(grenade, transform.position, new Quaternion());
        
        inst.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce, ForceMode.Impulse);




    }

}
