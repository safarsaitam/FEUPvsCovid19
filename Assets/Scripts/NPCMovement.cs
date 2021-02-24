using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour

{
    public float moveSpeed;

    private Rigidbody2D rigidBody;
    private Animator animator;

    private float moveCounter;

    private bool moveRight;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        moveCounter = 0;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        moveCounter += Time.deltaTime;

        if (moveCounter < 4.5 || moveCounter > 6 && moveCounter < 30) {
            moveRight = true;
            rigidBody.velocity = new Vector2(moveSpeed, 0);
        }

        else if(moveCounter > 4.5 && moveCounter < 6 )
        {
            moveRight = false;
            rigidBody.velocity = new Vector2(0, moveSpeed);
        }

        else rigidBody.velocity = Vector2.zero;

        animator.SetBool("MoveRight", moveRight);
    }
}
