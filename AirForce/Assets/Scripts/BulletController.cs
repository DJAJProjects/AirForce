using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    public GameObject explosion;

    private GameController gc;

    // Use this for initialization
    void Start () {
        GameObject obj = GameObject.FindWithTag("GameController");
        gc = obj.GetComponent("GameController") as GameController;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        Properties p = other.GetComponent("Properties") as Properties;
        if (p == null) return;

        // Kill hit player
        if (p.player)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            gc.GameOver();
            Destroy(this.gameObject);
        }
        // Destroy hit objesct
        else if (p.destroyable)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

    }
}
