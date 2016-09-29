using UnityEngine;
using System.Collections;

public class charControl : MonoBehaviour {
    CharacterController cc;
    float jumpTimer;
    public float moveSpeed;
    public bool sprinting;
    public bool fatigued;

    public float stamina;    
    public float sprintTimer;
    public float recoveryRate;
    public float recoveryTimer;
    
	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();
        
	}
	//to do - head bob - more headbob on sprint. fatigue mechanic.
	// Update is called once per frame
    //use fixedupdate for rigidbody stuff
	void Update () {      
        
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        if (Input.GetKeyDown(KeyCode.LeftShift) && fatigued == false)
        {
            sprinting = true;
            stamina = Time.time + 3f;
        }
        
        if (Input.GetKeyUp(KeyCode.LeftShift)) 
        {
            sprinting = false;
            stamina = 0f;
        }

        //set movespeed depending on player state
        if (sprinting)
        {
            moveSpeed = 12f;
            sprintTimer = Time.time;

            if (sprintTimer > stamina)
            {
                sprinting = false;
                fatigued = true;
                recoveryRate = Time.time + 5f;
                sprintTimer = 0;
            }
        }

        if (fatigued)
        {
            moveSpeed = 3f;
            PlayerPrefs.SetInt("wasFatigued", 1);
            recoveryTimer = Time.time;
            sprinting = false;

            if (recoveryTimer > recoveryRate)
            {
                fatigued = false;
                recoveryTimer = 0;
            }
        }

        if (sprinting == false && fatigued == false)
        {
            moveSpeed = 5f;
        }

        cc.SimpleMove(transform.forward * inputY * moveSpeed);
        cc.SimpleMove(transform.right * inputX * moveSpeed);
        transform.Rotate(0f, mouseX * 180f * Time.deltaTime, 0f);
        //transform.Rotate(mouseY * -180f * Time.deltaTime, 0f, 0f);
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpTimer = Time.time + 1f;
        }

        if (Time.time < jumpTimer)
        {
            cc.Move(Vector3.up * .1f);
        }*/
	}
}
