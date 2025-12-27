using System.Collections.Generic;
using UnityEngine;

[System.Serializable]   
public class HabitInfo
{
    public string HabitName;
    public string Description;
    public int Points;
    public List<bool> Completion;
    public HabitInfo(string habitName, string description, int points)
    {
        HabitName = habitName;
        Description = description;
        Points = points;
        Completion = new List<bool>();
    }
    public int GetPoints()
    {
        return Points;
    }
}
