using System;
using System.Collections.Generic;
using UnityEngine;

public class HabitManager : MonoBehaviour
{
    [SerializeField] List<HabitInfo> Habits;
    [SerializeField] List<MonthDisplayer> MonthDisplay;
    [SerializeField] GameObject HabitPanel;
    [SerializeField] GameObject MonthyTracker;
    [SerializeField] Transform HabitsLayout;
    [SerializeField] Transform MonthlyTrackerLayout;

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
        Habits = SaveSystem.LoadData();
        int d = GetDaysInMonth();
        
        if(lastdate > DateTime.Now.Day)
        {
            List<bool> bs = new List<bool>();

            foreach(HabitInfo hi in Habits)
            {
                hi.Completion = bs;
            }
        }

        for (int index = 0; index < Habits.Count; index++)
        {
            CreatePanel(Habits[index].HabitName, Habits[index].Description, Habits[index].Points, index);
        }
        lastdate = DateTime.Now.Day;
    }
    void CreatePanel(string name,string desc,int point,int ind)
    {
        GameObject g = Instantiate(HabitPanel);
        g.transform.SetParent(HabitsLayout);
        g.GetComponent<HabitPanel>().Setup(name, desc, ind, Habits[ind].Completion[GetDate()]);
        CreateMonthlyTracker(ind, Habits[ind].HabitName);
    }
    void CreateMonthlyTracker(int ind,string name)
    {
        GameObject g = Instantiate(MonthyTracker);
        g.transform.SetParent(MonthlyTrackerLayout);
        g.GetComponent<MonthDisplayer>().CreateBoxes(Habits[ind].Completion,name);
        MonthDisplay.Add(g.GetComponent<MonthDisplayer>());
    }
    public void SetComplete(bool b,int ind)
    {
        Habits[ind].Completion[GetDate()] = b;
        MonthDisplay[ind].SetCompleted(b, GetDate());
    }
    public void CreateHabit(string n,string d,int p)
    {
        HabitInfo h = new HabitInfo(n,d,p);

        List<bool> bs = new List<bool>();
        for(int i = 0; i < GetDaysInMonth(); i++)
        {
            bs.Add(false);
        }
        h.Completion = bs;

        Habits.Add(h);
        SaveSystem.SaveData(Habits);
        CreatePanel(n, d, p, Habits.Count-1);
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
    private void OnApplicationQuit()
    {
        SaveSystem.SaveData(Habits);
    }
}
