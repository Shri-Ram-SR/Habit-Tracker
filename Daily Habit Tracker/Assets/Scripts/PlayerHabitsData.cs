using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerHabitsData
{
    public List<HabitInfo> AllHabits;

    public PlayerHabitsData(List<HabitInfo> allHabits)
    {
        AllHabits = allHabits;
    }
}
