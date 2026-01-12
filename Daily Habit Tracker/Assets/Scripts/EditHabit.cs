using TMPro;
using UnityEngine;

public class EditHabit : MonoBehaviour
{
    [SerializeField] TMP_InputField Inp_Name;
    [SerializeField] TMP_InputField Inp_Desc;
    [SerializeField] TMP_InputField Inp_Points;
    [SerializeField] Animator Ani;

    int cur = 0;
    string cc;
    HabitManager HM;
    public static EditHabit instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    private void Start()
    {
        HM = HabitManager.instance;
    }
    public void DeleteHabit(int ind)
    {
        HM.DeleteHabit(ind);
    }
    public void Interacted()
    {
        Ani.SetTrigger("Interacted");
    }
    public void SetUp(int ind)
    {
        Ani.SetTrigger("Interacted");
        cur = ind;
        HabitInfo hi = HM.GetHabit(cur);
        Inp_Name.text = hi.HabitName;
        Inp_Desc.text = hi.Description;
        Inp_Points.text = hi.Points.ToString();
    }
    public void Save()
    {
        HabitInfo hi = HM.GetHabit(cur);
        hi.HabitName = Inp_Name.text;
        hi.Description = Inp_Desc.text;
        hi.Points = int.Parse(Inp_Points.text);
        hi.cc = cc;

        HM.SpriteChanged();
        Interacted();
    }
    public void ChangeColor(string n)
    {
        cc = n;
    }
}
