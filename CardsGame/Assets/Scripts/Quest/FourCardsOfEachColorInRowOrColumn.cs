using Model;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Quest
{
    /// <summary>
    /// Quest requirement to check if there are 4 cards of each color in a row or column.
    /// </summary>
    public class FourCardsOfEachColorInRowOrColumn : QuestRequirement
    {

        /// <summary>
        /// Checks if the quest requirement is satisfied.
        /// </summary>
        /// <param name="cardPlacementTracker">The tracker of card placements.</param>
        /// <returns>True if the quest requirement is satisfied, false otherwise.</returns>
        public override bool IsSatisfied(Dictionary<Vector3, Card> cardPlacementTracker) => AreFourCardsOfEachColorInRowOrColumn(cardPlacementTracker);

        /// <summary>
        /// Checks if there are 4 cards of each color in a row or column.
        /// </summary>
        /// <param name="cardPlacementTracker">The tracker of card placements.</param>
        /// <returns>True if there are 4 cards of each color in a row or column, false otherwise.</returns>
        private static bool AreFourCardsOfEachColorInRowOrColumn(Dictionary<Vector3, Card> cardPlacementTracker)
        {
            return cardPlacementTracker.Any(item => CheckHorizontal(item.Key, item.Value.symbol, cardPlacementTracker) || CheckVertical(item.Key, item.Value.symbol, cardPlacementTracker));
        }

        /// <summary>
        /// Check for a horizontal line of the same type
        /// </summary>
        /// <param name="position">The current position.</param>
        /// <param name="symbol">The symbol to match.</param>
        /// <param name="tracker">The tracker of card placements.</param>
        /// <returns>True if there is a horizontal line of the same type, false otherwise.</returns>
        private static bool CheckHorizontal(Vector3 position, Symbol symbol, IReadOnlyDictionary<Vector3, Card> tracker)
        {
            var matchingCount = 1;
            var symbolList = new List<Symbol>
            {
                symbol,
            };

            for (var i = 1; i < 4; i++)
            {
                var nextPosition = new Vector3(position.x + 10 * i, 0, position.z);

                if (tracker.TryGetValue(nextPosition, out var nextCard) && !symbolList.Contains(nextCard.symbol))
                {
                    Debug.Log($"nextCard.symbol: {nextCard.symbol}");
                    matchingCount++;
                    symbolList.Add(nextCard.symbol);
                    Debug.Log($"symbolList.Count: {symbolList.Count}");
                }
                else
                {
                    break;
                }
            }

            return matchingCount == 4;
        }

        /// <summary>
        /// Check for a vertical line of the same type
        /// </summary>
        /// <param name="position">The current position.</param>
        /// <param name="symbol">The symbol to match.</param>
        /// <param name="tracker">The tracker of card placements.</param>
        /// <returns>True if there is a vertical line of the same type, false otherwise.</returns>
        private static bool CheckVertical(Vector3 position, Symbol symbol, IReadOnlyDictionary<Vector3, Card> tracker)
        {
            var matchingCount = 1;
            var symbolList = new List<Symbol>
            {
                symbol,
            };

            for (var i = 1; i < 4; i++)
            {
                var nextPosition = new Vector3(position.x, 0, position.z + 10 * i);

                if (tracker.TryGetValue(nextPosition, out var nextCard) && !symbolList.Contains(nextCard.symbol))
                {
                    Debug.Log($"nextCard.symbol: {nextCard.symbol}");
                    matchingCount++;
                    symbolList.Add(nextCard.symbol);
                    Debug.Log($"symbolList.Count: {symbolList.Count}");
                }
                else
                {
                    break;
                }
            }

            return matchingCount == 4;
        }

    }
}