using System.Collections;
using UnityEngine;

namespace Assets.Classes
{
    public class Level2 : Level
    {
        public override IEnumerator SpawnWave(GameObject hazard, Vector3 spawnValues)
        {
            isEnded = true;

            // A line
            Vector3 spawnPosition = spawnValues;
            for (int i = 0; i < 50; i++)
            {
                spawnPosition.x = Random.Range(-spawnValues.x, spawnValues.x);
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                yield return new WaitForSeconds(0.4f);
            }

            yield return new WaitForSeconds(3.0f);
        }

        public override void NextLevel(LevelManager levelManager)
        {
            //levelManager.SetLevel(new Level3());
        }
    }
}
