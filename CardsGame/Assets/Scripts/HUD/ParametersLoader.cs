using UnityEngine;
using TMPro;
using System.Collections.Generic;
public class ParametersLoader : MonoBehaviour
{
    public Transform parameterPrefab;
    public Transform container;
    void Start()
    {
        CreateParameters();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateParameters()
    {
        PointsManager.Instance.Parameters = new List<ParameterWithPoints>();
        Debug.Log( DataManager.Instance.difficultyLevel.parameters.Count);
        foreach(var parameter in DataManager.Instance.difficultyLevel.parameters)
        {
            Transform parameterObject = Instantiate(parameterPrefab, container);
            Debug.Log(parameter.name);
            parameterObject.Find("nameText").GetComponent<TMP_Text>().text = parameter.name;
            parameterObject.Find("minmaxText").GetComponent<TMP_Text>().text = $"{parameter.min} - {parameter.max}";
            parameterObject.Find("scoreText").GetComponent<TMP_Text>().text = "0";
            parameterObject.Find("infoText").GetComponent<TMP_Text>().text = "Wszytsko jest super";

            PointsManager.Instance.Parameters.Add(
                new ParameterWithPoints(){
                    name = parameter.name,
                    points = 0
                }
            );
        }

    }
}
