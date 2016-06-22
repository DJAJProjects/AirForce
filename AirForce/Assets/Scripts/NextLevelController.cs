using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class NextLevelController : MonoBehaviour
{

    public static readonly string nextLevelName = "Scene01";
    //TODO dodać efekt czząsteczkowy
    //public GameObject explosion;
    public GameObject nextLevelText;
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Extra");

       // explosion.SetActive(true);
        nextLevelText.SetActive(true);
        Invoke("LoadLevel", 0.5f);
    }

    void LoadLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }
}
