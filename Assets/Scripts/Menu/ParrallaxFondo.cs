using UnityEngine;
using System.Collections;

public class ParrallaxFondo : MonoBehaviour
{
    public Transform obj;
    void Start()
    {
        obj = GameObject.Find("ObjetoMoviendose").transform;
    }
    

    /// <summary>
    /// La misma mecanica de  "CameraMove" script
    /// </summary>
    void Update()
    {
        Vector3 delta = obj.transform.position - previousCameraTransform;
        delta.y = 0; delta.z = 0;
        transform.position += delta / ParallaxFactor;

        if(transform.position.x >= 30f)
        {
            Vector3 pos = obj.position;
            pos.x = -15f;
            transform.position = pos;
        }
        previousCameraTransform = obj.transform.position;
    }

    public float ParallaxFactor;

    Vector3 previousCameraTransform;

    
}
