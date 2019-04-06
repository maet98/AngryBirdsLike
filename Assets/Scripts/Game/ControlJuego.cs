using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlJuego : MonoBehaviour
{

    
    public enum Estados
    {
        SinAgarrar,
        Agarrado,
        Disparado
    }
    public CameraFollow cameraFollow;
    Vector3 referencia;
    public Estados Estado { get; set; }
    float force = 10f;
    Vector3 velocidad;
    LineRenderer line;
    
    bool moveAnimation = false;
    GameObject actual;

    void Start()
    {
        cameraFollow = Camera.main.GetComponent<CameraFollow>();
        Estado = Estados.SinAgarrar;
        var pos = GameObject.Find("slingshot_left").transform.position;
        referencia = new Vector3(pos.x - 1.2f, pos.y + 1, pos.z);
    }


    void Update()
    {
        switch (Estado)
        {
            case Estados.SinAgarrar:
                
                if (moveAnimation)
                {
                    actual.transform.position = Vector3.MoveTowards(actual.transform.position, referencia, 0.1f);
                    if (actual.transform.position == referencia)
                    {
                        moveAnimation = false;
                        Estado = Estados.Agarrado;
                    }
                }

                break;
            case Estados.Agarrado:
                Vector3 position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                position.z = 0;
                if (Vector3.Distance(referencia, position) < 5f)
                {
                    actual.transform.position = position;
                }
                calcularLineaFuturo();
                if (Input.GetMouseButtonDown(0))
                {
                    float distance = Vector3.Distance(actual.transform.position, referencia);
                    velocidad = (referencia - actual.transform.position) * (distance * force / 5f);
                    var mruv = actual.GetComponent<mruv>();
                    mruv.friccion = false;
                    mruv.velocidadFinal = velocidad;
                    Estado = Estados.Disparado;
                    cameraFollow.BirdToFollow = actual.transform;
                    cameraFollow.IsFollowing = true;
                    mruv.activado = true;
                }
                break;
            case Estados.Disparado:
                break;
            default:
                break;
        }
    }

    public void setActual(GameObject transform)
    {
        actual = transform;
        line = transform.GetComponent<Ave>().line;
        moveAnimation = true;
    }
    

    private void calcularLineaFuturo()
    {
        line.positionCount = 101;
        float distance = Vector3.Distance(actual.transform.position, referencia);
        Vector3 velo = (referencia - actual.transform.position) * (distance * force / 5f);
        line.SetPosition(0, actual.transform.position);
        float time = Time.deltaTime;
        for (int i = 1; i <= 100; i++)
        {
            Vector3 pos = actual.transform.position + velo * time + Physics.gravity * Mathf.Pow(time, 2) / 2;
            line.SetPosition(i, pos);
            time += Time.deltaTime;
        }
    }
}
