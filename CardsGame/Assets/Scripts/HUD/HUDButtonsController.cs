using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HUDButtonsController : MonoBehaviour
{
    public void onEndGameButtonClick() 
    {
        foreach(var parameter in DataManager.Instance.difficultyLevel.parameters)
        {
            int points = PointsManager.Instance.Parameters.Find(p => p.name == parameter.name).points;

            if (points <= parameter.max && points >= parameter.min)
                DataManager.Instance.IsWin = true;
            else
            {
                DataManager.Instance.IsWin = false;
                break;
            }
               
        }
        SceneManager.LoadScene(2);
    }

    public void onDrawNextButtonClick()
    {
        //int building_x = Random.Range(0, 2);
        //int building_z = Random.Range(0, 2); 
        Vector2Int coordinates = new Vector2Int();
        coordinates.x = Random.Range(0, 2);
        coordinates.y = Random.Range(0, 2);
        bool isOn = GameBoardController.Instance.coordinatesList.CheckList(coordinates);
        if (isOn == false)
        {
            GameBoardController.Instance.coordinatesList.AddToList(coordinates);
        }
  

        if (isOn == false)
        {
            int index = Random.Range(0, GameBoardController.Instance.cardList.GetAll().Count);
            var card = GameBoardController.Instance.cardList.GetAll()[index];
            Vector3 buildingPosition = new Vector3(coordinates.x * 10 - 5, 0, coordinates.y * 10);
            Instantiate(card.buildingModel, buildingPosition, Quaternion.identity);

            foreach(var parameter in card.parametersList)
            {
                var parameterToUpdate = PointsManager.Instance.Parameters.Find(p => p.name == parameter.category);

                if(parameterToUpdate != null)
                {
                    parameterToUpdate.points += parameter.points;
                }

            }

        }
        else
        {
            if (GameBoardController.Instance.coordinatesList.Count() < 4)
            {
                Debug.Log("nie ma miejsca jeszcze raz");
                onDrawNextButtonClick();
            }
        }
    }
}
