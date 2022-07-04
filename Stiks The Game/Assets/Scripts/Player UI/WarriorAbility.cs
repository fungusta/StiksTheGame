using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAbility : MonoBehaviour
{
    public ImprovedPlayerController player;
    public PlayerHealth health;

    //Variables for first Skill
    //Duration of first Skill
    public float firstSkillDuration;

    //Increase in speed of player
    public float firstSkillSpeedBoost;

    //Health regen per second during skill
    public int firstSkillHealthRegen;

    //Cooldown after skill
    public float firstSkillCooldown;
    public bool firstActive;
    public bool firstCooldown;
    
    //Animator for first Skill
    //public Animator animateFirstSkill;

    //Collider for burn
    public Transform playerPos;
    public LayerMask enemyLayers;

    //Damage for first skill
    public float burnRange;
    public int burnDamage;

    //Variables for second Skill

    //Animator for first Skill
    //public Animator animateSecondSkill;

    public float secondSkillDmgRed;
    public float secondSkillDuration;
    public float secondSkillCooldown;
    public bool secondActive;
    public bool secondCooldown;
    public float reflectRange;


    private void Start()
    {
        firstSkillDuration = 5f;
        firstSkillSpeedBoost = 20f;
        firstSkillHealthRegen = 20;
        firstSkillCooldown = 5f;
        firstActive = false;
        firstCooldown = false;
        burnRange = 4f;
        burnDamage = 10;
        secondSkillDmgRed = 0.5f;
        secondSkillDuration = 5f;
        secondSkillCooldown = 5f;
        secondActive = false;
        secondCooldown = false;
        reflectRange = 5f;
    }
    // Next update in second
    private int nextUpdate = 1;

    // Update is called once per frame
    void Update()
    {

        // If the next update is reached
        if (Time.time >= nextUpdate)
        {
            // Change the next update (current second+1)
            nextUpdate = Mathf.FloorToInt(Time.time) + 1;
            // Call your fonction
            UpdateEverySecond();
        }

    }

    // Update is called once per second
    void UpdateEverySecond()
    {
        if (firstActive)
        {
            FirstSkillBurn();
            health.Regen(firstSkillHealthRegen);
        }

    }

    //First Skill: Fiery Heart
    public void FirstSkillStart()
    {
        if (!firstCooldown)
        {
            player.runSpeed += firstSkillSpeedBoost;
            firstActive = true;
            firstCooldown = true;
            StartCoroutine(FirstSkill(firstSkillDuration, firstSkillCooldown));
        }
    }

    IEnumerator FirstSkill(float firstSkillDur, float firstSkillCd)
    {
        yield return new WaitForSeconds(firstSkillDur);
        //Debug.Log("Wait is over");
        //First Skill Over
        player.runSpeed -= firstSkillSpeedBoost;
        firstActive = false;

        //after the skill ends, the cooldown will start
        yield return new WaitForSeconds(firstSkillCd);
        //Debug.Log("Cooldown Over");
        firstCooldown = false;
    }

    public void FirstSkillBurn()
    {
        // Detect enemies in range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(playerPos.position, burnRange, enemyLayers);
        
        // Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(burnDamage);
        }
    }

    public void FirstSkillChangeRegen(int i)
    {
        firstSkillHealthRegen += i;
    }

    public void FirstSkillChangeDamage(int i)
    {
        burnDamage += i;
    }

    public void FirstSkillChangeDur(float f)
    {
        firstSkillDuration += f;
    }

    public void FirstSkillChangeCooldown(float f)
    {
        firstSkillCooldown -= f;
    }

    //Second Skill: Shields Up
    public void SecondSkill()
    {
        if(!secondCooldown)
        {
            health.DamageReduction(secondSkillDmgRed);
            secondActive = true;
            secondCooldown = true;
            StartCoroutine(SecondSkill(secondSkillDuration, secondSkillCooldown));
        }
    }

    IEnumerator SecondSkill(float secondSkillDur, float SecondSkillCd)
    {
        yield return new WaitForSeconds(secondSkillDur);
        //Debug.Log("Wait is over");
        secondActive = false;
        health.DamageReduction();

        //after the skill ends, the cooldown will start
        yield return new WaitForSeconds(SecondSkillCd);
        //Debug.Log("Cooldown Over");
        secondCooldown = false;
    }
    public void Reflect(int reflectDmg)
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(playerPos.position, reflectRange, enemyLayers);

        // Damage them
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(reflectDmg);
        }
    }

    public void SecondSkillChangeDef(float i)
    {
        secondSkillDmgRed += i;
    }

    public void SecondSkillChangeRefRange(float i)
    {
        reflectRange += i;
    }

    public void SecondSkillChangeDur(float i)
    {
        secondSkillDuration += i;
    }

    public void SecondSkillChangeCooldown(float i)
    {
        secondSkillCooldown -= i;
    }
}

