using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 3f;
    public float playerFeetRadius = 0.2f;
    private float direction = 0f;
    private bool isGrounded = false;

    public Transform playerFeet;
    public LayerMask groundLayer;
    private Rigidbody2D playerRb;

    public float hangTime = 0.2f;
    public float hangCounter;

    // Start is called before the first frame update
    private Animator playerAnimator;
    private void Start()
    {
        //Get reference to rigidbody component for left right movement and jumping
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //Get direction keypress from user
        direction = Input.GetAxis("Horizontal");
        playerAnimator.SetFloat("Speed", Mathf.Abs(direction));

        //Move the player
        if (direction != 0)
        {
            playerRb.velocity = new Vector2(direction * speed, playerRb.velocity.y);
        }
        else
        {
            playerRb.velocity = new Vector2(0, playerRb.velocity.y);
        }

        //Character to face correct direction
        if (direction > 0) //moving right
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
        }
        else if (direction < 0) //moving left
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
    }
}
