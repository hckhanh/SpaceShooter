using System;
using System.Collections;
using UnityEngine;

namespace Assets.Classes
{
    public class Level3 : Level
    {
        public override IEnumerator SpawnWave(GameObject hazard, Vector3 spawnValues)
        {
            //   throw new NotImplementedException();
            isEnded = true;
            return null;
        }

        public override void NextLevel(LevelManager levelManager)
        {
            /// This is the max level
        }
    }
}
