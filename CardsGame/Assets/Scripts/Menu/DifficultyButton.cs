using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DifficultyButton : MonoBehaviour
{
        public GameObject button;
    public void OnDifficultyButtonClick()
    {
        DataManager.Instance.difficultyLevel = DataManager.Instance.difficultyLevelsList.GetByName(button.GetComponentInChildren<TMP_Text>().text);
        Debug.Log(DataManager.Instance.difficultyLevel.name);
    }
}
