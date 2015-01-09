using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Classes;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject hazard;
    public GameObject gameOverTrigger;

    public Text scoreText;
    public Text gameOverText;
    public Text restartGameText;

    public int hazardCount;
    public float startWait;
    public Vector3 spawnValues;
    public float timeToProtect;

    private int score = 0;
    private bool isGameOver = false;
    private LevelManager levelManager;


    public void Start()
    {
        score = 0;
        UpdateScore();
        gameOverText.gameObject.SetActive(false);
        restartGameText.gameObject.SetActive(false);
        Instantiate(player, Vector3.zero, Quaternion.identity);
        StartCoroutine(SpawnWaves());
    }

    IEnumerator SpawnWaves()
    {
        levelManager = gameObject.AddComponent<LevelManager>();
        levelManager.InitLevel();

        yield return new WaitForSeconds(startWait);
        Vector3 spawnPoint = spawnValues;
        levelManager.SpawnWave(hazard, ref spawnPoint);

        Vector3 spawnTrigger = new Vector3(0, 0, spawnPoint.z + 2);
        Instantiate(gameOverTrigger, spawnTrigger, Quaternion.identity);
    }

    public void AddScore(int newScore)
    {
        score += newScore;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartGameText.gameObject.SetActive(true);
        isGameOver = true;
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.R) && isGameOver)
        {
            Restart();
        }
    }

    private void Restart()
    {
        DestroyAllAsteroid();
        isGameOver = false;
        Start();
        StartCoroutine(ProtectPlayerByShield(timeToProtect));
    }

    public IEnumerator ProtectPlayerByShield(float timeToProtect)
    {
        PlayerIsProtected = true;
        yield return new WaitForSeconds(timeToProtect);
        PlayerIsProtected = false;
    }

    private void DestroyAllAsteroid()
    {
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        int size = asteroids.Length;
        for (int i = 0; i < size; i++)
        {
            if (asteroids[i] != null)
            {
                Destroy(asteroids[i]);
            }
        }
    }

    public bool PlayerIsProtected { get; set; }
}
