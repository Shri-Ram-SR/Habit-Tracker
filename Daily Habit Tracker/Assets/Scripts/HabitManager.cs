using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HabitManager : MonoBehaviour
{
    [SerializeField] List<HabitInfo> Habits;
    [SerializeField] List<MonthDisplayer> MonthDisplay;
    [SerializeField] GameObject HabitPanel;
    [SerializeField] GameObject MonthyTracker;
    [SerializeField] GameObject HabitProfile;
    [SerializeField] Transform HabitsLayout;
    [SerializeField] Transform MonthlyTrackerLayout;
    [SerializeField] Transform HabitProfileLayout;
    [SerializeField] ColorPallete Colors;

    int lastdate;

    public static HabitManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        CreatePanelsFromData(); 
    }
    public void SpriteChanged()
    {
        SaveSystem.SaveData(Habits, SpriteManager.Instance.GetCurrent());
        ResetMonthlyDisplay();
        ResetPanels();
        ResetHabitProfile();

        CreatePanelsFromData();
    }
    void CreatePanelsFromData()
    {
        PlayerData Data = SaveSystem.LoadData();
        Habits = Data.AllHabits;

        if(SpriteManager.Instance.GetCurrent() != Data.IconShape)
        {
            SpriteManager.Instance.ChangeCurrent(Data.IconShape);
            return;
        }

        if (Habits == null)
            Habits = new List<HabitInfo>();
        int d = GetDaysInMonth();

        if (lastdate > DateTime.Now.Day)
        {
            List<bool> bs = new List<bool>();

            foreach (HabitInfo hi in Habits)
            {
                hi.Completion = bs;
            }
        }

        for (int index = 0; index < Habits.Count; index++) 
        {
            CreatePanel(Habits[index].HabitName, Habits[index].Description, Habits[index].Points, index, Habits[index].cc);
        }
        lastdate = DateTime.Now.Day;
    }
    void ResetPanels()
    {
        for (int i = HabitsLayout.childCount - 1; i >= 0; i--)
        {
            Destroy(HabitsLayout.GetChild(i).gameObject);
        }
    }
    void ResetMonthlyDisplay()
    {
        for (int i = MonthlyTrackerLayout.childCount - 1; i >= 0; i--)
        {
            Destroy(MonthlyTrackerLayout.GetChild(i).gameObject);
        }
        MonthDisplay = new List<MonthDisplayer>();
    }
    void ResetHabitProfile()
    {
        for (int i = HabitProfileLayout.childCount - 1; i >= 0; i--)
        {
            Destroy(HabitProfileLayout.GetChild(i).gameObject);
        }
    }
    void CreatePanel(string name,string desc,int point,int ind,string cc)
    {
        GameObject g = Instantiate(HabitPanel);
        g.transform.SetParent(HabitsLayout);
        g.GetComponent<HabitPanel>().Setup(name, desc, ind, Habits[ind].Completion[GetDate() - 1], Colors.GetColor(cc));
        CreateMonthlyTracker(ind, Habits[ind].HabitName);
    }
    void CreateMonthlyTracker(int ind,string name)
    {
        GameObject g = Instantiate(MonthyTracker);
        g.transform.SetParent(MonthlyTrackerLayout);

        g.GetComponent<MonthDisplayer>().CreateBoxes(Habits[ind].Completion, name, Colors.GetColor(Habits[ind].cc));
        MonthDisplay.Add(g.GetComponent<MonthDisplayer>());
        CreateHabitProfile(ind);
    }
    void CreateHabitProfile(int ind)
    {
        GameObject go = Instantiate(HabitProfile);
        go.transform.SetParent(HabitProfileLayout);
        go.GetComponent<HabitProfile>().Setup(ind, Habits[ind].HabitName, Colors.GetColor(Habits[ind].cc));
    }
    public void SetComplete(bool b,int ind)
    {
        Habits[ind].Completion[GetDate()-1] = b;
        MonthDisplay[ind].SetCompleted(b, GetDate()-1);
    }
    public void CreateHabit(string n,string d,int p,string cc)
    {
        HabitInfo h = new HabitInfo(n,d,p,cc);

        List<bool> bs = new List<bool>();
        for (int i = 0; i < GetDaysInMonth(); i++) 
        {
            bs.Add(false);
        }
        h.Completion = bs;

        Habits.Add(h);
        SaveSystem.SaveData(Habits, SpriteManager.Instance.GetCurrent());
        CreatePanel(n, d, p, Habits.Count-1,cc);
    }
    public void DeleteHabit(int ind)
    {
        Habits.RemoveAt(ind);
        SpriteChanged();
    }
    public static int GetDate()
    {
        return DateTime.Now.Day;
    }
    public static int GetDaysInMonth()
    {
        int daysinmonth = 0;
        switch (DateTime.Now.Month)
        {
            case 1:
                daysinmonth = 31;
                break;
            case 2:
                daysinmonth = 28;
                break;
            case 3:
                daysinmonth = 31;
                break;
            case 4:
                daysinmonth = 30;
                break;
            case 5:
                daysinmonth = 31;
                break;
            case 6:
                daysinmonth = 30;
                break;
            case 7:
                daysinmonth = 31;
                break;
            case 8:
                daysinmonth = 31;
                break;
            case 9:
                daysinmonth = 30;
                break;
            case 10:
                daysinmonth = 31;
                break;
            case 11:
                daysinmonth = 30;
                break;
            case 12:
                daysinmonth = 31;
                break;
        }
        return daysinmonth;
    }
    public HabitInfo GetHabit(int ind)
    {
        return Habits[ind];
    }
    private void OnApplicationQuit()
    {
        SaveSystem.SaveData(Habits, SpriteManager.Instance.GetCurrent());
    }
}
