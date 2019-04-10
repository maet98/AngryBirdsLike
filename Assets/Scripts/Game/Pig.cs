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

        //if we are hit by a bird
        if (col.gameObject.tag == "Bird")
        {
            audio.PlayEnemigoDamage();
            Destroy(gameObject);
        }
        else //we're hit by something else
        {
            //calculate the damage via the hit object velocity
            float damage = col.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude * 10;
            Health -= damage;
            //don't play sound for small damage
            if (damage >= 10)
                audio.PlayEnemigoDamage();

            if (Health < ChangeSpriteHealth)
            {
                //change the shown sprite
                GetComponent<SpriteRenderer>().sprite = SpriteShownWhenHurt;
            }
            if (Health <= 0) Destroy(this.gameObject);
        }
    }


}
