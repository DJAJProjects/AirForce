using System;
using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour
{
   
    public float speed;
    public GameObject shot;
    public Transform shotSpawn;
    public GameObject explosionOnDeath;
    public float fireRate;
    public float tilt;
    public float rotationSpeed;

    private Rigidbody rb;
    private float nextFire;
    private GameController gc;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject obj = GameObject.FindWithTag("GameController");
        gc = obj.GetComponent("GameController") as GameController;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            GetComponent<AudioSource>().Play();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (gc.isGameOver()) return;

        // make the ship move at a constant forward speed.
        rb.velocity = transform.forward * speed;
        float x = Input.GetAxis("Vertical");
        float y = Input.GetAxis("Horizontal");
        rb.AddRelativeTorque(x * rotationSpeed * Time.deltaTime, y * rotationSpeed * Time.deltaTime, 0);
        rb.AddRelativeTorque(y * (-1) * rotationSpeed * Time.deltaTime * Vector3.forward);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Terrain"))
        {
            Instantiate(explosionOnDeath, transform.position, transform.rotation);
            gc.GameOver();
        }
    }
}
