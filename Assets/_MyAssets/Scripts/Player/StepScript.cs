using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepScript : MonoBehaviour {
    
    public float stepHieght = 1;
    public float stepForward = 1;

    Rigidbody rb;



    private void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "Player" && other.tag != "Ignore")
        {
            rb.AddForce(transform.up * stepHieght, ForceMode.Impulse);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag != "Player" && other.tag != "Ignore")
        {
            rb.AddForce(transform.forward * stepForward, ForceMode.Impulse);
        }
    }
}
