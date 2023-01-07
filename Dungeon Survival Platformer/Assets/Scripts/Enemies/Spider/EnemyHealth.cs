using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float currHealth = 25;
    public float maxHealth = 25;

    [SerializeField]
    Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currHealth = maxHealth;

        healthBar.maxValue = maxHealth;
        healthBar.value = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.value = currHealth;

        if (currHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
