using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeController : MonoBehaviour {

    public GameObject grenade;
    public Camera FPS_Camera;
    public float throwForce;
    public float throwCooldown = 4;
    public Image grenadeIcon;
    public Slider grenadeIndicator;

    //private bool throwable = true;
    private float nextFireTime;
    private float startFireTime;
    private Rigidbody rb;
    

    private void Update()
    {
        if (Time.time > nextFireTime)
        {
            grenadeIcon.color = Color.white;
            if (Input.GetButtonDown("Fire2"))
            {
                startFireTime = Time.time;
                nextFireTime = Time.time + throwCooldown;
                ThrowGrenade();
            }
        }
        else
        {
            grenadeIcon.color = Color.grey;
            grenadeIndicator.value = (Time.time - startFireTime) / (nextFireTime - startFireTime);
        }
    }


    void ThrowGrenade()
    {
        GameObject inst = Instantiate(grenade, transform.position, new Quaternion());
        
        inst.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce, ForceMode.Impulse);
    }
}
