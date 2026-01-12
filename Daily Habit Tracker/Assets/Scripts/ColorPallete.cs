using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ColorPallete : ScriptableObject
{
    public List<ColorCombination> Combinations;
    public ColorCombination GetColor(string n)
    {
        foreach(ColorCombination cc in Combinations)
        {
            if(cc.Name == n)
                return cc;
        }

        return null;
    }
}
[System.Serializable]
public class ColorCombination
{
    public string Name;
    public Color BgColor;
    public Color InfoColor;
}