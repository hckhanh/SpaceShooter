using System.Collections;
using UnityEngine;

namespace Assets.Classes
{
    public class Level1 : Level
    {
        public override IEnumerator SpawnWave(GameObject hazard, Vector3 spawnValues)
        {
            // A line
            float spawnX = -spawnValues.x;
            while (spawnX <= spawnValues.x)
            {
                Vector3 spawnPosition = spawnValues;
                spawnPosition.x = spawnX;
                spawnX += 2;
                Instantiate(hazard, spawnPosition, Quaternion.identity);
            }
            yield return new WaitForSeconds(1.5f);

            // 2 lines
            spawnX = -spawnValues.x;
            while (spawnX <= spawnValues.x)
            {
                Vector3 spawnPosition = spawnValues;
                spawnPosition.x = spawnX;
                spawnX += 2;
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                spawnPosition.z += 2;
                Instantiate(hazard, spawnPosition, Quaternion.identity);
            }
            yield return new WaitForSeconds(1.5f);

            // 3 lines
            spawnX = -spawnValues.x;
            while (spawnX <= spawnValues.x)
            {
                Vector3 spawnPosition = spawnValues;
                spawnPosition.x = spawnX;
                spawnX += 2;
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                spawnPosition.z += 2;
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                spawnPosition.z += 2;
                Instantiate(hazard, spawnPosition, Quaternion.identity);
            }
            yield return new WaitForSeconds(3.0f);
        }

        public override void NextLevel(LevelManager levelManager)
        {
            levelManager.SetLevel(gameObject.AddComponent<Level2>());
        }
    }
}
