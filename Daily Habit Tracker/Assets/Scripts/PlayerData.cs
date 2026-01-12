using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public List<HabitInfo> AllHabits;
    public string IconShape;

    public PlayerData(List<HabitInfo> allHabits, string iconShape)
    {
        AllHabits = allHabits;
        IconShape = iconShape;
    }
}
