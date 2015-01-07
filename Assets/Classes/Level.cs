using Assets.Classes;
using System.Collections;
using UnityEngine;

public abstract class Level : MonoBehaviour
{
    protected bool isEnded = false;

    public abstract IEnumerator SpawnWave(GameObject hazard, Vector3 spawnValues);

    public abstract void NextLevel(LevelManager levelManager);

    public bool IsEnded()
    {
        return isEnded;
    }

    public GameObject GetHazard(GameObject[] hazards)
    {
        return hazards[Random.Range(0, hazards.Length)];
    }
}
