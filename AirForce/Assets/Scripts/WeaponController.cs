using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{

    private AudioSource audioSource;
    public AudioClip[] clips;
    public Transform shotSpawn;
    public GameObject shot;
    public int ammunition;
    public float fireRate;

    private float nextFire;


    // Use this for initialization
    void Start ()
	{
        audioSource = GetComponent<AudioSource>();
        nextFire = 0;
    }

    public void Fire()
    {
        if(ammunition > 0 && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            AudioClip clip = clips[Random.Range(0, clips.Length - 1)];
            audioSource.clip = clip;
            audioSource.Play();
            ammunition--;
        }
    }
}
