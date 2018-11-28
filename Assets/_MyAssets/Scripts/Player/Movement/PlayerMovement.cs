using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float playerSpeed = 5f;
    public float playerJumpForce = 1f;
    public float lookSpeed = 5f;
    public GameObject fpsCamera;

    private bool jumpEnable = true;

    Rigidbody rb;
    //Vector2 rotation = new Vector2(0, 0);

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}

    // Update is called once per frame
    void Update()
    {

        //---MOVE---//
        
        float axisV = Input.GetAxisRaw("Vertical");                 // Forward/Backward Input
        float axisH = Input.GetAxisRaw("Horizontal");               // Left/Right Input

        //Vector3 move = new Vector3(axisH, 0, axisV);                // Converts the inputs to a movement Vector

        rb.AddForce(transform.forward * playerSpeed * axisV, ForceMode.Impulse);         // Adds force to the player with speed
        rb.AddForce(transform.right * playerSpeed * axisH, ForceMode.Impulse);

        //---JUMP---//
        
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(transform.up * playerJumpForce, ForceMode.Impulse);
        }


        //---LOOK---//

        Vector3 look = fpsCamera.transform.localEulerAngles;
        if (!Cursor.visible)
        {
            look.x -= Input.GetAxis("Mouse Y") * lookSpeed;
            look.y += Input.GetAxis("Mouse X") * lookSpeed;
        }
        //Debug.Log(look);

        
        transform.eulerAngles += new Vector3(0, look.y);
        
        // 85 and 275 angels on fpsCamera check.

        if (look.x > 85 && look.x < 180)
        {
            fpsCamera.transform.localEulerAngles = new Vector3(85, 0);
        }
        else if (look.x < 275 && look.x > 180)
        {
            fpsCamera.transform.localEulerAngles = new Vector3(275, 0);
        }
        else
        {
            fpsCamera.transform.localEulerAngles = new Vector3(look.x, 0);
        }
        //Debug.Log(fpsCamera.transform.localEulerAngles + ", " + look.x);
    }
}
