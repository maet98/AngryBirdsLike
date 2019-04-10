using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour
{
    AudioManagerGame audio;
    private void Awake()
    {
        audio = GameObject.Find("AudioManager").GetComponent<AudioManagerGame>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Rigidbody2D>() == null) return;

        float damage = col.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude * 10;
        //don't play audio for small damages
        if (damage >= 10)
        {
            audio.playMadera();
        }
        //decrease health according to magnitude of the object that hit us
        Health -= damage;
        //if health is 0, destroy the block
        if (Health <= 0)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().destruido(tag);
            Destroy(this.gameObject);
        }
    }

    public float Health = 70f;


    //wood sound found in 
    //https://www.freesound.org/people/Srehpog/sounds/31623/
}
