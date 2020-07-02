using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : PhysicsObject
{
    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis("Horizontal");

        /*----------flip the character------------------*/
        if (move.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else if (move.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        /*----------flip the character end--------------*/
        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y *= 0.5f;
            }
        }

        animator.SetBool("Grounded", grounded);
        animator.SetFloat("HorizontalSpeed", Mathf.Abs(velocity.x) / maxSpeed);
        animator.SetFloat("VerticalVelocity", velocity.y);
        targetVelocity = move * maxSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collectible")
        {
            Destroy(collision.gameObject);
            score++;
            scoreText.text = score.ToString();
        }
    }

    Animator animator;

    int score = 0;
    public Text scoreText;

    private void Awake()
    {
        animator = GetComponent<Animator>();

        scoreText.text = score.ToString();
    }
}