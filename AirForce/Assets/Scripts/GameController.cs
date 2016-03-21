using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class GameController : MonoBehaviour
{

    public GameObject [] hazards;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait, startWait, waveWait;

    private int score;
    public GUIText scoreText;
    public GUIText restartText;
    public GUIText gameOverText;

    private bool gameOver;
    private bool restart;

    void Start()
    {
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                GameObject hazard = hazards[Random.Range(0, hazards.Length)];
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
               GameObject clone =Instantiate(hazard, spawnPosition, spawnRotation) as GameObject;
                clone.transform.SetParent(null);
                ReverseDirection(clone);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                restartText.text = "Press 'R' to restart";
                restart = true;
                break;
            }
        }
    }

    public void ReverseDirection(GameObject clone)
    {
       Quaternion rot =  clone.transform.rotation;
       clone.transform.rotation = new Quaternion(rot.x,0,rot.z,rot.w);
       clone.GetComponent<Mover>().speed = -5;

    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    public void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOver = true;
        gameOverText.text = "Game Over"; 
    }
}
