﻿using System;
using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour
{
    public float initialLife;
    public GameObject shot;
    public Transform shotSpawn;
    public GameObject explosionOnDeath;
    public float fireRate;
    public float tilt;
    public float initialSpeed;
    public float rotationSpeed;
    public float minSpeed = 5;
    public float maxSpeed = 300;

    private float speed;
    private float speedBonusTime = 0;
    private float currentSpeedBonus = 0;
    private bool speedBonus = false;
    private float life;
    private Rigidbody rb;
    private float nextFire;
    private GameController gc;


    public void speedChange(float value, float _speedBonusTime)
    {
        speed += value;
        currentSpeedBonus += value;
        speedBonusTime = _speedBonusTime;
        speedBonus = true;

        if (speed <= minSpeed)
        {
            speed = minSpeed;
        }
        else if(speed > maxSpeed)
        {
            speed = maxSpeed;
        }
    }

    public void lifeChange(float value)
    {
        life += value;
        if (life <= 0)
        {
            gc.GameOver();
        }
    }

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject obj = GameObject.FindWithTag("GameController");
        gc = obj.GetComponent("GameController") as GameController;

        speed = initialSpeed;
        life = initialLife;
    }

    void Update()
    {
        if (gc.isGameOver()) return;

        // Shooting 
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }

        //SpeedBonus
        if(speedBonusTime > 0)
        {
            speedBonusTime -= Time.deltaTime;
            if(speedBonusTime <= 0)
            {
                speedBonusTime = 0;
                speedBonus = false;
                speed -= currentSpeedBonus;
                currentSpeedBonus = 0;
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gc.isGameOver()) return;

        // Flight physics
        rb.velocity = transform.forward * speed;
        float x = Input.GetAxis("Vertical");
        float y = Input.GetAxis("Horizontal");
        rb.AddRelativeTorque(x * rotationSpeed * Time.deltaTime, y * rotationSpeed * Time.deltaTime, 0);
        rb.AddRelativeTorque(y * (-1) * rotationSpeed * Time.deltaTime * Vector3.forward);
    }

    void OnTriggerEnter(Collider other)
    {
        Properties p = other.GetComponent("Properties") as Properties;

        if (p.crushCollider)
        {
            Instantiate(explosionOnDeath, transform.position, transform.rotation);
            gc.GameOver();
        }
    }
}
