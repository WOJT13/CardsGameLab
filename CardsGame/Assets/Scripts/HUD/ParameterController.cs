using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ParameterController : MonoBehaviour
{
    // Start is called before the first frame update

    Transform scoreTextObject;
    Transform nameTextObject;
    Transform minMaxTextObject;
    Transform infoTextObject;

    int min;
    int max;
    void Start()
    {
        scoreTextObject = transform.Find("scoreText");
        nameTextObject = transform.Find("nameText");
        minMaxTextObject = transform.Find("minmaxText");
        infoTextObject = transform.Find("infoText");
        string minMaxText = minMaxTextObject.GetComponent<TMP_Text>().text;

        min = int.Parse(minMaxText.Substring(0, minMaxText.IndexOf('-')-1));
        max = int.Parse(minMaxText.Substring(minMaxText.IndexOf('-')+1));
    }

    // Update is called once per frame
    void Update()
    {
        TMP_Text scoreTextComponent = scoreTextObject.GetComponent<TMP_Text>();
        TMP_Text nameTextComponent = nameTextObject.GetComponent<TMP_Text>();
        TMP_Text infoTextComponent = infoTextObject.GetComponent<TMP_Text>();

        if (scoreTextComponent != null && nameTextComponent != null)
        {
            // Wykonaj operacje na komponencie Text
            int points = PointsManager.Instance.Parameters.Find(p => p.name == nameTextComponent.text).points;
            scoreTextComponent.text = points.ToString();
            if(min > points)
                infoTextComponent.text = "Brakuje punktów do minimum";
            else if(max < points)
                infoTextComponent.text = "Przekroczenie punktów";
            else
                infoTextComponent.text = "Punkty w wymaganym przedziale";

        }
    }
}
