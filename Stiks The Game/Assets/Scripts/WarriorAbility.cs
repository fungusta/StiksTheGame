using System.Collections;
using UnityEngine;

/*
 * Author: Peter
 * Date: 7 Aug 2022
 * 
 * Class that deals with the warrior class abilities and their interactions
 */
public class WarriorAbility : MonoBehaviour //cannot implement Interface unless get rid of coroutine
{
    /*
     * Player variables
     */
    public ImprovedPlayerController player;
    public PlayerHealth health;

    /*
     * Variables for first Skill
     */
    //Duration of first Skill
    public float firstSkillDuration;

    //Increase in speed of player
    public float firstSkillSpeedBoost;

    //Health regen per second during skill
    public int firstSkillHealthRegen;

    //Cooldown after skill
    public float firstSkillCooldown;

    //Boolean whether first is still active
    public bool firstActive;

    //Boolean whether first is still on cooldown
    public bool firstCooldown;

    //Animator for first Skill
    public Animator firstSkillAnimator;

    //SoundFX for first Skill
    public AudioSource firstSkillSoundFX;

    //Collider for burn of first Skill
    public Transform playerPos;
    public LayerMask enemyLayers;

    //Damage and range for burn of first skill
    public float burnRange;
    public int burnDamage;

    /*
     * Variables for second Skill
     */
    //Damage Reduction of second skill
    public float secondSkillDmgRed;

    //Duration of second skill
    public float secondSkillDuration;

    //Cooldown of second skill
    public float secondSkillCooldown;

    //Boolean whether second skill is active
    public bool secondActive;

    //Boolean whether second skill is on cooldown
    public bool secondCooldown;

    //Range in a circle around player for reflect
    public float reflectRange;

    //Animator for second Skill
    public Animator secondSkillAnimator;

    //SoundFX for second Skill
    public AudioSource secondSkillSoundFX;

    


    private void Start()
    {
        //Update these values to update skill values
        firstSkillDuration = 3f;
        firstSkillSpeedBoost = 20f;
        firstSkillHealthRegen = 20;
        firstSkillCooldown = 5f;
        firstActive = false;
        firstCooldown = false;
        burnRange = 4f;
        burnDamage = 10;
        secondSkillDmgRed = 0.5f;
        secondSkillDuration = 0.5f;
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
            // Call function every sec
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

    //First Skill: Fiery Heart (Currently hardcoded looking to be update)
    public void FirstSkill()
    {
        if (!firstCooldown)
        {
            firstSkillAnimator.SetBool("Skill_1", true);
            firstSkillSoundFX.Play();
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
        firstSkillAnimator.SetBool("Skill_1", false);


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

    //Second Skill: Shields Up (Currently hardcoded looking to be update)
    public void SecondSkill()
    {
        if(!secondCooldown)
        {
            firstSkillAnimator.SetBool("Skill_2", true);
            health.DamageReduction(secondSkillDmgRed);
            secondActive = true;
            secondCooldown = true;
            secondSkillSoundFX.Play();
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
        firstSkillAnimator.SetBool("Skill_2", false);
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

