using TMPro;
using UnityEngine;

public class CreateHabits : MonoBehaviour
{
    [SerializeField] TMP_InputField Inp_Name;
    [SerializeField] TMP_InputField Inp_Desc;
    [SerializeField] TMP_InputField Inp_Points;
    [SerializeField] GameObject Button;
    [SerializeField] Animator Ani;

    public void CreateHabit()
    {
        if (Inp_Points.text == "" || Inp_Name.text == "") 
            return;
        HabitManager.instance.CreateHabit(Inp_Name.text, Inp_Desc.text, int.Parse(Inp_Points.text));
        Interacted();
    }
    public void Interacted()
    {
        if (!Button.activeSelf)
            Invoke("SetButtonActive", .1f);
        else
            Button.SetActive(!Button.activeSelf);
        Ani.SetTrigger("Interacted");
    }
    public void SetButtonActive()
    {
        Button.SetActive(true);
    }
}
