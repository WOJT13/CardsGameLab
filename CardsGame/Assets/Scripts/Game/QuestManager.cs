using Model;
using Quest;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// Manages quests and related data and actions.
    /// </summary>
    public class QuestManager : MonoBehaviour
    {

        /// <summary>
        /// Get and set the singleton instance of the QuestManager.
        /// </summary>
        public static QuestManager Instance { get; private set; }

        /// <summary>
        /// List of quests
        /// </summary>
        public List<Quest.Quest> quests = new List<Quest.Quest>();

        public List<Quest.Quest> availableQuests = new List<Quest.Quest>();

        /// <summary>
        /// Called on object initialization.
        /// </summary>
        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = this;
            }

            quests.Add(new Quest.Quest("COLOR!", "Connect 4 cards with the same color", new List<Quest.QuestRequirement>() { new Quest.FourCardsSameWithSymbolConnected() }, Quest.RewardType.Score, 5));
            quests.Add(new Quest.Quest("Pair!", "Connect 2 cards with the same pictograph", new List<Quest.QuestRequirement>() { new Quest.TwoCardsWithTheSamePictographConnected() }, Quest.RewardType.Score, 5));

            quests.Add(new Quest.Quest("COLOR!", "Connect 4 cards with the same color", new List<Quest.QuestRequirement>() { new Quest.FourCardsSameWithSymbolConnected() }, Quest.RewardType.Bombs, 2));
            quests.Add(new Quest.Quest("Pair!", "Connect 2 cards with the same pictograph", new List<Quest.QuestRequirement>() { new Quest.TwoCardsWithTheSamePictographConnected() }, Quest.RewardType.Bombs, 2));

            availableQuests.Add(quests[UnityEngine.Random.Range(0, quests.Count)]);
        }

        /// <summary>
        /// Check all quests if completed
        /// </summary>
        /// <param name="cardPlacementTracker">The tracker of card placements.</param>
        public void CheckQuests(Dictionary<Vector3, Card> cardPlacementTracker)
        {
            foreach (var quest in quests.Where(quest => quest.IsCompleted(cardPlacementTracker)))
            {
                GrantReward(quest.reward, quest.rewardAmount);

                availableQuests.Remove(quest);
                availableQuests.Add(quests[UnityEngine.Random.Range(0, quests.Count)]);
            }
        }

        /// <summary>
        /// Grant a reward to the player.
        /// </summary>
        /// <param name="reward">The reward type.</param>
        /// <param name="rewardAmount">The reward amount.</param>
        private void GrantReward(RewardType reward, int rewardAmount)
        {
            switch (reward)
            {
                case RewardType.Score:
                {
                    var pointsManager = PointsManager.Instance;
                    if (pointsManager == null) return;

                    var parameterWithPoints = pointsManager.parameters.First();
                    parameterWithPoints.points += rewardAmount;
                    break;
                }
                case RewardType.Cards:
                    break;
                case RewardType.Bombs:
                {
                    var gameBoardController = GameBoardController.Instance;
                    if (gameBoardController == null) return;

                    gameBoardController.bombsLeft += rewardAmount;
                    break;
                }
                default:
                    throw new ArgumentException("Invalid reward type.");
            }
        }
    }
}