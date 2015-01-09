using System;
using System.Collections;
using UnityEngine;

namespace Assets.Classes
{
    public class Level3 : Level
    {
        protected override void OnSpawnWave(GameObject hazard, ref Vector3 spawnValues)
        {
            for (int i = 0; i < 5; i++)
            {
                // A left-dash
                Vector3 spawnPosition = spawnValues;
                spawnPosition.x = -spawnPosition.x;
                //spawnPosition.z += 10;
                while (spawnPosition.x <= spawnValues.x)
                {
                    Instantiate(hazard, spawnPosition, Quaternion.identity);
                    spawnPosition.x += 2;
                    spawnPosition.z += 1;
                }
                
                spawnValues.z = spawnPosition.z + 2;

                // A right-dash
                spawnPosition = spawnValues;
                //spawnPosition.z += 2;
                while (spawnPosition.x >= -spawnValues.x)
                {
                    Instantiate(hazard, spawnPosition, Quaternion.identity);
                    spawnPosition.x -= 2;
                    spawnPosition.z += 1;
                }
                spawnValues.z = spawnPosition.z + 2;
            }
        }

        public override void NextLevel()
        {
            // This is the max level.
            Manager.SetLevel(null);
        }
    }
}
