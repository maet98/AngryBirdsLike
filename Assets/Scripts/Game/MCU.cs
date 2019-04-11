using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCU : MonoBehaviour
{
    public Vector3 velocidadFinal = Vector3.zero;
    Vector3 velocidadQueVenia;
    Vector3 centroAnterior = Vector3.zero;
    public float angulo = 0;
    private float _radio;
    private Vector3 _centro;
    private float tiempoInicio;
    private int reloj;
    private LineRenderer LineRenderer;
    public float ultimaVez = 0;
    public bool activado = false;
    public float anguloInicio;

    void Start()
    {
        activado = false;
    }

    void Update()
    {
        if (activado)
        {
            transform.position = new Vector3(_centro.x + _radio * Mathf.Cos(angulo), _centro.y + _radio * Mathf.Sin(angulo), transform.position.z);
            angulo += reloj * velocidadFinal.magnitude * Time.deltaTime / _radio;
            anguloInicio += reloj * velocidadFinal.magnitude * Time.deltaTime / _radio;

        }
    }

    public float AnguloEntre2Vectores(Vector3 vec1, Vector3 centro)
    {
        Vector3 diff = vec1 - centro;
        angulo = Mathf.Atan2(diff.y, diff.x);
        return angulo;
    }

    public void EstablecerCentro(Vector3 nuevoCentro, float tiempo, Vector3 velocidad)
    {
        _centro = nuevoCentro;
        _radio = (float)calcularDistancia(transform.position, _centro);
        tiempoInicio = tiempo;
        velocidadQueVenia = velocidad;
        velocidadFinal = velocidad;
        calcularTorque(transform.position, _centro);
        angulo = AnguloEntre2Vectores(transform.position, _centro);
        velocidadFinal = new Vector3(10, 10);
        anguloInicio = 0;
        centroAnterior = _centro;

    }

    double calcularDistancia(Vector3 a, Vector3 b)
    {
        return Mathf.Sqrt(Mathf.Pow(a.x - b.x, 2) + Mathf.Pow(a.y - b.y, 2));
    }

    double productoEscalar(Vector3 a, Vector3 b)
    {
        return (a.x * b.x) + (a.y * b.y);
    }

    private void calcularTorque(Vector3 objeto, Vector3 centro)
    {
        if (objeto.x > centro.x)
        {
            reloj = (velocidadQueVenia.y > 0 ? 1 : -1);
        }
        else if (objeto.x < centro.x)
        {
            reloj = (velocidadQueVenia.y > 0 ? -1 : 1);
        }
        else
        {
            reloj = (objeto.y < centro.y ? -1 : 1)
                * (velocidadQueVenia.x > 0 ? -1 : 1);
        }

    }

}
