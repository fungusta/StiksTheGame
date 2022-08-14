using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Author: Jason
 * Date: 10 Aug 2022
 * 
 * Class that deals with the implementation of movement
 */


public class ImprovedPlayerController : MonoBehaviour
{
	// calls another script that deals with movement
	public CharacterController2D controller;

	public Animator animator;
	public WarriorAbility abilities; //change to IAbilities after fixing coroutine issues

	// runspeed of player
	public float runSpeed; 

	float horizontalMove = 0f;
	bool jump = false;
	bool crouch = false;

	// Update is called once per frame
	void Update()
	{
		// movement left and right
		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

		// input to jump + animation
		if (Input.GetButtonDown("Jump"))
		{
			jump = true;
			animator.SetBool("IsJumping", true);
		}

		//crouch input to crouch + animation
		if (Input.GetButtonDown("Crouch"))
		{
			crouch = true;
		}
		else if (Input.GetButtonUp("Crouch"))
		{
			crouch = false;
		}

		//for first skill
		if (Input.GetKeyDown(KeyCode.Z))
        {
			abilities.FirstSkill();
		}

		// for second skill
		if (Input.GetKeyDown(KeyCode.X))
        {
			abilities.SecondSkill();
        }
	}
	// landing animation
	public void OnLanding()
	{
		animator.SetBool("IsJumping", false);
	}

	//crouching animation
	public void OnCrouching(bool isCrouching)
	{
		animator.SetBool("IsCrouching", isCrouching);
	}

	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
		jump = false;
	}


}
