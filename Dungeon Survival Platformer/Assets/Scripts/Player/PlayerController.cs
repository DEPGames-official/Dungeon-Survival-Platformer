using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float movementSpeed = 2f;
    [SerializeField]
    float jumpHeight = 5f;

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator anim;

    [SerializeField]
    float dirX;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * movementSpeed, rb.velocity.y);


        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(0, jumpHeight);
        }
        AnimationUpdate();
    }

    void AnimationUpdate()
    {
        if (dirX > 0)
        {
            anim.SetBool("running", true);
            spriteRenderer.flipX = false;
        }
        else if (dirX < 0)
        {
            anim.SetBool("running", true);
            spriteRenderer.flipX = true;
        }
        else
        {
            anim.SetBool("running", false);
        }
    }
}
