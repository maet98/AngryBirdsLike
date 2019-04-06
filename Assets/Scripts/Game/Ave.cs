using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ave : MonoBehaviour
{
    public bool isGrounded;
    public float mass;
    bool dentro;
    public TrailRenderer trail;
    public LineRenderer line;

    private void Awake()
    {
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
    

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && dentro)
        {
            GameObject.Find("ScriptsGlobales").GetComponent<ControlJuego>().setActual(gameObject);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
            GetComponent<mruv>().friccion = true;

        }
        else if (collision.gameObject.tag == "Brick")
        {
            GetComponent<Rigidbody2D>().velocity = GetComponent<mruv>().velocidadFinal;
            GetComponent<mruv>().velocidadFinal = Vector3.zero;
        }
    }
}
