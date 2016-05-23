using UnityEngine;
using System.Collections;

public class EnemyTowerController : BasicObject {

    public Transform target;
    public GameObject turret;
    public GameObject destructionExplosion;
    private WeaponController turretWC;
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
        turretWC = turret.GetComponent<WeaponController>();
    }
	
	// Update is called once per frame
	void Update () {
        if (target != null)
        {
            turret.transform.LookAt(target);
            turretWC.Fire();
        }
    }
}
