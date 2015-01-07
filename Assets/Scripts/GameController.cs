﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Assets.Classes;

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
        while (true)
        {
            Level level = levelManager.GetLevel();
            StartCoroutine(level.SpawnWave(hazard, spawnValues));
            levelManager.NextLevel();

            if (levelManager.IsEnded())
                break;

            yield return new WaitForSeconds(waveWait);
        }
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
        StartCoroutine(ProtectPlayerByShield(timeToProtect));
    }

    public IEnumerator ProtectPlayerByShield(float timeToProtect)
    {
        PlayerIsProtected = true;
        yield return new WaitForSeconds(timeToProtect);
        PlayerIsProtected = false;
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

    public bool PlayerIsProtected { get; set; }
}
