using UnityEngine;
using System.Collections;

public class LightsController : MonoBehaviour {

    public double energyLoseRate = 0.5;

    private bool turnedOn;
    private Light lights = null;
    private double energy = 100;

	// Use this for initialization
	void Start () {
        turnedOn = false;
        lights = this.GetComponent<Light>();
    }
	
	// Update is called once per frame
	void Update () {
       
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (turnedOn)
            {
                turnedOn = false;
                lights.enabled = false;
            }
            else if(energy > 0)
            {
                turnedOn = true;
                lights.enabled = true;
            }
        }
        if (turnedOn)
        {
            energy -= energyLoseRate * Time.deltaTime;
            if(energy <= 0)
            {
                energy = 0;
                turnedOn = false;
                lights.enabled = false;
            }
        }
    }
}
