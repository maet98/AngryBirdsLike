using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class AudioManager : MonoBehaviour
{
    public AudioSource click;
    public AudioSource music;


    void Start()
    {
        if (!XmlManager.configuracion.Music)
        {
            music.Stop();
        }
       
    }

    void Update()
    {
    }

    public void playClick()
    {
        if (XmlManager.configuracion.Sonido)
        {
            click.Play();
        }

    }

  
}
