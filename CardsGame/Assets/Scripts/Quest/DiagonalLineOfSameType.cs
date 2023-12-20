using Model;
using System.Collections.Generic;
using UnityEngine;

namespace Quest
{
    /// <summary>
    /// Quest requirement to check if there is a diagonal line of the same type.
    /// </summary>
    public class DiagonalLineOfSameType : QuestRequirement
    {

        /// <summary>
        /// Length of the diagonal line
        /// </summary>
        private readonly int lineLength;

        /// <summary>
        /// Constructor for the diagonal line of same type quest requirement
        /// </summary>
        /// <param name="length">Length of the diagonal line</param>
        public DiagonalLineOfSameType(int length)
        {
            this.lineLength = length;
        }

        /// <summary>
        /// Checks if the quest requirement is satisfied.
        /// </summary>
        /// <param name="cardPlacementTracker">The tracker of card placements.</param>
        /// <returns>True if the quest requirement is satisfied, false otherwise.</returns>
        public override bool IsSatisfied(Dictionary<Vector3, Card> cardPlacementTracker)
        {
            foreach (var item in cardPlacementTracker)
            {
                // Check for diagonal line in both diagonal directions from each card
                if (CheckDiagonal(item.Key, item.Value.symbol, cardPlacementTracker, 10) || CheckDiagonal(item.Key, item.Value.symbol, cardPlacementTracker, -10))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Check for a diagonal line of the same type
        /// </summary>
        /// <param name="position">The current position.</param>
        /// <param name="symbol">The symbol to match.</param>
        /// <param name="tracker">The tracker of card placements.</param>
        /// <param name="direction">The direction to check.</param>
        /// <returns>True if there is a diagonal line of the same type, false otherwise.</returns>
        private bool CheckDiagonal(Vector3 position, Symbol symbol, IReadOnlyDictionary<Vector3, Card> tracker, int direction)
        {
            int matchingCount = 1; // Start with the current card

            for (int i = 1; i < lineLength; i++)
            {
                var nextPosition = new Vector3(position.x + 10 * i, 0, position.z + direction * i);

                if (!tracker.TryGetValue(nextPosition, out var nextCard) || nextCard.symbol != symbol)
                {
                    return false;
                }

                matchingCount++;
            }

            return matchingCount == lineLength;
        }
    }

}