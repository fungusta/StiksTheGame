using UnityEngine;

/*
 * Author: Peter
 * Date: 7 Aug 2022
 * 
 * Class that deals with the effects when skill tree icons become activated.
 */
public class SkillTreeEffects : MonoBehaviour
{
    /*
     * Current player
     */
    public GameObject player;

    /*
     * Health of current player
     */
    private PlayerHealth health;

    /*
     * Abilities of character chosen (to be update to IAbilities when interface
     * has been fully created)
     */
    private WarriorAbility abilities;

    /*
     * Combat numbers of current player
     */
    private PlayerCombat combat;

    /*
     * Warning sign that shows up if there is a lack of skill points
     */
    public WarningSkillTree warning;

    /*
     * Current number of skill points available
     */
    public int skillTreePts;

    private void Start()
    {
        health = player.GetComponent<PlayerHealth>();
        abilities = player.GetComponent<WarriorAbility>();
        combat = player.GetComponent<PlayerCombat>();
        skillTreePts = player.GetComponent<LevelSystem>().GetCurrentSkillPts();
    }

    /*
     * Function that effects the player depending on the name of the skill icon
     */
    //Will be updated to be more efficient with the use interfaces
    public void Effect(string name)
    {
        if (name == "Health I")
        {
            health.ChangeMaxHealth(20);
        }
        else if (name == "FieryHeart I")
        {
            abilities.FirstSkillChangeRegen(10);
        }
        else if (name == "Damage I")
        {
            combat.ChangeAttackDamage(5);
        }
        else if (name == "Durability I")
        {
            abilities.SecondSkillChangeDef(0.2f);
        }
        else if (name == "FieryHeart II")
        {
            abilities.FirstSkillChangeDamage(10);
        }
        else if (name == "Damage II")
        {
            combat.ChangeAttackDamage(10);
        } 
        else if (name == "Reflect I")
        {
            abilities.SecondSkillChangeRefRange(2f);
        }
        else if (name == "Fiery Cooldown I")
        {
            abilities.FirstSkillChangeDur(1f);
        }
        else if (name == "Health II")
        {
            health.ChangeMaxHealth(60);
        }
        else if (name == "Durability Cooldown I")
        {
            abilities.SecondSkillChangeDur(1f);
        }
        else if (name == "Fiery Cooldown II")
        {
            abilities.FirstSkillChangeCooldown(2f);
        }
        else if (name == "Damage III")
        {
            combat.ChangeAttackDamage(30);
        } 
        else if (name == "Durability Cooldown II")
        {
            abilities.SecondSkillChangeCooldown(2f);
        }
    }

    /*
     * Checks if there is enough points to activate a skill point,
     * if yes, returns true, else false.
     */
    public bool PointCheck()
    {
        if(skillTreePts > 0)
        {
            skillTreePts -= 1;
            return true;
        }
        //If 0 skill points, activate the warning message
        warning.ShowWarning();
        return false;
    }

    /*
     * Function that increases current skill points depending on int param input
     */
    public void IncreaseSkillPt(int skillPt)
    {
        skillTreePts += skillPt;
    }
}
