using System.Collections;
using UnityEngine;

namespace Assets.Classes
{
    public class Level1 : Level
    {
        protected override void OnSpawnWave(GameObject hazard, ref Vector3 spawnValues)
        {
            // A line
            Vector3 spawnPosition = spawnValues;
            spawnPosition.x = -spawnPosition.x;
            while (spawnPosition.x <= spawnValues.x)
            {
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                spawnPosition.x += 2;
            }

            // 2 lines
            spawnPosition = spawnValues;
            spawnPosition.x = -spawnPosition.x;
            spawnPosition.z = spawnValues.z + 5;
            while (spawnPosition.x <= spawnValues.x)
            {
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                spawnPosition.z += 2;
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                spawnPosition.x += 2;
            }

            // 3 lines
            spawnPosition = spawnValues;
            spawnPosition.x = -spawnPosition.x;
            while (spawnPosition.x <= spawnValues.x)
            {
                spawnPosition.z = spawnValues.z + 25;
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                spawnPosition.z += 3;
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                spawnPosition.z += 3;
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                spawnPosition.x += 2;
            }
            spawnValues.z = spawnPosition.z + 2;
        }

        public override void NextLevel()
        {
            //Manager.SetLevel(null);
            Manager.SetLevel(gameObject.AddComponent<Level2>());
        }
    }
}
