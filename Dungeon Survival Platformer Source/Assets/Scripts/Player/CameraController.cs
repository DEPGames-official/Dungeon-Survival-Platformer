using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    Transform playerTransform;
    
    void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y + 1.5f, transform.position.z);
    }
}
