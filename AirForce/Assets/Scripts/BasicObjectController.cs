using UnityEngine;
using System.Collections;

public class BasicObjectController : BasicObject {

    public bool destroyOnShot;
    public bool destroyOnCrush;
    public bool invokeCrush;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        BasicObject bo = other.GetComponent("BasicObject") as BasicObject;

        if (bo == null) return;

        if (invokeCrush) bo.crushed();
    }

    public override void crushed()
    {
        if(destroyOnCrush)
            DestroyObject(this.gameObject);
    }
    public override void shooted(float destruction)
    {
        if (destroyOnShot)
            DestroyObject(this.gameObject);
    }
}
