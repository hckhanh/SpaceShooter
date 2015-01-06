using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject player;
    public GameObject hazard;
    public GameObject asteroidExplosion;

    public Text scoreText;
    public Text gameOverText;
    public Text restartGameText;

    public int hazardCount;
    public float startWait;
    public float hazardWait;
    public float waveWait;
    public Vector3 spawnValues;
    public float delayBeforeDestroy;

    private int score = 0;
    private bool isGameOver = false;


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
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                SpawnWave();
                if (isGameOver)
                    break;
                yield return new WaitForSeconds(hazardWait);
            }
            if (isGameOver)
                break;
            yield return new WaitForSeconds(waveWait);
        }
    }

    void SpawnWave()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(hazard, spawnPosition, spawnRotation);
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
        StartCoroutine(DestroyAllAsteroid());
        isGameOver = false;
        Start();
    }

    private IEnumerator DestroyAllAsteroid()
    {
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("Asteroid");
        int size = asteroids.Length;
        for (int i = 0; i < size; i++)
        {
            if (asteroids[i] != null)
            {
                Object explosionObj = Instantiate(asteroidExplosion, asteroids[i].transform.position, asteroids[i].transform.rotation);

                Destroy(asteroids[i]);
                Destroy(explosionObj, 2);
            }
            yield return new WaitForSeconds(delayBeforeDestroy);
        }
    }
}
