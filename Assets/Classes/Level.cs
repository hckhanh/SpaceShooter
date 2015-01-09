using Assets.Classes;
using System.Collections;
using UnityEngine;

public abstract class Level : MonoBehaviour
{
    public LevelManager Manager { get; set; }

    public abstract void NextLevel();

    protected abstract void OnSpawnWave(GameObject hazard, ref Vector3 spawnValues);

    public void SpawnWave(GameObject hazard, ref Vector3 spawnValues)
    {
        OnSpawnWave(hazard, ref spawnValues);
        NextLevel();
        Manager.SpawnWave(hazard, ref spawnValues);
    }
}
