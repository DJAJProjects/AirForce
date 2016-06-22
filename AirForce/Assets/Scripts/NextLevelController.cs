using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextLevelController : MonoBehaviour
{

    public static readonly string nextLevelName = "Scene01";

    void Start()
    {
        nextLevelText.SetActive(false);
    }
    //TODO dodać efekt czząsteczkowy
    //public GameObject explosion;
    public GameObject nextLevelText;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("Extra");
            nextLevelText.SetActive(true);
            Invoke("LoadLevel", 0.5f);
            //Application.LoadLevel(nextLevelName);
        }
        

       // explosion.SetActive(true);
       
        //Invoke("LoadLevel", 0.5f);
    }

    void LoadLevel()
    {
        //nextLevelText.SetActive(true);
        SceneManager.LoadScene(nextLevelName);
    }
}
    