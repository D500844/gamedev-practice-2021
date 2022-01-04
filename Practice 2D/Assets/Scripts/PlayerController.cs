using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private PlayerActionControls playerActionControls;
    private Rigidbody2D rb;
    private Collider2D col;
    [SerializeField] private float speed, jumpSpeed;
    [SerializeField] private LayerMask ground;

    /// control initializing and start/awake functions  ///////

    private void Awake()
    {
        playerActionControls = new PlayerActionControls();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    private void OnEnable()
    {
        playerActionControls.Enable();
    }

    private void OnDisable()
    {
        playerActionControls.Disable();
    }

    void Start()
    {
        playerActionControls.Land.Jump.performed += _ => Jump(); 
    }

    /// ///////////////////////////////////////////////////////

    private void Jump()
    {
        if (IsGrounded())
        {
            rb.AddForce(new Vector2(0, jumpSpeed), ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        Vector2 topleftPoint = transform.position;
        topleftPoint.x -= col.bounds.extents.x;
        topleftPoint.y += col.bounds.extents.y;

        Vector2 bottomRight = transform.position;
        bottomRight.x += col.bounds.extents.x;
        bottomRight.y -= col.bounds.extents.y;

        return Physics2D.OverlapArea(topleftPoint, bottomRight, ground);

    }

    void Update()
    {
        //read the movement
        float movementInput = playerActionControls.Land.Move.ReadValue<float>();

        //move the player
        Vector3 currentPosition = transform.position;
        currentPosition.x += movementInput * speed * Time.deltaTime;
        transform.position = currentPosition;
    }
}
