using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class Ave : MonoBehaviour
{
    public bool isGrounded;
    public float mass;
    bool dentro;
    public TrailRenderer trail;
    public LineRenderer line;
    AudioManagerGame audio;

    private void Awake()
    {
        audio = GameObject.Find("AudioManager").GetComponent<AudioManagerGame>();
        trail = GetComponent<TrailRenderer>();
        line = GetComponent<LineRenderer>();
    }

    void Start()
    {
        trail.enabled = false;
        dentro = false;
        mass = 0.5f;
        isGrounded = true;
    }
    

    void fixedUpdate()
    {
        if(State == BirdState.Thrown && GetComponent<Rigidbody2D>().velocity.sqrMagnitude <= Constants.MinVelocity)
        {
            print("Destruir");
            StartCoroutine(DestroyAfter(2));
        }
    }

    private void OnMouseEnter()
    {
        dentro = true;
    }
    private void OnMouseExit()
    {
        dentro = false;
    }
    public void OnThrow()
    {
        //play the sound
        audio.playTiro();
        //show the trail renderer
        GetComponent<TrailRenderer>().enabled = true;
        //make the collider normal size
        GetComponent<CircleCollider2D>().radius = Constants.BirdColliderRadiusNormal;
        State = BirdState.Thrown;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
            GetComponent<mruv>().friccion = true;

        }
        else if (collision.gameObject.tag == "Brick")
        {
            GetComponent<Rigidbody2D>().velocity = GetComponent<mruv>().velocidadFinal;
            GetComponent<Rigidbody2D>().gravityScale = 1;
            GetComponent<mruv>().velocidadFinal = Vector3.zero;
        }
    }

    IEnumerator DestroyAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(gameObject);
    }

    public BirdState State
    {
        get;
        private set;
    }
}
