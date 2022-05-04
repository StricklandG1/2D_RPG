using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D playerRb;
    Vector2 moveInput;
    [SerializeField] float speed;
    [SerializeField] float xScale = .75f;
    Animator playerAnimator;
    SpriteRenderer playerRenderer;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Run();
    }

    // Handle player movement
    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * speed, moveInput.y * speed);
        
        playerRb.velocity = playerVelocity;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y / 100.0f);
        FlipSprite();
    }

    // Flip player sprite based on direction on the x-axis
    void FlipSprite()
    {
        bool horizontalMovement = Mathf.Abs(playerRb.velocity.x) > Mathf.Epsilon;
        bool verticalMovement = Mathf.Abs(playerRb.velocity.y) > Mathf.Epsilon;
        playerAnimator.SetBool("isRunning", horizontalMovement || verticalMovement);
        if (horizontalMovement)
        {
            float sign = Mathf.Sign(playerRb.velocity.x);
            transform.localScale = new Vector2(sign * xScale, transform.localScale.y);
            //attack.transform.localScale = newVector2(sign * )
        }
    }

    // Change vector to determine movement based on player input. Comes from InputSystem
    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
}
