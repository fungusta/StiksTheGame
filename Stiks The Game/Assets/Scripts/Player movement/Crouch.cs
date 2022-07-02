using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crouch : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D Me;
    public SpriteRenderer SpriteRenderer;

    public Sprite Standing;
    public Sprite Crouching;

    public BoxCollider2D Collider;

    public Vector2 StandingSize;
    public Vector2 CrouchingSize;

    public float speed;

    float MovementX;
    float MovementY;
    void Start()
    {
        Me = GetComponent<Rigidbody2D>();
        Collider = GetComponent<BoxCollider2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();

        SpriteRenderer.sprite = Standing;
        StandingSize = Collider.size;

    }

    // Update is called once per frame
    void Update()
    {
        MovementX = Input.GetAxisRaw("Horizontal");
        MovementY = Input.GetAxisRaw("Vertical");
        

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            SpriteRenderer.sprite = Crouching;
            Collider.size = CrouchingSize;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            SpriteRenderer.sprite = Standing;
            Collider.size = StandingSize;
        }
    }
}
