using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public DifficultyLevelsList difficultyLevelsList = new DifficultyLevelsList();
    public Sprite easyIcon;
    public Sprite hardIcon;
    void Awake()
    {
        // Poziom trudności 1
        DifficultyLevel easyLevel = new DifficultyLevel
        {
            name = "Easy",
            icon = easyIcon, // Przypisz ikonę
            parameters = new List<Parameter>()
        };
        easyLevel.parameters.Add(new Parameter() { name = "ParametrA", min = 1, max = 10 });
        easyLevel.bombCount = 3;
        difficultyLevelsList.Create(easyLevel);

        // Poziom trudności 2
        DifficultyLevel hardLevel = new DifficultyLevel
        {
            name = "Hard",
            icon = hardIcon, // Przypisz ikonę
            parameters = new List<Parameter>()
        };
        hardLevel.parameters.Add(new Parameter() { name = "ParametrA", min = 1, max = 10 });
        hardLevel.parameters.Add(new Parameter() { name = "ParametrB", min = 5, max = 15 });
        hardLevel.bombCount = 5;
        difficultyLevelsList.Create(hardLevel);

        DataManager.Instance.difficultyLevelsList = difficultyLevelsList;
    }
}
