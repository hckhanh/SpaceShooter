using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Classes
{
    public class LevelManager : MonoBehaviour
    {
        private Level currentLevel;
        public GameController Controller { get; set; }

        public void InitLevel()
        {
            currentLevel = gameObject.AddComponent<Level1>();
            currentLevel.Manager = this;
        }

        public void SetLevel(Level level)
        {
            currentLevel = level;
            if (level != null)
                currentLevel.Manager = this;
        }

        public Level GetLevel()
        {
            return currentLevel;
        }

        public void SpawnWave(GameObject hazard, ref Vector3 spawnValues)
        {
            if (currentLevel != null)
                currentLevel.SpawnWave(hazard, ref spawnValues);
        }
    }
}
