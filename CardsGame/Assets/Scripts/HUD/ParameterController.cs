using Game;
using TMPro;
using UnityEngine;

namespace HUD
{
    /// <summary>
    /// This class controls the parameters and displays them using Unity UI TextMesh Pro.
    /// </summary>
    public class ParameterController : MonoBehaviour
    {
        /// <summary>
        /// Reference to scoreTextObject
        /// </summary>
        private Transform scoreTextObject;
        /// <summary>
        /// Reference to nameTextObject
        /// </summary>
        private Transform nameTextObject;
        /// <summary>
        /// Reference to minMaxTextObject
        /// </summary>
        private Transform minMaxTextObject;
        /// <summary>
        /// Reference to infoTextObject
        /// </summary>
        private Transform infoTextObject;

        /// <summary>
        /// Minimum value of parameter
        /// </summary>
        private int min;
        /// <summary>
        /// Maximumvalue of parameter
        /// </summary>
        private int max;

        /// <summary>
        /// Called when the script is initialized.
        /// </summary>
        private void Start()
        {
            // Find the UI elements
            scoreTextObject = transform.Find("scoreText");
            nameTextObject = transform.Find("nameText");
            minMaxTextObject = transform.Find("minmaxText");
            infoTextObject = transform.Find("infoText");

            // Extract the minimum and maximum values from the minMaxText UI element
            string minMaxText = minMaxTextObject.GetComponent<TMP_Text>().text;
            min = int.Parse(minMaxText.Substring(0, minMaxText.IndexOf('-') - 1));
            max = int.Parse(minMaxText.Substring(minMaxText.IndexOf('-') + 1));
        }

        /// <summary>
        /// Called every frame to update the UI elements.
        /// </summary>
        private void Update()
        {
            // Get references to the UI TextMesh Pro components
            var scoreTextComponent = scoreTextObject.GetComponent<TMP_Text>();
            var nameTextComponent = nameTextObject.GetComponent<TMP_Text>();
            var infoTextComponent = infoTextObject.GetComponent<TMP_Text>();

            if (scoreTextComponent != null && nameTextComponent != null)
            {
                // Retrieve the points for the parameter with the matching name
                var points = PointsManager.Instance.parameters.Find(p => p.name == nameTextComponent.text).points;

                // Update the score text
                scoreTextComponent.text = points.ToString();

                // Check if points are below the minimum or above the maximum
                if (min > points)
                    infoTextComponent.text = "Brakuje punktów do minimum";
                else if (max < points)
                    infoTextComponent.text = "Przekroczenie punktów";
                else
                    infoTextComponent.text = "Punkty w wymaganym przedziale";
            }
        }
    }
}