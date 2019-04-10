using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCamera : MonoBehaviour
{
    public bool siguiendo;
    public Transform birds;
    public Vector3 StartingPosition;
    private const float minCameraX = 0;
    private const float maxCameraX = 13;
    void Start()
    {
        
    }
    

    void Update()
    {
        if (siguiendo)
        {
            Vector3 pos = birds.position;
            pos.z = transform.position.z;
            pos.y = transform.position.y;
            transform.position = pos;
        }
    }
}
