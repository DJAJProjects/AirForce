using UnityEngine;
using System.Collections;

public class LightsController : MonoBehaviour {

    private bool turnedOn;

    private Light lights = null;

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
            else
            {
                turnedOn = true;
                lights.enabled = true;
            }
        }
	}
}
