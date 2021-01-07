using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class Leaderboard
    {
        public Dictionary<Trigger, List<Marble>> RankPerTrigger = new Dictionary<Trigger, List<Marble>>();

        public void MarbleReachedCheckPoint(Trigger trigger, Marble marble)
        {
            if (!RankPerTrigger.ContainsKey(trigger))
            {
                RankPerTrigger[trigger] = new List<Marble>();
            }
            
            RankPerTrigger[trigger].Add(marble);
            marble.CurrentPos = RankPerTrigger[trigger].Count;
            UpdateLeaderboardUI(trigger);
        }

        private void UpdateLeaderboardUI(Trigger trigger)
        {
            ClearLeaderboard();
            GameObject leaderboardPanel = GameObject.Find("Leaderboard");
            
            List<Marble> marblesPerRank = RankPerTrigger[trigger];

            foreach (var marble in marblesPerRank)
            {
                ChangeTextUIForRank(marble.CurrentPos, marble.name);
            }
            
        }

        private void ClearLeaderboard()
        {
            GameObject.Find("First").GetComponent<Text>().text = "1.";
            GameObject.Find("Second").GetComponent<Text>().text = "2.";
            GameObject.Find("Third").GetComponent<Text>().text = "3.";
            GameObject.Find("Fourth").GetComponent<Text>().text = "4.";
        }

        [CanBeNull]
        private Text ChangeTextUIForRank(int rank, string text)
        {
            switch (rank)
            {
                case 1:
                    GameObject.Find("First").GetComponent<Text>().text += text;
                    break;
                case 2:
                    GameObject.Find("Second").GetComponent<Text>().text += text;
                    break;
                case 3:
                    GameObject.Find("Third").GetComponent<Text>().text += text;
                    break;
                case 4:
                    GameObject.Find("Fourth").GetComponent<Text>().text += text;
                    RankPerTrigger.Clear();
                    break;
                case 5:
                case 6:
                case 7:
                case 8:
                default:
                    break;
            }

            return null;
        }
    }
}