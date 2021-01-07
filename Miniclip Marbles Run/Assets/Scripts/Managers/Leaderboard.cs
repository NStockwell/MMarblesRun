using System.Collections.Generic;
using JetBrains.Annotations;

namespace Managers
{
    public class Leaderboard
    {
        public Dictionary<Trigger, List<Marble>> RankPerTrigger = new Dictionary<Trigger, List<Marble>>();
        
        [CanBeNull]
        public List<Marble> GetLeaderboardForTrigger(Trigger trigger) {
            if (!RankPerTrigger.ContainsKey(trigger))
            {
                return null;
            }

            return RankPerTrigger[trigger];
        }

        public void MarbleReachedCheckPoint(Trigger trigger, Marble marble)
        {
            if (!RankPerTrigger.ContainsKey(trigger))
            {
                RankPerTrigger[trigger] = new List<Marble>();
            }
            
            RankPerTrigger[trigger].Add(marble);
        }
    }
}