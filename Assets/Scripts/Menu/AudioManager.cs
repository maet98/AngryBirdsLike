using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip clickSound;
    AudioSource fuenteAudio; 


    void Start()
    {
        fuenteAudio = GetComponent<AudioSource>();
           
       
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            fuenteAudio.clip = clickSound;
            fuenteAudio.Play();
        }
    }

  
}
