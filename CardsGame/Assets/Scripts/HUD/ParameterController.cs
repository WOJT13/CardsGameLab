using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// This class controls the parameters and displays them using Unity UI TextMesh Pro.
/// </summary>
public class ParameterController : MonoBehaviour
{
    /// <summary>
    /// Reference to scoreTextObject
    /// </summary>
    Transform scoreTextObject;
    /// <summary>
    /// Reference to nameTextObject
    /// </summary>
    Transform nameTextObject;
    /// <summary>
    /// Reference to minMaxTextObject
    /// </summary>
    Transform minMaxTextObject;
    /// <summary>
    /// Reference to infoTextObject
    /// </summary>
    Transform infoTextObject;

    /// <summary>
    /// Minimum value of parameter
    /// </summary>
    int min;
    /// <summary>
    /// Maximumvalue of parameter
    /// </summary>
    int max;

    /// <summary>
    /// Called when the script is initialized.
    /// </summary>
    void Start()
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
    void Update()
    {
        // Get references to the UI TextMesh Pro components
        TMP_Text scoreTextComponent = scoreTextObject.GetComponent<TMP_Text>();
        TMP_Text nameTextComponent = nameTextObject.GetComponent<TMP_Text>();
        TMP_Text infoTextComponent = infoTextObject.GetComponent<TMP_Text>();

        if (scoreTextComponent != null && nameTextComponent != null)
        {
            // Retrieve the points for the parameter with the matching name
            int points = PointsManager.Instance.Parameters.Find(p => p.name == nameTextComponent.text).points;

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
