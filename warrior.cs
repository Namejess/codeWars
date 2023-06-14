using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace codeWars
{
    public class Warrior
    {
        // Business Rules    
        private int level = 1;
        private int experience = 100;
        private string rank = "Pushover";
        private readonly List<string> ranks = new List<string> { "Pushover", "Novice", "Fighter", "Warrior", "Veteran", "Sage", "Elite", "Conqueror", "Champion", "Master", "Greatest" };
        private readonly List<string> achievements = new List<string>();

        // Methods
        public int Level()
        {
            return this.level;
        }

        public int Experience()
        {
            return this.experience;
        }

        public string Rank()
        {
            return this.rank;
        }

        public List<string> Achievements()
        {
            return this.achievements;
        }

        public string Training(string[] trainingData)
        {
            string training = trainingData[0];
            int exper = int.Parse(trainingData[1].ToString());
            int lvl = int.Parse(trainingData[2].ToString());
            this.experience += exper;
            while (this.experience >= 100 && this.level < 100)
            {
                this.experience -= 100;
                this.level++;
                if (this.level % 10 == 0)
                {
                    this.rank = ranks[this.level / 10 - 1];
                }
            }

            if (this.level == 100)
            {
                this.experience = 10000;
                this.rank = "Greatest";
            }

            this.achievements.Add(training);
            return training;
        }

        public string Battle(int enemyLevel)
        {
            if (enemyLevel < 1 || enemyLevel > 100)
            {
                return "Invalid level";
            }

            int diff = enemyLevel - level;
            int expEarned = 0;

            if (diff == 0)
            {
                expEarned = 10;
            }
            else if (diff == -1)
            {
                expEarned = 5;
            }
            else if (diff >= -2)
            {
                expEarned = 0;
            }

            experience += expEarned;

            if (level < 100)
            {
                while (experience >= 100)
                {
                    level++;
                    experience -= 100;

                    if (level % 10 == 0 && Array.IndexOf(ranks.ToArray(), rank) + 1 < ranks.Count)
                    {
                        rank = ranks[Array.IndexOf(ranks.ToArray(), rank) + 1];
                    }
                }
            }
            else
            {
                experience = 10000;
            }

            if (level == 100)
            {
                rank = "Greatest";
            }

            if (expEarned > 0)
            {
                this.achievements.Add("Defeated Chuck Norris");
            }

            if (expEarned == 10)
            {
                return "Easy fight";
            }

            if (expEarned == 5)
            {
                return "A good fight";
            }

            return "An intense fight";
        }
    }

}
