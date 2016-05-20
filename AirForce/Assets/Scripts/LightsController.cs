using UnityEngine;
using System.Collections;

public class LightsController : MonoBehaviour {

    public float energyLoseRate = (float)0.5;
    public float initialEnergy;

    private Light lights = null;
    private float energy = 100;

    public float getEnergy() { return energy; }

	// Use this for initialization
	void Start () {
        lights = this.GetComponent<Light>();
        energy = initialEnergy;
    }

    public void energyChange(float value)
    {
        energy += value;
        if (energy <= 0 && lights.enabled)
        {
            lights.enabled = false;
            energy = 0;
        }
        else if (!lights.enabled && energy > 0)
        {
            lights.enabled = true;
        }
    }

    // Update is called once per frame
    void Update () {
       
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (lights.enabled) lights.enabled = false;
            else if(energy > 0) lights.enabled = true;

        }
        if (lights.enabled)
        {
            energyChange(energyLoseRate*Time.deltaTime *(-1));
        }
    }
}
