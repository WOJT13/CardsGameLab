using Model;
using System.Collections.Generic;
using UnityEngine;

namespace Quest
{
    /// <summary>
    /// Quest requirement to check if there are 2 cards with the same pictograph that are connected.
    /// </summary>
    public class TwoCardsWithTheSamePictographConnected : QuestRequirement
    {

        /// <summary>
        /// Checks if the quest requirement is satisfied.
        /// </summary>
        /// <param name="cardPlacementTracker">The tracker of card placements.</param>
        /// <returns>True if the quest requirement is satisfied, false otherwise.</returns>
        public override bool IsSatisfied(Dictionary<Vector3, Card> cardPlacementTracker) => AreTwoMatchingPictographsConnected(cardPlacementTracker);


        /// <summary>
        /// Checks if there are 2 cards with the same pictograph that are connected.
        /// </summary>
        /// <param name="cardPlacementTracker">The tracker of card placements.</param>
        /// <returns>True if there are 2 cards with the same pictograph that are connected, false otherwise.</returns>
        public bool AreTwoMatchingPictographsConnected(Dictionary<Vector3, Card> cardPlacementTracker)
        {
            foreach (var item in cardPlacementTracker)
            {
                var visited = new HashSet<Vector3>
                {
                    //item.Key
                };
                if (DfsForPictograph(item.Key, item.Value.pictograph, cardPlacementTracker, visited))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Depth first search to find cards with the same pictograph that are connected.
        /// </summary>
        /// <param name="position">The current position.</param>
        /// <param name="pictograph">The pictograph to match.</param>
        /// <param name="tracker">The tracker of card placements.</param>
        /// <param name="visited">The set of visited positions.</param>
        /// <returns>True if the pictograph is found, false otherwise.</returns>
        private static bool DfsForPictograph(Vector3 position, Pictograph pictograph, IReadOnlyDictionary<Vector3, Card> tracker, HashSet<Vector3> visited)
        {
            Debug.Log($"pictograph: {pictograph}");
            Debug.Log($"visited.Contains(position): {visited.Contains(position)}");
            if (!tracker.TryGetValue(position, out Card card) || visited.Contains(position))
            {
                return false;
            }

            

            if (card.pictograph == pictograph && !visited.Contains(position))
            {
                return true; // Found a matching pictograph
            }
            visited.Add(position);
            // Check adjacent positions (up, down, left, right)
            var adjacentPositions = new Vector3[]
            {
                new Vector3(position.x, 0, position.z + 10), // Up
                new Vector3(position.x, 0, position.z - 10), // Down
                new Vector3(position.x - 10, 0, position.z), // Left
                new Vector3(position.x + 10, 0, position.z) // Right
            };

            foreach (var adjacent in adjacentPositions)
            {
                if (DfsForPictograph(adjacent, pictograph, tracker, visited))
                {
                    return true;
                }
            }

            return false;
        }
    }
}