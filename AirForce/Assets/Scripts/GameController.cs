using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject [] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait, startWait, waveWait;
    public GameObject sceneLight;

    private int score;
    public GUIText lifeText;
    public GUIText restartText;
    public GUIText gameOverText;
    public GUIText ammoText;
    public GUIText energyText;

    private bool gameOver;
    private bool restart;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        sceneLight.GetComponent<Light>().enabled = false;

        // StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        UpdateText();
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    public bool isGameOver() { return gameOver; }

    public void ReverseDirection(GameObject clone)
    {
       Quaternion rot =  clone.transform.rotation;
       clone.transform.rotation = new Quaternion(rot.x,0,rot.z,rot.w);
       clone.GetComponent<Mover>().speed = -5;

    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        
    }
    public void UpdateText()
    {
        lifeText.text = "Life: " + playerController.getLife();
        ammoText.text = "Ammo: " + playerController.getAmmo();
        energyText.text = "Energy: " + playerController.getEnergy();

    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.text = "Game Over";
        Time.timeScale = 0;
    }

}
