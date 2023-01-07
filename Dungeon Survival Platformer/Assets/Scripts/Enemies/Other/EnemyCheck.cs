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
            if (enemyCondition.Length != 0)
            {
                break;
            }
            else
            {
                door.SetActive(false);
            }
        }
    }
}
