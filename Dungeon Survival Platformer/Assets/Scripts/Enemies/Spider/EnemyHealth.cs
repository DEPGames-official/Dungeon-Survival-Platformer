using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [HideInInspector]
    public float currHealth = 25;
    public float maxHealth = 25;

    [SerializeField]
    bool hasHealthBar;


    [SerializeField]
    Slider healthBar;

    [SerializeField]
    PlayerHealth player;


    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;

        if (hasHealthBar == true)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = maxHealth;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasHealthBar == false && currHealth <= 0)
        {
            gameObject.SetActive(false);
        }
        else if (hasHealthBar == true)
        {
            updateHealth();
            if (currHealth <= 0)
            {
                player.currHealth += 25;
                healthBar.GameObject().SetActive(false);
                gameObject.SetActive(false);
            }
            
            
        }
    }

    void updateHealth()
    {
        healthBar.value = currHealth;
    }
}
