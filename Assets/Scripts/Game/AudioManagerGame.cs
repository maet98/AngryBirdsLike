using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerGame : MonoBehaviour
{
    public AudioSource Tiro;
    public AudioSource Madera;
    public AudioSource EnemigoDamage;

    void Start()
    {
        
    }

    public void playTiro()
    {
        Tiro.Play();
    }

    public void playMadera()
    {
        Madera.Play();
    }

    public void PlayEnemigoDamage()
    {
        EnemigoDamage.Play();
    }
}
