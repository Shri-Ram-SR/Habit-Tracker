using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonthDisplayer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Txt_HabitName;
    [SerializeField] TextMeshProUGUI Txt_NoOfCompleted;
    [SerializeField] TextMeshProUGUI Txt_Days;
    [SerializeField] List<Image> Boxes;
    [SerializeField] GameObject BoxDisplay;
    [SerializeField] Transform BoxesLayout;
    int Completed;

    public void CreateBoxes(List<bool> bs,string n,ColorCombination cc)
    {
        GetComponent<Image>().color = cc.BgColor;

        Txt_HabitName.text = n;
        Txt_HabitName.color = cc.InfoColor;
        Txt_NoOfCompleted.color = cc.InfoColor;
        Txt_Days.color = cc.InfoColor;

        for (int i = 0; i < FindTheStartOfTheMonth(); i++) 
        {
            GameObject go = Instantiate(BoxDisplay);
            go.transform.SetParent(BoxesLayout);
            go.GetComponent<Image>().enabled = false;
        }
        
        foreach(bool b in bs)
        {
            GameObject go = Instantiate(BoxDisplay);
            go.transform.SetParent(BoxesLayout);
            if (b)
            {
                Completed++;
                go.GetComponent<Image>().sprite = SpriteManager.Instance.GetTicked();
            }
            else
                go.GetComponent<Image>().sprite = SpriteManager.Instance.GetUnTicked();
            go.GetComponent<Image>().color = cc.InfoColor;
            Boxes.Add(go.GetComponent<Image>());
        }
        Txt_NoOfCompleted.text = Completed + "/" + bs.Count;
    }
    public void SetCompleted(bool b, int ind)
    {
        if (b)
        {
            Completed++;
            Boxes[ind].sprite = SpriteManager.Instance.GetTicked();
        }
        else
        {
            Completed--;
            Boxes[ind].sprite = SpriteManager.Instance.GetUnTicked();
        }
        Txt_NoOfCompleted.text = Completed + "/" + Boxes.Count;
    }
    int FindTheStartOfTheMonth()
    {
        int x = (int)(DateTime.Now.DayOfWeek) - HabitManager.GetDate() % 7;

        if (x == -1)
            x = 6;
        else if (x == -2)
            x = 5;
        else if (x == -3)
            x = 4;
        else if (x == -4)
            x = 3;
        else if (x == -5)
            x = 2;
        else if (x == -6)
            x = 1;

        return (x);
    }
}
