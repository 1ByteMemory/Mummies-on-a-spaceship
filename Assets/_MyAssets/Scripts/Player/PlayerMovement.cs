using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float playerSpeed = 5f;
    public float lookSpeed = 5f;

    Rigidbody rb;
    Vector2 rotation = new Vector2(0, 0);

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float fAxis = Input.GetAxis("Horizontal");
        float sAxis = Input.GetAxis("Vertical");
        

        

        //
        rotation.y += Input.GetAxis("Mouse X");
        rotation.x += -Input.GetAxis("Mouse Y");
        transform.eulerAngles = (Vector2)rotation * lookSpeed;

    }
}
