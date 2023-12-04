using Game;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace HUD
{
    /// <summary>
    /// This class loads and initializes parameters
    /// </summary>
    public class ParametersLoader : MonoBehaviour
    {
        /// <summary>
        /// The prefab for parameter objects.
        /// </summary>
        public Transform parameterPrefab;

        /// <summary>
        /// The container where the parameter objects will be instantiated.
        /// </summary>
        public Transform container;

        /// <summary>
        /// Called when the script is initialized.
        /// </summary>
        private void Start()
        {
            CreateParameters();
        }

        /// <summary>
        /// Create and initialize parameter objects based on data from DataManager.
        /// </summary>
        private void CreateParameters()
        {
            PointsManager.Instance.parameters = new List<ParameterWithPoints>();

            foreach (var parameter in DataManager.Instance.difficultyLevel.parameters)
            {
                var parameterObject = Instantiate(parameterPrefab, container);

                // Set the parameter's name, min-max text, score text, and info text
                parameterObject.Find("nameText").GetComponent<TMP_Text>().text = parameter.name;
                parameterObject.Find("minmaxText").GetComponent<TMP_Text>().text = $"{parameter.min} - {parameter.max}";
                parameterObject.Find("scoreText").GetComponent<TMP_Text>().text = "0";
                parameterObject.Find("infoText").GetComponent<TMP_Text>().text = "Wszystko jest super";

                // Add the parameter to the PointsManager's list with initial points
                PointsManager.Instance.parameters.Add(
                    new ParameterWithPoints()
                    {
                        name = parameter.name,
                        points = 0
                    }
                );
            }
        }
    }
}