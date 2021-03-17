using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardNPCMovement : MonoBehaviour
{
    public float moveSpeed;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;

    private Rigidbody2D myRigidBody;
    private Animator animator;

    public bool isWalking;

    public float walkTime;
    private float walkCounter;
    private float waitCounter;
    public float waitTime;

    private int walkDirection;

    public Collider2D walkZone;
    private bool hasWalkZone;
    public bool canMove;

    private DialogueManager dialogueManager;


    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        dialogueManager = FindObjectOfType<DialogueManager>();

        waitCounter = waitTime;
        walkCounter = walkTime;
        canMove = true;

        chooseDirection();

        if (walkZone != null)
        {
            minWalkPoint = walkZone.bounds.min;
            maxWalkPoint = walkZone.bounds.max;
            hasWalkZone = true;
        }
    }


    void Update()
    {
        canMove = !dialogueManager.dialogActive;

        if (canMove)
        {
            animator.SetFloat("MoveX", 0);
            animator.SetFloat("MoveY", 0);

            if (isWalking)
            {
                walkCounter -= Time.deltaTime;

                switch (walkDirection)
                {
                    case 0:
                        myRigidBody.velocity = new Vector2(0, moveSpeed);
                        if (hasWalkZone && transform.position.y > maxWalkPoint.y)
                        {
                            isWalking = false;
                            waitCounter = waitTime;
                        }
                        animator.SetFloat("MoveY", 1);
                        animator.SetFloat("LastMoveX", 0);
                        animator.SetFloat("LastMoveY", 1);
                        break;
                    case 1:
                        myRigidBody.velocity = new Vector2(moveSpeed, 0);
                        if (hasWalkZone && transform.position.x > maxWalkPoint.x)
                        {
                            isWalking = false;
                            waitCounter = waitTime;
                        }
                        animator.SetFloat("MoveX", 1);
                        animator.SetFloat("LastMoveX", 1);
                        animator.SetFloat("LastMoveY", 0);
                        break;
                    case 2:
                        myRigidBody.velocity = new Vector2(0, -moveSpeed);
                        if (hasWalkZone && transform.position.y < minWalkPoint.y)
                        {
                            isWalking = false;
                            waitCounter = waitTime;
                        }
                        animator.SetFloat("MoveY", -1);
                        animator.SetFloat("LastMoveX", 0);
                        animator.SetFloat("LastMoveY", -1);
                        break;
                    case 3:
                        myRigidBody.velocity = new Vector2(-moveSpeed, 0);
                        if (hasWalkZone && transform.position.x < minWalkPoint.x)
                        {
                            isWalking = false;
                            waitCounter = waitTime;
                        }
                        animator.SetFloat("MoveX", -1);
                        animator.SetFloat("LastMoveX", -1);
                        animator.SetFloat("LastMoveY", 0);
                        break;
                    default:
                        break;
                }

                if (walkCounter < 0)
                {
                    isWalking = false;
                    waitCounter = waitTime;
                }

            }
            else
            {
                waitCounter -= Time.deltaTime;

                myRigidBody.velocity = Vector2.zero;

                if (waitCounter < 0)
                {
                    chooseDirection();
                    switch (walkDirection)
                    {
                        case 0:
                            animator.SetFloat("MoveY", 1);
                            animator.SetFloat("LastMoveY", 1);
                            break;
                        case 1:
                            animator.SetFloat("MoveX", 1);
                            animator.SetFloat("LastMoveX", 1);
                            break;
                        case 2:
                            animator.SetFloat("MoveY", -1);
                            animator.SetFloat("LastMoveY", -1);
                            break;
                        case 3:
                            animator.SetFloat("MoveX", -1);
                            animator.SetFloat("LastMoveX", -1);
                            break;
                        default:
                            break;
                    }
                }
            }

            animator.SetBool("PlayerMoving", isWalking);
        } else {
            animator.SetBool("PlayerMoving", false);
            myRigidBody.velocity = Vector2.zero;
        }
    }

    public void chooseDirection()
    {
        walkDirection = Random.Range(0, 4);
        // Debug.Log("New direction is " + walkDirection);
        isWalking = true;
        walkCounter = walkTime;
    }
}
