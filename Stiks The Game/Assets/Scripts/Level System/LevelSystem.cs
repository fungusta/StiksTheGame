using UnityEngine;

/*
 * Author: Peter
 * Date: 7 Aug 2022
 * This class encapsulates the level system that the player has in the game and
 * deals with exp gain as well as current level and skill points availability.
 */
public class LevelSystem : MonoBehaviour
{
    /*
     * Maximum Experience for the player to level up to next level.
     */
    public int maxExp;

    /*
     * Current Experience of the player.
     */
    public int currentExp;

    /*
     * Current Level of the player.
     */
    public int level;

    /*
     * UI Exp Bar that follows the current experience the player has
     */
    public EXPBar expBar;

    /*
     * Class that deals with the changing of levels
     */
    public ChangeLevel levelChange;

    /*
     * Skill Tree Connected to the player 
     */
    public SkillTreeEffects skillTree;

    /*
     * Sound of leveling up
     */
    public AudioSource levelUpSound;


    // Start is called before the first frame update
    void Start()
    {
        maxExp = 5;
        currentExp = 0;
        level = 1;
    }

    /*
     * Function that takes in a certain amount of exp and adds it to the player
     */
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

    /*
     * Function that is called when the player is levelled up to increase skill
     * points as well as update max exp and current exp, while also player the
     * level up audio
     */
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

    /*
     * Function that returns current skill points available to be used 
     */
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
