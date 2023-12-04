using Model;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Quest
{
    /// <summary>
    /// Quest requirement to check if there are 4 cards with the same symbol that are connected.
    /// </summary>
    public class FourCardsSameWithSymbolConnected : QuestRequirement
    {

        /// <summary>
        /// Checks if the quest requirement is satisfied.
        /// </summary>
        /// <param name="cardPlacementTracker">The tracker of card placements.</param>
        /// <returns>True if the quest requirement is satisfied, false otherwise.</returns>
        public override bool IsSatisfied(Dictionary<Vector3, Card> cardPlacementTracker) => AreFourMatchingSymbolsConnected(cardPlacementTracker);


        /// <summary>
        /// Checks if there are 4 cards with the same symbol that are connected.
        /// </summary>
        /// <param name="cardPlacementTracker">The tracker of card placements.</param>
        /// <returns>True if there are 4 cards with the same symbol that are connected, false otherwise.</returns>
        public bool AreFourMatchingSymbolsConnected(Dictionary<Vector3, Card> cardPlacementTracker)
        {
            var visited = new HashSet<Vector3>();

            foreach (var item in cardPlacementTracker)
            {
                if (visited.Contains(item.Key)) continue;

                var count = DepthFirstSearch(item.Key, item.Value.symbol, cardPlacementTracker, visited);
                if (count >= 4)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Depth first search to find cards with the same symbol that are connected.
        /// </summary>
        /// <param name="position">The current position.</param>
        /// <param name="symbol">The symbol to match.</param>
        /// <param name="tracker">The tracker of card placements.</param>
        /// <param name="visited">The set of visited positions.</param>
        /// <returns>The number of cards with the same symbol that are connected.</returns>
        private static int DepthFirstSearch(Vector3 position, Symbol symbol, IReadOnlyDictionary<Vector3, Card> tracker, HashSet<Vector3> visited)
        {
            if (!tracker.TryGetValue(position, out var card) || card.symbol != symbol || visited.Contains(position))
            {
                return 0;
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

            return 1 + adjacentPositions.Sum(adjacent => DepthFirstSearch(adjacent, symbol, tracker, visited));
        }

    }
}