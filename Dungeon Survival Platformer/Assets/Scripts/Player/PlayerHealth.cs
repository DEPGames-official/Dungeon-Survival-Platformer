using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float currHealth = 100;
    public float maxHealth = 500;

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
            ReloadMainLevel();
        }
    }
    public void ReloadMainLevel()
    {
        SceneManager.LoadScene("SampleScene");
        
    }
}
