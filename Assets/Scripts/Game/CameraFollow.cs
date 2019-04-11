using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    void Start()
    {
        StartingPosition = transform.position;
    }
    

    void Update()
    {
        if (IsFollowing)
        {
            if(BirdToFollow != null)
            {
                var birdPosition = BirdToFollow.transform.position;
                float x = Mathf.Clamp(birdPosition.x, minCameraX, maxCameraX);
                //la camara sigue a la ave
                transform.position = new Vector3(x, StartingPosition.y, StartingPosition.z);
            }
            
        }
    }

    [HideInInspector]
    public Vector3 StartingPosition;


    private const float minCameraX = 0;
    private const float maxCameraX = 16;
    [HideInInspector]
    public bool IsFollowing;
    [HideInInspector]
    public Transform BirdToFollow;
}
