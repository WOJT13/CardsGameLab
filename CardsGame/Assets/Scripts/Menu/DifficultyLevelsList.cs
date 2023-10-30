using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;

[System.Serializable]
public class DifficultyLevelsList 
{
    private List<DifficultyLevel> difficultyLevels = new List<DifficultyLevel>();

    public void Create(DifficultyLevel difficultyLevel)
    {
        difficultyLevels.Add(difficultyLevel);
    }

    public List<DifficultyLevel> GetAll()
    {
        return difficultyLevels;
    } 

    public DifficultyLevel GetByName(string name)
    {
        return difficultyLevels.FirstOrDefault(dl => dl.name == name);
    }

    public void Update(DifficultyLevel difficultyLevel)
    {
        DifficultyLevel levelToUpdate = difficultyLevels.FirstOrDefault(dl => dl.name == difficultyLevel.name);
        if(levelToUpdate != null)
        {
            levelToUpdate.bombCount = difficultyLevel.bombCount;
            levelToUpdate.icon = difficultyLevel.icon;
            levelToUpdate.parameters = difficultyLevel.parameters;
        }
    }

    public void Delete(string name)
    {
        DifficultyLevel levelToDelete = difficultyLevels.FirstOrDefault(dl => dl.name == name);
        if(levelToDelete != null)
        {
            difficultyLevels.Remove(levelToDelete);
        }
    }
}
