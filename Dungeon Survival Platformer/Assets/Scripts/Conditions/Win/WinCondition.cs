using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField]
    List<string> enemyTags;

    [SerializeField]
    GameObject WinMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < enemyTags.Count; i++)
        {
            var enemyCondition = GameObject.FindGameObjectsWithTag(enemyTags[i]);
            if (enemyCondition.Length != 0)
            {
                break;
            }
            else
            {
                WinMenu.SetActive(true);
            }
        }
    }
}
