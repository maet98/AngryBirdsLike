using UnityEngine;
using System.Collections;

public class Pig : MonoBehaviour
{

    public float Health = 150f;
    AudioManagerGame audio;
    public Sprite SpriteShownWhenHurt;
    private float ChangeSpriteHealth;

    private void Awake()
    {
        audio = GameObject.Find("AudioManager").GetComponent<AudioManagerGame>();
    }

    // Use this for initialization
    void Start()
    {
        ChangeSpriteHealth = Health - 30f;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.GetComponent<Rigidbody2D>() == null) return;
        if(col.gameObject.tag == "Floor")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().destruido(tag);
            Destroy(this.gameObject);
        }
        //si fue golpeada por una ave
        if (col.gameObject.tag == "Bird")
        {
            audio.PlayEnemigoDamage();
            GameObject.Find("GameManager").GetComponent<GameManager>().destruido(tag);
            Destroy(gameObject);
        }
        else //we're hit by something else
        {
            //calculate the damage via the hit object velocity
            float damage = col.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude * 10;
            Health -= damage;
            //No sonar por un poco de daño
            if (damage >= 10)
                audio.PlayEnemigoDamage();

            if (Health < ChangeSpriteHealth)
            {
                //change the shown sprite
                GetComponent<SpriteRenderer>().sprite = SpriteShownWhenHurt;
            }
            if (Health <= 0)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().destruido(tag);
                Destroy(this.gameObject);
            }
        }
    }

    //sound found in
    //https://www.freesound.org/people/yottasounds/sounds/176731/
}
