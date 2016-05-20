using System;
using UnityEngine;
using System.Collections;


public class PlayerController : BasicObject
{
    public float initialLife;
    public GameObject explosionOnDeath;
    public float tilt;
    public float initialSpeed;
    public float rotationSpeed;
    public float mouseRotationSpeed;
    public float onlyHorizontalRotationSpeed;
    public float minSpeed = 5;
    public float maxSpeed = 300;

    private float speed;
    private float speedBonusTime = 0;
    private float currentSpeedBonus = 0;
    private bool speedBonus = false;
    private float life;
    private Rigidbody rb;
    private GameController gc;
    private WeaponController wc;
    private LightsController lc;


    public void ammoChange(int value)
    {
        wc.ammunition += value;
    }

    public override void shooted(float destruction)
    {
        lifeChange(-destruction);
    }

    public override void crushed()
    {
        Instantiate(explosionOnDeath, transform.position, transform.rotation);
        gc.GameOver();
    }

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
        else if (speed > maxSpeed)
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
    
    public int getAmmo() { return wc.ammunition; }

    public float getLife() { return life; }

    public double getEnergy() { return lc.getEnergy(); }

    public void energyChange(float value)
    {
        lc.energyChange(value);
    }

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject obj = GameObject.FindWithTag("GameController");
        gc = obj.GetComponent("GameController") as GameController;
        wc = this.GetComponent("WeaponController") as WeaponController;
        lc = this.GetComponentInChildren(typeof(LightsController)) as LightsController;

        speed = initialSpeed;
        life = initialLife;
    }

    void Update()
    {
        if (gc.isGameOver()) return;

        // Shooting 
        if (Input.GetKey(KeyCode.Space))
        {
            wc.Fire();
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

          float y2 = Input.GetAxis("Mouse X");

          rb.AddRelativeTorque(x * rotationSpeed * Time.deltaTime, y * rotationSpeed * Time.deltaTime, 0);
          rb.AddRelativeTorque(y * (-1) * rotationSpeed * Time.deltaTime * Vector3.forward);

          rb.AddRelativeTorque(y2 * (-1) * mouseRotationSpeed * Time.deltaTime * Vector3.forward);


    }

    void OnTriggerEnter(Collider other)
    {
    }

    
}
