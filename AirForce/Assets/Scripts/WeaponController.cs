﻿using UnityEngine;
using System.Collections;

public class WeaponController : MonoBehaviour
{

    private AudioSource audioSource;
    public AudioClip [] clips;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;
	// Use this for initialization
	void Start ()
	{
        audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Fire", delay, fireRate);
	}

    void Fire()
    {
        Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        AudioClip clip = clips[Random.Range(0, clips.Length-1)];
        audioSource.clip = clip;
        audioSource.Play();
    }
}