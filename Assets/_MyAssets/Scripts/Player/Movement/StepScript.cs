using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepScript : MonoBehaviour {
    
    public float stepHieght = 1;
    public GameObject player;

    private Rigidbody rb;
    private PlayerMovement pm;

    private void Start()
    {
        rb = player.GetComponent<Rigidbody>();
        pm = player.GetComponent<PlayerMovement>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player" && other.tag != "Ignore" && other.tag != "Zombie")
        {
            rb.AddForce(player.transform.up * stepHieght, ForceMode.Impulse);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player" && other.tag != "Ignore" && other.tag != "Zombie")
        {
            float axisV = Input.GetAxisRaw("Vertical");
            float axisH = Input.GetAxisRaw("Horizontal");

            rb.AddForce(player.transform.forward * axisV * pm.playerSpeed, ForceMode.Impulse);
            rb.AddForce(player.transform.right * axisH * pm.playerSpeed, ForceMode.Impulse);
        }
    }
}
