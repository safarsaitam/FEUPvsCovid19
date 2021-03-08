using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D rigidBody;
    private Vector2 moveInput;
    private Animator animator;
    private bool playerMoving;
    public Vector2 lastMove;
    public string startPoint;
    public bool canMove;


    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        canMove = true;
    }


    void Update()
    {
        playerMoving = false;

        if (canMove)
        {
            moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;

            if (moveInput != Vector2.zero)
            {
                playerMoving = true;
                rigidBody.velocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
                lastMove = moveInput;
            }
            else
            {
                rigidBody.velocity = Vector2.zero;
            }

            animator.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
            animator.SetBool("PlayerMoving", playerMoving);
            animator.SetFloat("LastMoveX", lastMove.x);
            animator.SetFloat("LastMoveY", lastMove.y);
        }
    }
}
