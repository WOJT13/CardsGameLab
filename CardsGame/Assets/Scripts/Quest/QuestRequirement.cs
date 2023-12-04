using Model;
using System.Collections.Generic;
using UnityEngine;

namespace Quest
{
    /// <summary>
    /// Abstract class for a quest requirement.
    /// </summary>
    public abstract class QuestRequirement
    {

        /// <summary>
        /// Checks if the quest requirement is satisfied.
        /// </summary>
        /// <param name="cardPlacementTracker">The tracker of card placements.</param>
        /// <returns>True if the quest requirement is satisfied, false otherwise.</returns>
        public abstract bool IsSatisfied(Dictionary<Vector3, Card> cardPlacementTracker);

    }

}