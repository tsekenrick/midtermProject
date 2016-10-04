using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class charControl : MonoBehaviour {
    CharacterController cc;
    float jumpTimer;
    public float moveSpeed;
    public bool sprinting;
    public bool fatigued;

    public float staminaCap;
    public float stamina;    
    public float sprintTimer;
    public float recoveryCap;
    public float recoveryRate;
    public float recoveryTimer;

    public static int wasFatigueds1;
    public static int wasFatigueds2;
	// Use this for initialization
	void Start () {
        cc = GetComponent<CharacterController>();
        staminaCap = 3f;
        stamina = 3f;
        recoveryCap = 5f;
        recoveryRate = 5f;

        if (wasFatigueds1 == 1)
        {
            stamina += 2;
        }

        if (wasFatigueds2 == 1)
        {
            stamina += 2;
        }
        

	}
	//to do - head bob - more headbob on sprint. fatigue mechanic.
	// Update is called once per frame
    //use fixedupdate for rigidbody stuff
	void Update () {      
        
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        if (Input.GetKey(KeyCode.LeftShift) && fatigued == false)
        {
            sprinting = true;
            stamina -= Time.deltaTime;
            //stamina = Time.time + 3f;
        }
        
        if (Input.GetKey(KeyCode.LeftShift) == false) 
        {
            sprinting = false;
            if (stamina < staminaCap)
            {
                stamina += Time.deltaTime;
            }
            
        }

        //set movespeed depending on player state
        if (sprinting)
        {
            moveSpeed = 12f;
            //sprintTimer = Time.time;

            if (stamina <= 0)
            {
                sprinting = false;
                fatigued = true;               
                //sprintTimer = 0;
            }
        }

        if (fatigued)
        {
            recoveryRate -= Time.deltaTime;
            moveSpeed = 3f;
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                //PlayerPrefs.SetInt("wasFatigued", 1);
                wasFatigueds1 = 1;
            }

            else if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                wasFatigueds2 = 1;
            }
            
            //recoveryTimer = Time.time;
            sprinting = false;

            if (recoveryRate <= 0)
            {
                fatigued = false;
                recoveryRate = recoveryCap;
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
