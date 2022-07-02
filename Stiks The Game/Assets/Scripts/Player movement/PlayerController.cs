using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController2D controller;
    public float speed = 5f;
    public float jumpForce = 3f;
    public float playerFeetRadius = 0.2f;
    private float horizontalMove= 0f;
    private bool isGrounded = false;

    private bool crouch = false;
    private bool jump = false;

    public Transform playerFeet;
    public LayerMask groundLayer;
    private Rigidbody2D playerRb;
    public BoxCollider2D Collider;

    public SpriteRenderer SpriteRenderer;

    public Sprite Standing;
    public Sprite Crouching;
    public Vector2 StandingSize;
    public Vector2 CrouchingSize;


    public float hangTime = 0.2f;
    public float hangCounter;

    public void OnLanding()
    {
        playerAnimator.SetBool("IsJumping", false);
    }
    public void OnCrouching(bool isCrouching)
    {
        playerAnimator.SetBool("IsCrouching", isCrouching);
    }

    // Start is called before the first frame update
    private Animator playerAnimator;
    private void Start()
    {
        //Get reference to rigidbody component for left right movement and jumping
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        SpriteRenderer = GetComponent<SpriteRenderer>();

        SpriteRenderer.sprite = Standing;
        StandingSize = Collider.size;
    }

    // Update is called once per frame
    void Update()
    {

        //Get direction keypress from user
        horizontalMove = Input.GetAxisRaw("Horizontal");
        playerAnimator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        //Move the player
        if (horizontalMove != 0)
        {
            playerRb.velocity = new Vector2(horizontalMove * speed, playerRb.velocity.y);
        }
        else
        {
            playerRb.velocity = new Vector2(0, playerRb.velocity.y);
        }

        //Character to face correct direction
        if (horizontalMove > 0) //moving right
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
        else if (horizontalMove < 0) //moving left
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
        }

        //Check if player is grounded
        isGrounded = Physics2D.OverlapCircle(playerFeet.position, playerFeetRadius, groundLayer);
        playerAnimator.SetBool("Jumping", !isGrounded);

        /*
        if(isGrounded)
        {
            hangCounter = hangTime;
        } else
        {
            hangCounter -= Time.deltaTime;
        }
        */

        //Handle player jumping, player jumps when jump key is pressed and its not midair
        if (Input.GetButtonDown("Jump") && isGrounded) //hangCounter > 0)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
        }

        if (Input.GetButtonUp("Jump") && playerRb.velocity.y > 0)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, playerRb.velocity.y * .5f);
        }
        if (Input.GetButtonDown("Crouch"))
        {
            
            SpriteRenderer.sprite = Crouching;
            Collider.size = CrouchingSize;
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            
            SpriteRenderer.sprite = Standing;
            Collider.size = StandingSize;
            crouch = false;
        }

        
        
    }
    

}
