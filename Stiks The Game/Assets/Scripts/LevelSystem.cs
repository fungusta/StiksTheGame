using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    public int maxExp;
    public int currentExp;
    public int level;

    public EXPBar expBar;
    public ChangeLevel levelChange;
    // Start is called before the first frame update
    void Start()
    {
        maxExp = 5;
        currentExp = 0;
        level = 1;
    }

    public void GainExp(int exp)
    {
        if(maxExp <= (currentExp + exp))
        {
            LevelUp();
            currentExp = (currentExp + exp) - maxExp;
            expBar.SetExp(currentExp);
        } else
        {
            Debug.Log("Exp taken in");
            currentExp += exp;
            expBar.SetExp(currentExp);
        }
    }

    public void LevelUp()
    {
        level += 1;
        maxExp *= 2;
        expBar.SetMaxExp(maxExp);
        levelChange.LevelChange(level);
    }
}
