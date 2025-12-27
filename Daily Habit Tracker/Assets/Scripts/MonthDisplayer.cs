using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonthDisplayer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Txt_HabitName;
    [SerializeField] Sprite Unticked;
    [SerializeField] Sprite Ticked;
    [SerializeField] List<Image> Boxes;
    [SerializeField] GameObject BoxDisplay;
    [SerializeField] Transform BoxesLayout;

    public void CreateBoxes(List<bool> bs,string n)
    {
        Txt_HabitName.text = n;
        foreach(bool b in bs)
        {
            GameObject go = Instantiate(BoxDisplay);
            go.transform.SetParent(BoxesLayout);
            go.GetComponent<Image>().sprite = b ? Ticked : Unticked;
            Boxes.Add(go.GetComponent<Image>());
        }
    }
    public void SetCompleted(bool b, int ind)
    {
        Boxes[ind].sprite = b ? Ticked : Unticked;
    }
}
