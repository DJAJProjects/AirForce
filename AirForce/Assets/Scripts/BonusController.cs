using UnityEngine;
using System.Collections;

public enum BonusType {score, lifeBonus, speedBonus, ammoBonus, energyBonus};
public enum BonusEvent { destruction, collision};

public class BonusController : BasicObjectController
{
    public BonusType bonusType;
    public BonusEvent bonusEvent;
    public float bonusValue;
    public float timeRate;

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
        if (bonusEvent != BonusEvent.collision) return;

        PlayerController player = other.GetComponent("PlayerController") as PlayerController;

        if (this.bonusType == BonusType.speedBonus)
        {
            player.speedChange(bonusValue, timeRate);
            DestroyObject(this.gameObject);
        }
        else if (this.bonusType == BonusType.lifeBonus)
        {
             player.lifeChange(bonusValue);
             DestroyObject(this.gameObject);
        }
        else if( this.bonusType == BonusType.ammoBonus)
        {
            player.ammoChange((int)bonusValue);
            DestroyObject(this.gameObject);
        }
        else if (this.bonusType == BonusType.energyBonus)
        {
            player.energyChange((float)bonusValue);
            DestroyObject(this.gameObject);
        }
    }

    void OnDestroy()
    {
        if (bonusEvent != BonusEvent.destruction) return;

        if(bonusType == BonusType.score)
        {
            gc.AddScore((int)bonusValue);
        }
    }
}
