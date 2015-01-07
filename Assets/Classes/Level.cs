using UnityEngine;

public abstract class Level : MonoBehaviour
{
    public abstract void SpawnWave(GameObject hazard, Vector3 spawnValues);
}
