using Model;
using Quest;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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

        public List<GameObject> availableQuestsObjects = new List<GameObject>();

        /// <summary>
        /// The container where the card objects will be instantiated.
        /// </summary>
        public Transform cardsContainer;

        /// <summary>
        /// The container where the quest objects will be instantiated.
        /// </summary>
        public Transform questsContainer;

        /// <summary>
        /// The prefab for quest objects.
        /// </summary>
        public Transform questPrefab;

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

            quests.Add(new Quest.Quest("KOLOR!", "Po��cz 4 karty tego samego koloru", new List<Quest.QuestRequirement>() { new Quest.FourCardsSameWithSymbolConnected() }, Quest.RewardType.Score, 5));
            quests.Add(new Quest.Quest("PARA!", "Po��cz 2 karty z tym samym piktografem", new List<Quest.QuestRequirement>() { new Quest.TwoCardsWithTheSamePictographConnected() }, Quest.RewardType.Score, 5));

            quests.Add(new Quest.Quest("KOLOR!", "Po��cz 4 karty tego samego koloru", new List<Quest.QuestRequirement>() { new Quest.FourCardsSameWithSymbolConnected() }, Quest.RewardType.Bombs, 2));
            quests.Add(new Quest.Quest("KOLOR!", "Po��cz 4 karty tego samego koloru", new List<Quest.QuestRequirement>() { new Quest.FourCardsSameWithSymbolConnected() }, Quest.RewardType.Cards, 2));
            quests.Add(new Quest.Quest("PARA!", "Po��cz 2 karty z tym samym piktografem", new List<Quest.QuestRequirement>() { new Quest.TwoCardsWithTheSamePictographConnected() }, Quest.RewardType.Bombs, 2));

            quests.Add(new Quest.Quest("SKOS 2", "Po��cz 2 karty tego samego typu pod skosem", new List<Quest.QuestRequirement>() { new Quest.DiagonalLineOfSameType(2) }, Quest.RewardType.Score, 5));
            quests.Add(new Quest.Quest("SKOS 4", "Po��cz 4 karty tego samego typu pod skosem", new List<Quest.QuestRequirement>() { new Quest.DiagonalLineOfSameType(4) }, Quest.RewardType.Score, 20));

            quests.Add(new Quest.Quest("T�CZA!", "Po�� kart� ka�dego koloru w wierszu lub kolumnie", new List<Quest.QuestRequirement>() { new Quest.FourCardsOfEachColorInRowOrColumn() }, Quest.RewardType.Score, 30));

            availableQuests.Add(quests[UnityEngine.Random.Range(0, quests.Count)]);
            availableQuests.Add(quests[UnityEngine.Random.Range(0, quests.Count)]);
            availableQuests.Add(quests[UnityEngine.Random.Range(0, quests.Count)]);

            foreach (var quest in availableQuests)
            {
                ShowQuest(quest);
            }
        }

        /// <summary>
        /// Check all quests if completed
        /// </summary>
        /// <param name="cardPlacementTracker">The tracker of card placements.</param>
        public void CheckQuests(Dictionary<Vector3, Card> cardPlacementTracker)
        {
            var gameBoardController = GameBoardController.Instance;

            var completedQuests = new List<Quest.Quest>(availableQuests.Where(quest => quest.IsCompleted(cardPlacementTracker)));
            foreach (var quest in completedQuests)
            {
                GrantReward(quest.reward, quest.rewardAmount);

                var drawedCard = gameBoardController.cardList.DrawCard();

                GameBoardController.Instance.hand.Create(drawedCard);

                var newGameObject = Instantiate(drawedCard.cardModel, CardManager.Instance.container);
                var newCard = newGameObject.GetComponent<CardsDisplayer>();
                var image = newGameObject.GetComponent<Image>();
                image.sprite = drawedCard.cardImage;
                newCard.id = drawedCard.cardID;

                availableQuests.Remove(quest);
                availableQuests.Add(quests[UnityEngine.Random.Range(0, quests.Count)]);
                foreach (var questObject in availableQuestsObjects)
                {
                    Destroy(questObject);
                }
                foreach (var availableQuest in availableQuests)
                {
                    ShowQuest(availableQuest);
                }
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
                    var gameBoardController = GameBoardController.Instance;
                    if (gameBoardController == null) return;

                    if (gameBoardController.canDoublePoints && gameBoardController.doubleUpsLeft > 0)
                    {
                        rewardAmount *= 2;
                        gameBoardController.doubleUpsLeft--;
                    }

                    gameBoardController.points += rewardAmount;
                    break;
                }
                case RewardType.Cards:
                {
                    var gameBoardController = GameBoardController.Instance;
                    if (gameBoardController == null) return;

                    for (int i = 0; i < rewardAmount; i++)
                    {
                        var drawedCard = gameBoardController.cardList.DrawCard();
                        gameBoardController.hand.Create(drawedCard);
                        var newGameObject = Instantiate(drawedCard.cardModel, cardsContainer);
                        var newCard = newGameObject.GetComponent<CardsDisplayer>();
                        newCard.id = drawedCard.cardID;
                    }

                    gameBoardController.cardsLeft = gameBoardController.hand.CardCount();

                    break;
                }
                case RewardType.Bombs:
                {
                    var gameBoardController = GameBoardController.Instance;
                    if (gameBoardController == null) return;

                    gameBoardController.bombsLeft += rewardAmount;
                    break;
                }
                case RewardType.DoubleUps:
                {
                    var gameBoardController = GameBoardController.Instance;
                    if (gameBoardController == null) return;

                    gameBoardController.doubleUpsLeft += rewardAmount;
                    break;
                }
                default:
                    throw new ArgumentException("Invalid reward type.");
            }
        }

        private void ShowQuest(Quest.Quest quest)
        {
            var questObject = Instantiate(questPrefab, questsContainer);

            // Set the parameter's name, min-max text, score text, and info text
            questObject.Find("nameText").GetComponent<TMP_Text>().text = quest.name;
            questObject.Find("descriptionText").GetComponent<TMP_Text>().text = $"{quest.description}";
            questObject.Find("rewardText").GetComponent<TMP_Text>().text = MapReward(quest.reward, quest.rewardAmount);

            availableQuestsObjects.Add(questObject.gameObject);
        }

        private string MapReward(RewardType reward, int rewardAmount)
        {
            switch (reward)
            {
                case RewardType.Score:
                {
                    return $"Punkty: {rewardAmount}";
                }
                case RewardType.Cards:
                {
                    return $"Karty: {rewardAmount}";
                }
                case RewardType.Bombs:
                {
                    return $"Bomby: {rewardAmount}";
                }
                case RewardType.DoubleUps:
                {
                    return $"Podwojenia: {rewardAmount}";
                }
                default:
                    return $"Nie ma nagrody ;-)";
            }
        }
    }
}