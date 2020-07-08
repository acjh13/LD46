using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum facingDirection
{
    Up,
    Down, 
    Left,
    Right
}

public class TopDownPlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public Sprite IdleFront, IdleBack, IdleLeft, IdleRight, AttackFront, AttackBack, AttackLeft, AttackRight;
    private Rigidbody2D rb;
    private SpriteRenderer playerTexture;
    private AttackLogic attackScript;
    private Vector2 moveVelocity;
    private float horizontalInput, verticalInput;
    private facingDirection dir = facingDirection.Down;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerTexture = GetComponent<SpriteRenderer>();
        attackScript = GetComponent<AttackLogic>();
    }

    void UpdateMovement()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        Vector2 moveInput = new Vector2(horizontalInput, verticalInput);
        moveVelocity = moveInput.normalized * speed;

        if (horizontalInput == 0f && verticalInput == 0f)
        {
            return;
        }
        else
        {
            if (Mathf.Abs(verticalInput) >= Mathf.Abs(horizontalInput))
            {
                // moving horizontally faster
                if (verticalInput < 0) // down or not moving
                {
                    dir = facingDirection.Down;
                }
                else
                {
                    dir = facingDirection.Up;
                }
            }
            else
            {
                if (horizontalInput > 0)
                {
                    dir = facingDirection.Right;
                }
                else if (horizontalInput < 0)
                {
                    dir = facingDirection.Left;
                }
            }
        }

        // change texture
        switch(dir)
        {
            case facingDirection.Up:
                playerTexture.sprite = IdleBack;
                break;

            case facingDirection.Down:
                playerTexture.sprite = IdleFront;
                break;

            case facingDirection.Left:
                playerTexture.sprite = IdleLeft;
                break;

            case facingDirection.Right:
                playerTexture.sprite = IdleRight;
                break;

            default:
                break;
        }
    }

    void Update()
    {
        UpdateMovement();

        // checks for "attack"
        if (Input.GetButtonDown("Attack"))
        {
            switch(dir)
            {
                case facingDirection.Up:
                    playerTexture.sprite = AttackBack;
                    break;

                case facingDirection.Down:
                    playerTexture.sprite = AttackFront;
                    break;

                case facingDirection.Left:
                    playerTexture.sprite = AttackLeft;
                    break;

                case facingDirection.Right:
                    playerTexture.sprite = AttackRight;
                    break;

                default:
                    break;
            }
            attackScript.Shout(true, dir);
        }
        else if (Input.GetButtonUp("Attack"))
        {
            attackScript.Shout(false, dir);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }
}
