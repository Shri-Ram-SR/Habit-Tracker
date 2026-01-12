using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WindowSwitchButton : MonoBehaviour
{
    [SerializeField] Image BG_Panel;
    [SerializeField] Image Icon;
    [SerializeField] List<WindowSwitchButton> OtherButtons;

    [SerializeField] Animator Ani;
    public bool Active;
    static string prev;
    private void Start()
    {
        if (Active)
            ToggleActive();
        prev = "1";
    }
    public void ButtonClick(string n)
    {
        if (!Active)
        {
            Active = true;
            foreach(WindowSwitchButton button in OtherButtons)
            {
                if(button.Active) 
                    button.ToggleActive();
                button.Active = false;
            }
            ToggleActive();
            Ani.SetTrigger(prev+n);
            prev = n;
        }
    }
    public void ToggleActive()
    {
        Color c = BG_Panel.color;
        BG_Panel.color = Icon.color;
        Icon.color = c;
    }
}
