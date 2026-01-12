using TMPro;
using UnityEngine;

public class CreateHabits : MonoBehaviour
{
    [SerializeField] TMP_InputField Inp_Name;
    [SerializeField] TMP_InputField Inp_Desc;
    [SerializeField] TMP_InputField Inp_Points;
    [SerializeField] string ColorCombi;
    [SerializeField] Animator Ani;

    public void CreateHabit()
    {
        if (Inp_Points.text == "" || Inp_Name.text == "") 
            return;
        HabitManager.instance.CreateHabit(Inp_Name.text, Inp_Desc.text, int.Parse(Inp_Points.text),ColorCombi);
        Inp_Name.text = "";
        Inp_Desc.text = "";
        Inp_Points.text = "";
        Interacted();
    }
    public void SetColorCombination(string n)
    {
        ColorCombi = n;
    }
    public void Interacted()
    {
        Ani.SetTrigger("Interacted");
    }
}
