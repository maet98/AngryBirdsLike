using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource enter;
    public AudioSource exit;
    public AudioClip click;
    public AudioSource musica;

    void Start()
    {
        musica = GetComponent<AudioSource>();
           
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            musica.clip = click;
            musica.Play();
        }
    }

  
}
