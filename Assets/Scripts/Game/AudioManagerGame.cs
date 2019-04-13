using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerGame : MonoBehaviour
{
    public AudioSource Tiro;
    public AudioSource Madera;
    public AudioSource EnemigoDamage;
    public AudioSource musica;

    void Start()
    {
        if (!XmlManager.configuracion.Music)
        {
            musica.Stop();
        }
    }

    public void playTiro()
    {
        if (XmlManager.configuracion.Sonido)
        {
            Tiro.Play();
        }
        
    }

    public void playMadera()
    {
        if (XmlManager.configuracion.Sonido)
        {
            Madera.Play();
        }
        
    }

    public void PlayEnemigoDamage()
    {
        if (XmlManager.configuracion.Sonido)
        {
            EnemigoDamage.Play();
        }
        
    }
}
