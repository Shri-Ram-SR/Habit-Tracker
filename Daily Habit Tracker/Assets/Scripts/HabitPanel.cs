using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HabitPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Txt_Name;
    [SerializeField] TextMeshProUGUI Txt_Desc;
    [SerializeField] Image Img_Button;

    [SerializeField] Sprite Unticked;
    [SerializeField] Sprite Ticked;
    int Index;
    string Name;
    string Description;
    bool Completed;

    public void Setup(string name,string desc,int ind,bool b)
    {
        Index = ind;
        Name = name;
        Description = desc;

        Txt_Name.text = Name;
        Txt_Desc.text = Description;
        Img_Button.sprite = Unticked;
        if (b)
        {
            Txt_Name.text = "<s>" + Name + "<s>";
            Txt_Desc.enabled = false;
            Img_Button.sprite = Ticked;
        }
    }
    public void SetIndex(int i)
    {
        Index = i;
    }
    public void Interacted()
    {
        Completed = !Completed;
        if (Completed)
        {
            Txt_Name.text = "<s>" + Name + "<s>";
            Txt_Desc.enabled = false;
            Img_Button.sprite = Ticked;
        }
        else
        {
            Txt_Name.text = Name;
            Txt_Desc.enabled = true;
            Img_Button.sprite = Unticked;
        }
        HabitManager.instance.SetComplete(Completed, Index);
    }
}
