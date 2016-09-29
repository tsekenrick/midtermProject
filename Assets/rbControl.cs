using UnityEngine;
using System.Collections;

public class rbControl : MonoBehaviour {
    Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per physics frame, at a fixed framerate
	void FixedUpdate () {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X"); //current horiz mouse speed
        float mouseY = Input.GetAxis("Mouse Y");

        rb.velocity = transform.forward * 10f * inputY
            + transform.right * 10f * inputX
            + Physics.gravity;
            
        Debug.Log(rb.velocity);

	}
}
