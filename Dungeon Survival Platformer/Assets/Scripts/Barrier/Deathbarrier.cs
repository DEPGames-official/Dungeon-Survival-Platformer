using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathbarrier : MonoBehaviour
{
    [SerializeField]
    PlayerHealth playerHealth;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerHealth.currHealth = 0;
        }

           
    }
}
