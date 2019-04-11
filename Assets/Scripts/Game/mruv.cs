using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mruv : MonoBehaviour
{
    public Vector3 velocidadFinal = Vector3.zero;
    public Vector3 cambioPosicion = Vector3.zero;
    public bool activado;
    public bool friccion;
    public float coeficiente;
    public float coeficienteEstatico;
    const float force = 3f;

    void Start()
    {
        if(name != "ObjetoMoviendose")
        {
            friccion = false;
            coeficienteEstatico = 0.4f;
            coeficiente = 0.9f;
        }
        
    }


    void Update()
    {
        if (activado && velocidadFinal.magnitude > 0.1f)
        {
            cambioPosicion = (velocidadFinal * Time.deltaTime) + (Physics.gravity * Time.deltaTime*Time.deltaTime/2);
            if (friccion == false)
            {
                velocidadFinal.y += Physics.gravity.y * Time.deltaTime;
            }
            else
            {
                cambioPosicion.y = 0;
                float velocidadRestante = -Physics.gravity.y*coeficiente * Time.deltaTime * Mathf.Sign(velocidadFinal.x);
                if (Mathf.Abs(velocidadFinal.x) <= Mathf.Abs(velocidadRestante))
                {
                    velocidadFinal.x = 0;
                }
                else
                {
                    velocidadFinal.x -= velocidadRestante;
                }
            }
            transform.Translate(cambioPosicion);
        }
    }

    public void CambiarVelocidad(float angulo)
    {
        velocidadFinal = new Vector3(velocidadFinal.magnitude * Mathf.Cos(angulo), velocidadFinal.magnitude * Mathf.Sin(angulo));
    }


}
