using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    private GameController gameController;
    public int scoreValue;

    void Start()
    {
        GameObject obj = GameObject.FindWithTag("GameController");
        if (obj != null)
        {
            gameController = obj.GetComponent<GameController>();
        }
        else
        {
            Debug.Log("Nie znalezniono 'game controller");
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (isCollider(other))
        {
            Instantiate(explosion, transform.position, transform.rotation);
            if (this.tag.Equals("Player"))
            {
                gameController.GameOver();
            }
            else Destroy(this.gameObject);
        }

           // gameController.AddScore(scoreValue);
    }

    private bool isCollider(Collider other)
    {
        return other.tag.Equals("Terrain");
    }
}
