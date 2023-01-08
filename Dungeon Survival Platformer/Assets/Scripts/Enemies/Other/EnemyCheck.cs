using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCheck : MonoBehaviour
{
    [SerializeField]
    List<string> enemyTags;

    [SerializeField]
    GameObject door;

    void Update()
    {
        for (int i = 0; i < enemyTags.Count; i++)
        {

            var enemyCondition = GameObject.FindGameObjectsWithTag(enemyTags[i]);

            if (enemyCondition.Length == 0)
            {
                enemyTags.Remove(enemyTags[i]);
            }
  
            if (enemyTags.Count == 0)
            {
                door.SetActive(false);
            }


            
        }
        
    }
}
