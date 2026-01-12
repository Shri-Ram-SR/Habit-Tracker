using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HabitProfile : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Txt_Name;
    [SerializeField] Image EditButton;
    [SerializeField] Image DeleteButton;
    [SerializeField] Image DeleteConfirmationButton;
    int Index;
    bool DeleteConfirmation;

    public void Setup(int ind,string name,ColorCombination CC)
    {
        Index = ind;
        Txt_Name.text = name;

        GetComponent<Image>().color = CC.BgColor;
        EditButton.color = CC.InfoColor;
        DeleteButton.color = CC.InfoColor;
        DeleteConfirmationButton.color = CC.InfoColor;

        DeleteConfirmationButton.gameObject.SetActive(false);
    }
    public void Delete()
    {
        if (!DeleteConfirmation)
        {
            DeleteConfirmation = true;
            DeleteButton.gameObject.SetActive(false);
            DeleteConfirmationButton.gameObject.SetActive(true);
            Invoke("RevertDeleteConfirmation", 5);
        }
        else
        {
            DeleteConfirmation = false;
            DeleteButton.gameObject.SetActive(true);
            HabitManager.instance.DeleteHabit(Index);
        }
    }
    void RevertDeleteConfirmation()
    {
        DeleteConfirmation = false;
        DeleteButton.gameObject.SetActive(true);
        DeleteConfirmationButton.gameObject.SetActive(false);
    }
    public void EditInteracted()
    {
        EditHabit.instance.SetUp(Index);
    }
}
