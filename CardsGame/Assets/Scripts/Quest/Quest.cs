using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Quest
{
    /// <summary>
    /// Class for a quest.
    /// </summary>
    public class Quest
    {
        /// <summary>
        /// The quest's name.
        /// </summary>
        public string name;

        /// <summary>
        /// The quest's description.
        /// </summary>
        public string description;

        /// <summary>
        /// The quest's requirements.
        /// </summary>
        public List<QuestRequirement> requirements;

        /// <summary>
        /// The quest's reward type.
        /// </summary>
        public RewardType reward;

        /// <summary>
        /// The quest's reward amount.
        /// </summary>
        public int rewardAmount;

        /// <summary>
        /// The quest's constructor.
        /// </summary>
        /// <param name="name">The quest's name.</param>
        /// <param name="description">The quest's description.</param>
        /// <param name="requirements">The quest's requirements.</param>
        /// <param name="reward">The quest's reward type.</param>
        /// <param name="rewardAmount">The quest's reward amount.</param>
        public Quest(string name, string description, List<QuestRequirement> requirements, RewardType reward, int rewardAmount)
        {
            this.name = name;
            this.description = description;
            this.requirements = requirements;
            this.reward = reward;
            this.rewardAmount = rewardAmount;
        }


        /// <summary>
        /// Checks if the quest is completed.
        /// </summary>
        /// <param name="cardPlacementTracker">The tracker of card placements.</param>
        /// <returns>True if the quest is completed, false otherwise.</returns>
        public bool IsCompleted(Dictionary<Vector3, Card> cardPlacementTracker)
        {
            return requirements.All(requirement => requirement.IsSatisfied(cardPlacementTracker));
        }
    }

    /// <summary>
    /// The quest's reward type.
    /// </summary>
    public enum RewardType
    {
        /// <summary>
        /// Bomb reward.
        /// </summary>
        Bombs,

        /// <summary>
        /// Score reward.
        /// </summary>
        Score,

        /// <summary>
        /// Card reward.
        /// </summary>
        Cards,
        /// <summary>
        /// Double up reward.
        /// </summary>
        DoubleUp
    }
}