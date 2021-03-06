﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class charControl : MonoBehaviour
{
    CharacterController cc;
    public float moveSpeed;
    public bool sprinting;
    public bool fatigued;
    public bool canMove;

    public float staminaCap;
    public float stamina;
    public float sprintTimer;
    public float recoveryCap;
    public float recoveryRate;
    public float recoveryTimer;
    public float regenRate;

    public static int wasFatigueds1;
    public static int wasFatigueds2;
    // Use this for initialization
    void Start()
    {
        cc = GetComponent<CharacterController>();
        regenRate = 1f;
        staminaCap = 3f;
        stamina = 3f;
        recoveryCap = 5f;
        recoveryRate = 5f;     

        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            canMove = false;
            //regenRate = 100f;
        }
        else
        {
            canMove = true;
        }

        if (wasFatigueds1 != 1) wasFatigueds1 = 0;
        if (wasFatigueds2 != 1) wasFatigueds2 = 0;

        if (wasFatigueds1 == 0 && (SceneManager.GetActiveScene().buildIndex == 1 || SceneManager.GetActiveScene().buildIndex == 2))
        {
            //stamina += 2;
            staminaCap += 1;
            regenRate = 2f;
        }

        if (wasFatigueds2 == 0 && (SceneManager.GetActiveScene().buildIndex == 2))
        {
            //stamina += 2;
            staminaCap += 1;
            regenRate = 4f;

        }

    }
    // Update is called once per frame
    //use fixedupdate for rigidbody stuff
    void Update()
    {
        //wasFatigueds1 = PlayerPrefs.GetInt("wasFatigueds1");
        //wasFatigueds2 = PlayerPrefs.GetInt("wasFatigueds2");

        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");




        if (Input.GetKey(KeyCode.LeftShift) && fatigued == false && canMove == true)
        {
            sprinting = true;
            stamina -= Time.deltaTime;
            //stamina = Time.time + 3f;
        }

        if (Input.GetKey(KeyCode.LeftShift) == false || fatigued == true)
        {
            sprinting = false;
            if (stamina < staminaCap)
            {
                stamina += regenRate * Time.deltaTime;
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
            recoveryRate -= regenRate * Time.deltaTime;
            moveSpeed = 3f;
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                wasFatigueds1 = 1;
            }

            else if (SceneManager.GetActiveScene().buildIndex == 1)
            {
                wasFatigueds2 = 1;
            }


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

        if (canMove)
        {
            cc.SimpleMove(transform.forward * inputY * moveSpeed);
            cc.SimpleMove(transform.right * inputX * moveSpeed);
            transform.Rotate(0f, mouseX * 180f * Time.deltaTime, 0f);
        }

        if (Input.GetKeyDown(KeyCode.R) && (SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 4))
        {
            SceneManager.LoadScene(0);
            wasFatigueds1 = 0;
            wasFatigueds2 = 0;
        }

    }
}
