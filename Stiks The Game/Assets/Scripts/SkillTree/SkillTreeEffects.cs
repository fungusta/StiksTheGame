using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeEffects : MonoBehaviour
{
    public GameObject player;
    private PlayerHealth health;
    private WarriorAbility abilities;
    private PlayerCombat combat;
    public WarningSkillTree warning;
    public int skillTreePts;

    private void Start()
    {
        health = player.GetComponent<PlayerHealth>();
        abilities = player.GetComponent<WarriorAbility>();
        combat = player.GetComponent<PlayerCombat>();
        skillTreePts = player.GetComponent<LevelSystem>().level;
    }


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

    public bool PointCheck()
    {
        if(skillTreePts > 0)
        {
            skillTreePts -= 1;
            return true;
        }
        warning.ShowWarning();
        return false;
    }

    public void IncreaseSkillPt(int skillPt)
    {
        skillTreePts += skillPt;
    }
}
