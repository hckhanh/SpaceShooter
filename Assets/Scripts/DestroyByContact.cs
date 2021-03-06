﻿using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour
{
    public GameObject playerExplosion;
    public GameObject asteroidExplosion;
    private GameController gameController;
    public int scoreValues;

    public void Start()
    {
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject == null)
            Debug.LogError("Can not find GameController object");
        else
            gameController = gameControllerObject.GetComponent<GameController>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Boundary")
        {
            GameObject explosion = null;
            if (other.tag == "Player")
            {
                if (gameController.PlayerIsProtected)
                    return;

                gameController.GameOver();
                explosion = playerExplosion;
            }
            else
            {
                explosion = asteroidExplosion;
                if (gameController != null && other.tag == "Bolt")
                    gameController.AddScore(scoreValues);
            }

            Object explosionObj = Instantiate(explosion, transform.position, transform.rotation);

            Destroy(explosionObj, 2);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
