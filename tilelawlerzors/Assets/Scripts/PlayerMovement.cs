using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 6f;

    Vector2 moveInput;
    Rigidbody2D myrigidbody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    BoxCollider2D myFeetCollider;
    float gravityScaleAtStart;

    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        myFeetCollider = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = myrigidbody.gravityScale;
    }

    void Update()
    {
        Run();
        FlipSprite();
        ClimbLadder();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);
    }

    void OnJump(InputValue value)
    {
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }

        if (value.isPressed)
        {
            myrigidbody.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void Run()
    {

        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myrigidbody.velocity.y);
        myrigidbody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myrigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHasHorizontalSpeed);

    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myrigidbody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(myrigidbody.velocity.x), 1f);
        }
    }

    void ClimbLadder()
    {
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ladder")))
        {
            myrigidbody.gravityScale = gravityScaleAtStart;
            myAnimator.SetBool("isClimbing", false);
            return;
        }

        Vector2 climbVelocity = new Vector2 (myrigidbody.velocity.x, moveInput.y * climbSpeed);
        myrigidbody.velocity = climbVelocity;
        myrigidbody.gravityScale = 0f;

        bool playerHasVerticalSpeed = Mathf.Abs(myrigidbody.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("isClimbing", true);
        myAnimator.SetBool("isRunning", false);
    }
}
