using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;

public static class SaveSystem
{
    public static void SaveData(List<HabitInfo> h)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Habits.hb";

        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            PlayerHabitsData data = new PlayerHabitsData(h);
            formatter.Serialize(stream, data);
        }
    }

    public static List<HabitInfo> LoadData()
    {
        string path = Application.persistentDataPath + "/Habits.hb";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                PlayerHabitsData data = formatter.Deserialize(stream) as PlayerHabitsData;

                return data.AllHabits;
            }
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
