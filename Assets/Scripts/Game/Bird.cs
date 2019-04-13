using UnityEngine;
using System.Collections;
using Assets.Scripts;

[RequireComponent(typeof(Rigidbody2D))]
public class Bird : MonoBehaviour
{
    AudioManagerGame audio;
    bool cambio = false;
    float minDistance = 3f;

    private void Awake()
    {
        audio = GameObject.Find("AudioManager").GetComponent<AudioManagerGame>();
    }
    // Use this for initialization
    void Start()
    {
        
        //trailRenderer no es visible si no se ha tirado
        GetComponent<TrailRenderer>().enabled = false;
        GetComponent<TrailRenderer>().sortingLayerName = "Foreground";
        //no gravedad al comienzo
        GetComponent<Rigidbody2D>().isKinematic = true;
        GetComponent<mruv>().activado = false;
        State = BirdState.BeforeThrown;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Activar el rozamiento cuando collisione con el suelo
        if (collision.gameObject.tag == "Floor")
        {
            GetComponent<mruv>().friccion = true;
        }
    }


    void FixedUpdate()
    {
        if (name == "GreenBird" && State == BirdState.Thrown)
        {
            var mruv = GetComponent<mruv>();
            var mcu = GetComponent<MCU>();
            if (Input.GetButtonDown("Fire1"))
            {
                var hook = GameObject.FindGameObjectWithTag("Hook");
                float distance = Vector3.Distance(transform.position, hook.transform.position);
                if(distance <= minDistance)
                {
                    GetComponent<MCU>().EstablecerCentro(hook.transform.position, Time.time, GetComponent<mruv>().velocidadFinal);
                    GetComponent<MCU>().activado = true;
                    GetComponent<mruv>().activado = false;
                }
                
            }
            else if (Input.GetButtonUp("Fire1") && GetComponent<MCU>().activado)
            {
                mcu.ultimaVez = Time.realtimeSinceStartup;
                mruv.cambioPosicion = Vector3.zero;
                mruv.velocidadFinal = mcu.velocidadFinal;
                float angulo = mcu.angulo;
                angulo += (Mathf.PI / 2) * (angulo < 0 ? -1 : 1);
                mruv.CambiarVelocidad(angulo);
                mcu.activado = false;
                mruv.activado = true;
            }
        }

        //Si fue lanzado con un velocidad muy pequeña
        //se destruye
        if (State == BirdState.Thrown &&
            GetComponent<mruv>().velocidadFinal.sqrMagnitude <= Constants.MinVelocity)
        {
            if(name == "GreenBird" && !GetComponent<MCU>().activado)
            {
                Destroy(gameObject, 2);
            }
            else if (name == "RedBird")
            {
                Destroy(gameObject, 2);
            }
            
        }
        if (transform.position.x > 12f && GetComponent<mruv>().activado)
        {
            Vector3 velocity = GetComponent<mruv>().velocidadFinal;
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x, velocity.y);
            GetComponent<Rigidbody2D>().gravityScale = 1;
            GetComponent<mruv>().activado = false;
        }
    }

    public void OnThrow()
    {
        //sonar el Tiro
        audio.playTiro();
        //activar el trailRenderer
        GetComponent<TrailRenderer>().enabled = true;
        //allow for gravity forces
        GetComponent<Rigidbody2D>().isKinematic = false;
        //Establecer el collider a un radio normal
        GetComponent<CircleCollider2D>().radius = Constants.BirdColliderRadiusNormal;
        State = BirdState.Thrown;
    }

    public BirdState State
    {
        get;
        private set;
    }
}
