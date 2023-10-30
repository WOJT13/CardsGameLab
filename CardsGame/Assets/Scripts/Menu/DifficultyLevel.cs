
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DifficultyLevel
{
    public string name;
    public Sprite icon;
    public List<Parameter> parameters;
    public int bombCount;
}

[System.Serializable]
public class Parameter
{
    public string name;
    public int min;
    public int max;
}
