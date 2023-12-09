using Game;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Quest;

namespace HUD
{
    /// <summary>
    /// This class loads and initializes quests
    /// </summary>
    public class QuestsLoader : MonoBehaviour
    {
        /// <summary>
        /// The prefab for quest objects.
        /// </summary>
        public Transform questPrefab;

        /// <summary>
        /// The container where the quest objects will be instantiated.
        /// </summary>
        public Transform container;

        /// <summary>
        /// Called every frame.
        /// </summary>
        private void Update()
        {
            CreateQuests();
        }

        /// <summary>
        /// Create and initialize parameter objects based on data from DataManager.
        /// </summary>
        private void CreateQuests()
        {
            //PointsManager.Instance.parameters = new List<ParameterWithPoints>();

            foreach (var quest in QuestManager.Instance.availableQuests)
            {
                var questObject = Instantiate(questPrefab, container);

                // Set the parameter's name, min-max text, score text, and info text
                questObject.Find("nameText").GetComponent<TMP_Text>().text = quest.name;
                questObject.Find("descriptionText").GetComponent<TMP_Text>().text = $"{quest.description}";
                questObject.Find("rewardText").GetComponent<TMP_Text>().text = MapReward(quest.reward, quest.rewardAmount);  
            }
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
                    return $"karty: {rewardAmount}";
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