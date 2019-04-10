using UnityEngine;
using System.Collections;

public class ParallaxScrolling : MonoBehaviour {
    
	void Start () {
        camera = Camera.main;
        previousCameraTransform = camera.transform.position;
	}

    Camera camera;
	
	/// <summary>
	/// La misma mecanica de  "CameraMove" script
	/// </summary>
	void Update () {
        Vector3 delta = camera.transform.position - previousCameraTransform;
        delta.y = 0; delta.z = 0;
        transform.position += delta / ParallaxFactor;


        previousCameraTransform = camera.transform.position;
	}

    public float ParallaxFactor;

    Vector3 previousCameraTransform;

    ///background graphics found here:
    ///http://opengameart.org/content/hd-multi-layer-parallex-background-samples-of-glitch-game-assets
}
