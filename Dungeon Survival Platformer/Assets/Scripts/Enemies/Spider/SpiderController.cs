using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderController : MonoBehaviour
{
    [SerializeField]
    GameObject player;
    
    [SerializeField]
    float speed = 20;
    [SerializeField]
    float rotationModifier = 90;

    [SerializeField]
    ProjectileBehaviour projectilePrefab;
    [SerializeField]
    Transform launchOffset;

    Animator anim;


    [SerializeField]
    float shootTimer;
    float shootTimerBackup;

    enum MovementState { idle_top, attack_top, walking_top, dying_top }
    MovementState state;

    private void Start()
    {
        anim = GetComponent<Animator>();
        shootTimerBackup = shootTimer;
    }

    private void Update()
    {
        UpdateAnimationState();
        ShootPlayer();
        
    }

    void FixedUpdate()
    {
        RotateToPlayer();
    }

    void RotateToPlayer()
    {
        if (player != null)
        {
            Vector3 vectorToTarget = player.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * speed);
        }
    }

    void ShootPlayer()
    {

        state = MovementState.idle_top;
        shootTimer -= Time.deltaTime;
        while (shootTimer <= 0)
        {
            state = MovementState.attack_top;
            Instantiate(projectilePrefab, launchOffset.position, transform.rotation);
            shootTimer = shootTimerBackup;
        }
    }
    void UpdateAnimationState()
    {
        
        anim.SetInteger("state", (int)state);
    }
}
