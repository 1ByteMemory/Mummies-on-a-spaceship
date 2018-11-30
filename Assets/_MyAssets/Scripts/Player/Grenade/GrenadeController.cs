using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrenadeController : MonoBehaviour {

    public GameObject grenade; // Where the grenade fires from. Attachted to camera.
    public Camera FPS_Camera;
    public float throwForce;
    public float throwCooldown = 4;
    public Image grenadeIcon;
    public Slider grenadeIndicator;

    //private bool throwable = true;
    private float nextFireTime;
    private float startFireTime;
    private Rigidbody rb;

    private void Start()
    {
        
        grenadeIndicator.value = 1;
        nextFireTime = -1;
    }

    private void Update()
    {
        // Grenade can only fire once it has been charged.
        if (Time.time > nextFireTime)
        {
            grenadeIcon.color = Color.white;
            if (Input.GetButtonDown("Fire2") && !Cursor.visible) // !Cursor.visible stops the player from being able to shoot in the puaase menu.
            {

                // sets the start time and cooldown time for the grenade.
                startFireTime = Time.time;
                nextFireTime = Time.time + throwCooldown;
                ThrowGrenade();
            }
        }
        else
        {
            grenadeIcon.color = Color.grey;

            // Basic math to make the slider indicator be at the right place.
            grenadeIndicator.value = (Time.time - startFireTime) / (nextFireTime - startFireTime);
        }
    }


    void ThrowGrenade()
    {

        GameObject inst = Instantiate(grenade, transform.position, new Quaternion());
        
        // adds force to the grenade.
        inst.GetComponent<Rigidbody>().AddForce(transform.forward * throwForce, ForceMode.Impulse);
    }
}
