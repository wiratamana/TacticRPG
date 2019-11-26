using UnityEngine;
using System.Collections;

namespace TacticRPG
{
    [System.Serializable]
    public class Experience
    {
        public int currentExperience { private set; get; }
        public int nextExperience { private set; get; }

        public void AddExperience(int experiencePoint, Status status)
        {
            var remainingExperiencecPoint = experiencePoint;

            while(remainingExperiencecPoint > 0)
            {
                currentExperience += remainingExperiencecPoint;

                if(currentExperience < nextExperience)
                {
                    break;
                }

                remainingExperiencecPoint = currentExperience - nextExperience;
                currentExperience = nextExperience;
                nextExperience = 200 + (status.level.level * 100);

                status.level.LevelUp();
            }
        }
    }
}
