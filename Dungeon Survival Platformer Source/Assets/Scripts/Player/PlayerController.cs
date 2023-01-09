using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    float movementSpeed = 2f;
    [SerializeField]
    float jumpHeight = 5f;
    
    float dirX;


    [SerializeField]
    LayerMask jumpableGround;

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;
    Animator anim;
    BoxCollider2D coll;
    Vector3 transformScale;

    enum MovementState { idle, running, jumping, falling, attacking}
    MovementState state;

    [SerializeField]
    Transform attackPoint;
    public float attackRange = 0.5f;
    [SerializeField]
    LayerMask spiderLayers;

    public AudioClip attackSound_one, attackSound_two, jumpSound;
    [SerializeField]
    AudioSource audioSource;

    Random random = new Random();

    private void Start()
    {
        transformScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        
        dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * movementSpeed, rb.velocity.y);


        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            PlayAudioSource(jumpSound);
            rb.velocity = new Vector2(0f, jumpHeight);
        }
        UpdateAnimationState();
    }

    void UpdateAnimationState()
    {

        if (dirX > 0f)
        {
            state = MovementState.running;
            transform.localScale = new Vector3(transformScale.x, transformScale.y, transformScale.z);
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            transform.localScale = new Vector3(-transformScale.x, transformScale.y, transformScale.z);
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Attack();
        }

        anim.SetInteger("state", (int)state);
    }

    bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f,jumpableGround);
    }

    void Attack()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            int randomAttack = random.Next(0, 2);

            switch (randomAttack)
            {
                case 0:
                    PlayAudioSource(attackSound_one);
                    break;
                case 1:
                    PlayAudioSource(attackSound_two);
                    break;
            }

            

            state = MovementState.attacking;
            Collider2D[] hitSpiders = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, spiderLayers);

            foreach (Collider2D enemy in hitSpiders)
            {
                var enemyHealth = enemy.gameObject.GetComponent<EnemyHealth>();
                enemyHealth.currHealth -= 25;


            }
        }
        
    }

    void PlayAudioSource(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
