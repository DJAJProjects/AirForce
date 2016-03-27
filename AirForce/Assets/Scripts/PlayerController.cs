using System;
using UnityEngine;
using System.Collections;

[Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
   
}

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public GameObject shot;
    public GameController gc;
    public Transform shotSpawn;
    public float fireRate;
    public float tilt;
    public float rotationSpeed;

    private float nextFire;
    private float oldRotX;
    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        oldRotX = transform.rotation.x;

        GameObject obj = GameObject.FindWithTag("GameController");
        if (obj != null)
        {
            gc = obj.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("Nie znalezniono 'game controller");
        }
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
	void FixedUpdate ()
	{
        if (gc.isGameOver()) return;

        // make the ship move at a constant forward speed.
        rb.velocity = transform.forward * speed;
        float x = Input.GetAxis("Vertical");
        float y  = Input.GetAxis("Horizontal");
        rb.AddRelativeTorque(x * rotationSpeed * Time.deltaTime, y * rotationSpeed * Time.deltaTime, 0);
        rb.AddRelativeTorque(y * (-1) * rotationSpeed * Time.deltaTime * Vector3.forward); 


    }

}
