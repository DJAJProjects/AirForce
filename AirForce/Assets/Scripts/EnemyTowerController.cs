using UnityEngine;
using System.Collections;

public class EnemyTowerController : BasicObject {

    public Transform target;
    public GameObject destructionExplosion;
    public float life;

    public override void shooted(float destruction)
    {
        life -= destruction;
        if(life < 0)
        {
            Instantiate(destructionExplosion, transform.position, transform.rotation);
            DestroyObject(this.gameObject);
        }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (target != null)
        {
            transform.LookAt(target);
        }
    }
}
