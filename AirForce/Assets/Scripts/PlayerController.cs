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
    public Boundary boundary;
    public float speed;
    public GameObject shot;
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

        /*  float rotY = Input.GetAxis("Mouse Y") * Time.deltaTime * rotationSpeed;
          float rotX = Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed;
          // float rotZ = rb.rotation.eulerAngles.z + (Input.GetAxis("Mouse X") - rb.rotation.eulerAngles.y) * Time.deltaTime * rotationSpeed * (-tilt);


          rb.rotation = Quaternion.Euler(rb.rotation.eulerAngles + new Vector3(rotY, rotX,0));

          rb.position = rb.position + transform.forward * speed * Time.deltaTime;*/


        // make the ship move at a constant forward speed.
        rb.velocity = transform.forward * speed;
        float x = Input.GetAxis("Vertical");
        float y  = Input.GetAxis("Horizontal");
        rb.AddRelativeTorque(x * rotationSpeed * Time.deltaTime, y * rotationSpeed * Time.deltaTime, 0);
        rb.AddRelativeTorque(y * (-1) * rotationSpeed * Time.deltaTime * Vector3.forward); // added this


    }

}
