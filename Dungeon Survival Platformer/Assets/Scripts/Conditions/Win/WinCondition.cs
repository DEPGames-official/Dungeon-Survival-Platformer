using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField]
    List<string> enemyTags;

    [SerializeField]
    GameObject WinMenu;

    //Doing this because the pause feature doesn't work properly for some reason when clicking "Restart button" and don't have much time at this point
    [SerializeField]
    List<string> enemyTagsToFreeze;
    
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
                
                for (int k = 0; k < enemyTagsToFreeze.Count; k++)
                {
                    var enemiesToFreeze = GameObject.FindGameObjectsWithTag(enemyTagsToFreeze[k]);
                    
                    foreach(GameObject enemyObjects in enemiesToFreeze)
                    {
                        enemyObjects.SetActive(false);
                    }
                }

                    WinMenu.SetActive(true);
            }
        }
    }
}
