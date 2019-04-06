using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource enter;
    public AudioSource exit;
    public AudioSource click;
    public AudioSource musica;

    private void Start()
    {
       
            musica.Stop();
       
    }

    public void playEnter()
    {

            enter.Play();
        
        
    }

    public void playExit()
    {
       
            exit.Play();

    }

    public void playClick()
    {
      
            click.Play();

    }
}
