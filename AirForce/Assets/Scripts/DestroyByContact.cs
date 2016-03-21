using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
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
        if (other.CompareTag("Boundary") || other.CompareTag("Enemy"))
        {
            return;
        }
        if(explosion!=null)
            Instantiate(explosion, transform.position, transform.rotation);
        if (other.tag.Equals("Player"))
        {
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            gameController.GameOver();
        }
        else
            gameController.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
