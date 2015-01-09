using System.Collections;
using UnityEngine;

namespace Assets.Classes
{
    public class Level2 : Level
    {
        protected override void OnSpawnWave(GameObject hazard, ref Vector3 spawnValues)
        {
            // A line
            Vector3 spawnPosition = spawnValues;
            spawnPosition.z += 10;
            for (int i = 0; i < 50; i++)
            {
                spawnPosition.x = Random.Range(-spawnValues.x, spawnValues.x);
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                spawnPosition.z += 2;
            }
            spawnValues.z = spawnPosition.z + 2;
        }

        public override void NextLevel()
        {
            Manager.SetLevel(gameObject.AddComponent<Level3>());
        }
    }
}
