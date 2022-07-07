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
    public SkillTreeEffects skillTree;
    public AudioSource levelUpSound;
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
            currentExp = (currentExp + exp) - maxExp;
            LevelUp();
        } else
        {
            //Debug.Log("Exp taken in");
            currentExp += exp;
            expBar.SetExp(currentExp);
        }
    }

    public void LevelUp()
    {
        //Debug.Log("Level Up");
        skillTree.IncreaseSkillPt(level);
        level += 1;
        maxExp *= 2;
        expBar.SetMaxExp(maxExp);
        levelChange.LevelChange(level);
        expBar.SetExp(currentExp);
        levelUpSound.Play();
    }

    public int GetCurrentSkillPts()
    {
        int currentLevel = level;
        int temp = 1;
        for(int i = 0; i < currentLevel; i++)
        {
            temp += i;
        }
        return temp;
    }
}
