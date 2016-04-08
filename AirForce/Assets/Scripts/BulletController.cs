using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{

    public GameObject explosion;
    public float destruction;

    private GameController gc;


    // Use this for initialization
    void Start()
    {
        GameObject obj = GameObject.FindWithTag("GameController");
        gc = obj.GetComponent("GameController") as GameController;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        BasicObject bo = other.GetComponent("BasicObject") as BasicObject;
        if (bo == null) return;
        bo.shooted(destruction);
        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(this.gameObject);

    }
}
