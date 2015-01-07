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

        public void InitLevel()
        {
            currentLevel = gameObject.AddComponent<Level1>();
        }

        public void NextLevel()
        {
            currentLevel.NextLevel(this);
        }

        public void SetLevel(Level level)
        {
            currentLevel = level;
        }

        public Level GetLevel()
        {
            return currentLevel;
        }

        public bool IsEnded()
        {
            return currentLevel.IsEnded();
        }
    }
}
