using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codeWars
{
    public class Warrior
    {
        private int level = 1;
        private int experience = 100;
        private string rank = "Pushover";
        private List<string> achievements = new List<string>();

        public int Level
        {
            get { return level; }
        }

        public int Experience
        {
            get { return experience; }
        }

        public string Rank
        {
            get { return rank; }
        }

        public List<string> Achievements
        {
            get { return achievements; }
        }

        public string Battle(int enemyLevel)
        {
            if (enemyLevel < 1 || enemyLevel > 100)
            {
                return "Invalid level";
            }

            int levelDifference = enemyLevel - level;

            if (levelDifference >= 2)
            {
                return "No pain no gain";
            }
            else if (levelDifference == 1 || levelDifference == 0)
            {
                int experienceGain = 10 * levelDifference + 10;
                experience = Math.Min(10000, experience + experienceGain);
                UpdateLevelAndRank();
                return "A good fight";
            }
            else if (levelDifference <= -2)
            {
                return "Easy fight";
            }
            else if (levelDifference == -1)
            {
                experience = Math.Min(10000, experience + 5);
                UpdateLevelAndRank();
                return "A good fight";
            }
            else
            {
                return "Invalid level";
            }
        }

        public void Training(object[] trainingDetails)
        {
            string achievement = (string)trainingDetails[0];
            int experienceGain = (int)trainingDetails[1];
            experience = Math.Min(10000, experience + experienceGain);
            UpdateLevelAndRank();
            achievements.Add(achievement);
        }

        private void UpdateLevelAndRank()
        {
            int maxLevel = 100;

            if (level < maxLevel && experience >= level * 100)
            {
                level++;
                experience = level * 100;
            }

            int levelThreshold = 10;
            string[] ranks = new string[] { "Pushover", "Novice", "Fighter", "Warrior", "Veteran", "Sage", "Elite", "Conqueror", "Champion", "Master", "Greatest" };

            rank = ranks[(level - 1) / levelThreshold];
        }
    }


}
