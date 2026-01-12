using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HabitPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Txt_Name;
    [SerializeField] TextMeshProUGUI Txt_Desc;
    [SerializeField] Image Img_Button;

    int Index;
    string Name;
    string Description;
    bool Completed;

    public void Setup(string name,string desc,int ind,bool b,ColorCombination cc)
    {
        Index = ind;
        Name = name;
        Description = desc;

        Txt_Name.text = Name;
        Txt_Desc.text = Description;
        Img_Button.sprite = SpriteManager.Instance.GetUnTicked();
        if (b)
        {
            Txt_Name.text = "<s>" + Name + "<s>";
            Txt_Desc.text = "<s>" + Description + "<s>";
            Img_Button.sprite = SpriteManager.Instance.GetTicked();
        }

        //Assigning Colors
        Img_Button.color = cc.InfoColor;    
        Txt_Desc.color = cc.InfoColor;
        Txt_Name.color = cc.InfoColor;
        GetComponent<Image>().color = cc.BgColor;
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
            Txt_Desc.text = "<s>" + Description + "<s>";
            Img_Button.sprite = SpriteManager.Instance.GetTicked();
        }
        else
        {
            Txt_Name.text = Name;
            Txt_Desc.text = Description;
            Img_Button.sprite = SpriteManager.Instance.GetUnTicked();
        }
        HabitManager.instance.SetComplete(Completed, Index);
    }
}
