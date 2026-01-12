using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteManager : MonoBehaviour
{
    [SerializeField] List<TickBoxes> TickBoxes = new List<TickBoxes>();
    [SerializeField] TickBoxes Current;

    public static SpriteManager Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    public Sprite GetTicked()
    {
        return Current.Ticked;
    }
    public Sprite GetUnTicked()
    {
        return Current.Unticked;
    }
    public void ChangeCurrent(string n)
    {
        if (n == Current.Name) return;
        foreach(TickBoxes tb in TickBoxes)
        {
            if(tb.Name == n)
            {
                Current = tb;
                HabitManager.instance.SpriteChanged();
                tb.Img_IconSelection.sprite = tb.Ticked;
            }
            else
                tb.Img_IconSelection.sprite = tb.Unticked;
        }
    }
    public string GetCurrent()
    {
        return Current.Name;
    }
}
[System.Serializable]
public class TickBoxes
{
    public string Name;
    public Sprite Unticked;
    public Sprite Ticked;
    public Image Img_IconSelection;
}
