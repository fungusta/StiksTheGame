using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAbility : MonoBehaviour
{
    public ImprovedPlayerController player;
    public float firstSkillDuration = 5f;
    public float firstSkillSpeedBoost = 20f;

    public void FirstSkillStart()
    {
        player.runSpeed += firstSkillSpeedBoost;
        StartCoroutine(Wait(firstSkillDuration));
    }

    public void FirstSkillEnd()
    {
        player.runSpeed -= firstSkillSpeedBoost;
    }

    IEnumerator Wait(float timing)
    {
        yield return new WaitForSeconds(timing);
        Debug.Log("Wait is over");
        FirstSkillEnd();
    }
}

